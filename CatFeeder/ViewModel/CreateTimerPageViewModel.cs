using CatFeeder.Models;
using CatFeeder.Platforms.Android;
using CatFeeder.Services;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace CatFeeder.ViewModel
{
    public partial class CreateTimerPageViewModel : BaseViewModel
    {
        private TimeSpan time;

        public TimeSpan Time
        {
            get => time;
            set => SetProperty(ref time, value);
        }

        public bool Monday { get; set; }
        public bool Tuesday { get; set; }
        public bool Wednesday { get; set; }
        public bool Thursday { get; set; }
        public bool Friday { get; set; }
        public bool Saturday { get; set; }
        public bool Sunday { get; set; }

        private TimerService timerService;

        public CreateTimerPageViewModel(TimerService TimerService)
        {
            Title = "Opret planlægning";
            timerService = TimerService;
        }

        [RelayCommand]
        async Task CreateTimer()
        {
            if (IsBusy)
                return;
            try
            {
                IsBusy = true;

                // Pass the days of the week properties along with the time to the AddNewTimer method
                await timerService.AddNewTimer(new FeedTimer { Time = time, RepeatDays = new RepeatDays { Monday = Monday, Tuesday = Tuesday, Wednesday = Wednesday, Thursday = Thursday, Friday = Friday, Saturday = Saturday, Sunday = Sunday }});
                FeedAlarmScheduler.ScheduleFeedAlarm(new FeedTimer { Time = time, RepeatDays = new RepeatDays { Monday = Monday, Tuesday = Tuesday, Wednesday = Wednesday, Thursday = Thursday, Friday = Friday, Saturday = Saturday, Sunday = Sunday }});

                IsBusy = false;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
                await Shell.Current.DisplayAlert("Error", "Something went wrong! Contact Kasper", "OK!");
            }
            finally { IsBusy = false; }
        }
    }
}
