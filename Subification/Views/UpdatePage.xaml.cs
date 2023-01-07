using SUBIFICATION.Data;
using SUBIFICATION.Entities;

namespace SUBIFICATION.Views;

[QueryProperty("Item", "Item")]
public partial class UpdatePage : ContentPage
{
    Subscriptions item;
    public Subscriptions Item
    {
        get => BindingContext as Subscriptions;
        set => BindingContext = value;
    }
    SubificationDatabase database;
    public UpdatePage(SubificationDatabase subificationDatabase)
    {
        InitializeComponent();
        database = subificationDatabase;
    }

    async void OnSaveClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(Item.Name))
        {
            await DisplayAlert("Name Required", "Please enter a name for the todo item.", "OK");
            return;
        }

        await database.SaveItemAsync(Item);
        await Shell.Current.GoToAsync("..");
    }

    async void OnDeleteClicked(object sender, EventArgs e)
    {
        if (Item.ID == 0)
            return;
        await database.DeleteItemAsync(Item);
        await Shell.Current.GoToAsync("..");
    }

    async void OnCancelClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }

    async void OnReminderClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}