using CatFeeder.Services;
using CatFeeder.View;
using CatFeeder.ViewModel;

namespace CatFeeder;

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
			});

		builder.Services.AddSingleton<MQTTService>();
        builder.Services.AddSingleton<FeederService>();
        builder.Services.AddSingleton<MainPageViewModel>();
		builder.Services.AddSingleton<SchedulerPageViewModel>();
		builder.Services.AddSingleton<CreateTimerPageViewModel>();
		builder.Services.AddSingleton<MainPage>();
		builder.Services.AddSingleton<SchedulerPage>();
		builder.Services.AddTransient<CreateTimerPage>();


		return builder.Build();
	}
}
