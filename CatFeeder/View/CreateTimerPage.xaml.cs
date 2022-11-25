using CatFeeder.ViewModel;

namespace CatFeeder.View;

public partial class CreateTimerPage : ContentPage
{
	public CreateTimerPage(CreateTimerPageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}


}