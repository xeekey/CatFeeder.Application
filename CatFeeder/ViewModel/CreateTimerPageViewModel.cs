using CatFeeder.Models;
using CatFeeder.Services;
using CommunityToolkit.Mvvm.Input;
using System.Diagnostics;

namespace CatFeeder.ViewModel
{
    [QueryProperty(nameof(Date), nameof(Time))]
    public partial class CreateTimerPageViewModel : BaseViewModel
    {
        DateTime date;
        TimeSpan time;
        
        public DateTime Date { get => date; set => SetProperty(ref date, value); }
        public TimeSpan Time { get => time; set => SetProperty(ref time, value); }

        TimerService timerService;

        public CreateTimerPageViewModel(TimerService TimerService) 
        {
            Title = "Opret planlægning";
            timerService = TimerService;
        }

        [ObservableProperty]
        TimeSpan currentTime = DateTime.Now.TimeOfDay;

        [RelayCommand]
        async Task CreateTimer()
        {
            if (IsBusy)
                return;
            try
            {
                IsBusy = true;
                await timerService.AddNewTimer(date, time);
                IsBusy = false;

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                await Shell.Current.DisplayAlert("Error", "Something went wrong! Contact Kasper", "OK!");
            }
            finally { IsBusy = false; }
        }


    }

}
