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
using System.Security.Claims;

namespace CatFeeder.ViewModel
{
    public partial class SchedulerPageViewModel : BaseViewModel
    {
        public TimeSpan AlarmTime { get; set; }
        public string AlarmName { get; set; }
        public ObservableCollection<string> RepeatOptions { get; set; }
        public string SelectedRepeatOption { get; set; }
        public ObservableCollection<Alarm> Alarms { get; set; }
        public Alarm SelectedAlarm { get; set; }

        public bool HasSelectedAlarm
        {
            get
            {
                return SelectedAlarm != null;
            }
        }

        TimerService timerService;
        public SchedulerPageViewModel(TimerService timerService)
        {
            RepeatOptions = new ObservableCollection<string>()
            {
                "Never",
                "Daily",
                "Weekly",
                "Monthly"
            };
            this.timerService = timerService;
            Alarms = new ObservableCollection<Alarm>();

        }

        [RelayCommand]
        async Task SaveAlarmAsync()
        {
            // Save the alarm to the database or local storage.
        }

        [RelayCommand]
        async Task DeleteAlarmAsync()
        {
            // Delete the selected alarm from the database or local storage.
        }

        [RelayCommand]
        async Task GetTimersAsync()
        {
            if (IsBusy)
            {
                return;
            }

            try
            {
                IsBusy = true;
                Alarms.Clear();

                var timers = await timerService.GetAllTimers();
                foreach (var timer in timers)
                {
                    Alarms.Add(timer);
                }
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




        //TimerService timerService;

        //public ObservableRangeCollection<FeedTimer> Timers { get; }
        //public SchedulerPageViewModel(TimerService timerService)
        //{
        //    Title = "Planlægning";
        //    this.timerService = timerService;
        //    Timers = new ObservableRangeCollection<FeedTimer>();
        //}

        //[RelayCommand]
        //async Task GetTimersAsync()
        //{
        //    if (IsBusy)
        //    {
        //        return;
        //    }

        //    try
        //    {
        //        IsBusy = true;
        //        Timers.Clear();

        //        var timers = await timerService.GetAllTimers();
        //        Timers.AddRange(timers);
        //    }
        //    catch (Exception ex)
        //    {
        //        Debug.WriteLine(ex);
        //        await Shell.Current.DisplayAlert("Fejl", "Noget gik galt! Kontakt Kasper", "OK!");
        //    }
        //    finally
        //    {
        //        IsBusy = false;
        //    }
        //}

        //[RelayCommand]
        //async Task CreateTimerAsync()
        //{
        //    if (IsBusy)
        //    {
        //        return;
        //    }

        //    try
        //    {
        //        await Shell.Current.GoToAsync($"{nameof(CreateTimerPage)}");
        //    }
        //    catch (Exception ex)
        //    {
        //        Debug.WriteLine(ex);
        //        await Shell.Current.DisplayAlert("Fejl", "Noget gik galt! Kontakt Kasper", "OK!");
        //    }
        //}

        //[RelayCommand]
        //async Task Remove(FeedTimer timer)
        //{
        //    await timerService.RemoveTimer(timer.Id);
        //    await Refresh();
        //}

        //[RelayCommand]
        //async Task Refresh()
        //{
        //    try
        //    {
        //        IsBusy = true;

        //        var timers = await timerService.GetAllTimers();
        //        Timers.Clear();

        //        Timers.AddRange(timers);
        //    }
        //    catch (Exception ex)
        //    {
        //        Debug.WriteLine(ex);
        //        await Shell.Current.DisplayAlert("Fejl", "Noget gik galt! Kontakt Kasper", "OK!");
        //    }
        //    finally
        //    {
        //        IsBusy = false;
        //    }
        //}
    }
}