using CatFeeder.ViewModel;

namespace CatFeeder.View;

public partial class SchedulerPage : ContentPage
{
	public SchedulerPage(SchedulerPageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}

	protected async override void OnAppearing()
	{
		base.OnAppearing();

		var vm = (SchedulerPageViewModel)BindingContext;
		if (vm.Timers.Count == 0)
			await vm.RefreshCommand.ExecuteAsync(nameof(SchedulerPageViewModel));

    }

}

