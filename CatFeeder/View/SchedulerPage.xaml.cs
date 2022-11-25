using CatFeeder.ViewModel;

namespace CatFeeder.View;

public partial class SchedulerPage : ContentPage
{
	public SchedulerPage(SchedulerPageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}

}

