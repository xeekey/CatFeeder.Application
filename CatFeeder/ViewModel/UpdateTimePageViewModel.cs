using CatFeeder.Models;
using CatFeeder.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;

namespace CatFeeder.ViewModel
{
    public class UpdateTimePageViewModel : BaseViewModel
    {

        public TimeSpan Time { get; set; }
        public bool Monday { get; set; }
        public bool Tuesday { get; set; }
        public bool Wednesday { get; set; }
        public bool Thursday { get; set; }
        public bool Friday { get; set; }
        public bool Saturday { get; set; }
        public bool Sunday { get; set; }

        public IRelayCommand UpdateTimerCommand => new RelayCommand(UpdateTimer);

        TimerService _timerService;
        FeedTimer _timer;

        public UpdateTimePageViewModel(TimerService timerService, FeedTimer timer)
        {
            Title = "Update Timer";
            _timerService = timerService;
            _timer = timer;

            Time = timer.Time;
            Monday = timer.RepeatDays.Monday;
            Tuesday = timer.RepeatDays.Tuesday;
            Wednesday = timer.RepeatDays.Wednesday;
            Thursday = timer.RepeatDays.Thursday;
            Friday = timer.RepeatDays.Friday;
            Saturday = timer.RepeatDays.Saturday;
            Sunday = timer.RepeatDays.Sunday;
        }

        private async void UpdateTimer()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                _timer.RepeatDays = new RepeatDays { Monday = Monday, Tuesday = Tuesday, Wednesday = Wednesday, Thursday = Thursday, Friday = Friday, Saturday = Saturday, Sunday = Sunday };
                _timer.Time = Time;
                await _timerService.UpdateTimer(_timer);

                // Navigate back to the previous page
                await Shell.Current.Navigation.PopAsync();
            }
            catch (Exception ex)
            {
                // Handle the error
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
