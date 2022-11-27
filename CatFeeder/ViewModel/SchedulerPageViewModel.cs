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
using MvvmHelpers;
using CatFeeder.Interfaces;

namespace CatFeeder.ViewModel
{
    public partial class SchedulerPageViewModel : BaseViewModel
    {
        TimerService timerService;

        public ObservableRangeCollection<FeedTimer> Timers { get; } = new();
        public SchedulerPageViewModel(TimerService timerService)
        {
            Title = "Planlægning";
            this.timerService = timerService;
            Refresh();
        }

        [RelayCommand]
        async Task GetTimersAsync()
        {
            if (IsBusy)
                return;

            try
            {
                IsBusy = true;
                var timers = await timerService.GetAllTimers();

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
            finally 
            {
                IsBusy = false; 
            }
        }

        [RelayCommand]
        async Task Refresh()
        {
            IsBusy = true;
            
            Timers.Clear();
            
            var timers = await timerService.GetAllTimers();
            
            Timers.AddRange(timers);

            IsBusy = false;
        }
    }
}
