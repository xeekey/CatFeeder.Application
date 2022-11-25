using System.ComponentModel;


namespace CatFeeder.ViewModel
{
    [INotifyPropertyChanged]
    public partial class BaseViewModel
    {
        public BaseViewModel() 
        {
        }

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsNotBusy))]
        bool isBusy;

        [ObservableProperty]
        string title;
        public bool IsNotBusy => !IsBusy;
       
    }
}
