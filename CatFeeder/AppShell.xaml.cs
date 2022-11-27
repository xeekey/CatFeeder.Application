using CatFeeder.Interfaces;
using CatFeeder.View;
using CommunityToolkit;

namespace CatFeeder;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();


		Routing.RegisterRoute(nameof(SchedulerPage), typeof(SchedulerPage));
		Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
        Routing.RegisterRoute(nameof(CreateTimerPage), typeof(CreateTimerPage));
    }


}
