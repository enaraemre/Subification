using System.Collections.ObjectModel;
using SUBIFICATION.Data;
using SUBIFICATION.Entities;
using Plugin.LocalNotification;
using Microsoft.Identity.Client;
using System.Diagnostics;


namespace SUBIFICATION.Views;

public partial class MainPage : ContentPage
{
    public IPublicClientApplication IdentityClient { get; set; }

    SubificationDatabase database;
    public ObservableCollection<Subscriptions> Items { get; set; } = new();
    public MainPage(SubificationDatabase subificationDatabase)
    {
        InitializeComponent();
        SubificationService = new RemoteSubificationService(GetAuthenticationToken);
       
        database = subificationDatabase;
        BindingContext = this;
    }

    protected override async void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
        var items = await database.GetItemsAsync();
        MainThread.BeginInvokeOnMainThread(() =>
        {
            Items.Clear();
            var itemsSorted = from item in items 
                              orderby item.RenewDate
                              select item;

            DateTime today = DateTime.Today;

            foreach (var item in itemsSorted)
            {
                Items.Add(item);
                SendNotification(item);
            }            
        });
    }

   private void SendNotification(Subscriptions item)
    {
        var request = new NotificationRequest
        {
            NotificationId = item.ID,
            Title = "Check the " + item.Name,
            Subtitle = "Renewing date for the subscription is close",
            Description = "Reminder",
            BadgeNumber = 42,
            Schedule = new NotificationRequestSchedule
            {
                NotifyTime = DateTime.Now.AddSeconds(5),
                NotifyRepeatInterval = TimeSpan.FromDays(1),
            },
        };
         LocalNotificationCenter.Current.Show(request);
    }

    async void OnItemAdded(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(UpdatePage), true, new Dictionary<string, object>
        {
            ["Item"] = new Subscriptions()
        });
    }


    private async void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is not Subscriptions item)
            return;

        await Shell.Current.GoToAsync(nameof(UpdatePage), true, new Dictionary<string, object>
        {
            ["Item"] = item
        });
    }
}

