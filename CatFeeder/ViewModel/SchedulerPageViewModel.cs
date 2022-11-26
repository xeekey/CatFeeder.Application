using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CatFeeder.Services;
using System.Diagnostics;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;
using CatFeeder.View;
using CatFeeder.Models;

namespace CatFeeder.ViewModel
{
    public partial class SchedulerPageViewModel : BaseViewModel
    {
        TimerService timerService;

        public ObservableCollection<FeedTimer> Timers { get; } = new();
        public SchedulerPageViewModel(TimerService timerService)
        {
            Title = "Planlægning";
            this.timerService = timerService;
            GetTimersAsync();
        }

        [RelayCommand]
        async Task GetTimersAsync()
        {
            if (IsBusy)
                return;

            try
            {
                IsBusy = true;
                //var timers = timerService.GetAllTimers();


                var timers = new List<FeedTimer>() { new FeedTimer { Date = "ghe"} };

                if (Timers.Count != 0)
                    Timers.Clear();

                foreach (var timer in timers)
                    Timers.Add(timer);

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                await Shell.Current.DisplayAlert("Fejl", "Noget gik galt! Kontakt Kasper", "OK!");
            }
            finally { IsBusy = false; }
        }


        [RelayCommand]
        async Task CreateTimerAsync()
        {
            if (IsBusy)
                return;
            try
            {
                await Shell.Current.GoToAsync($"{nameof(CreateTimerPage)}");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                await Shell.Current.DisplayAlert("Fejl", "Noget gik galt! Kontakt Kasper", "OK!");
            }
            finally { IsBusy = false; }
        }
    }
}
