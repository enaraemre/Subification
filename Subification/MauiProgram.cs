using SUBIFICATION.Data;
using SUBIFICATION.Views;
using Plugin.LocalNotification;


namespace SUBIFICATION;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()			
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			})
            .UseLocalNotification();

        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddTransient<UpdatePage>();


        builder.Services.AddSingleton<SubificationDatabase>();

        return builder.Build();
	}
}
