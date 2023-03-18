using CatFeeder.ViewModel;

namespace CatFeeder.View;


public partial class UpdateTimePage : ContentPage
{
    public UpdateTimePage(UpdateTimePageViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}

