﻿using CatFeeder.Models;

namespace CatFeeder.ViewModel
{
    public partial class CreateTimerPageViewModel : BaseViewModel
    {

        public FeedTimer FeedTimer { get; set; }

        public CreateTimerPageViewModel() 
        {
            Title = "Opret planlægning";
        }

        [ObservableProperty]
        TimeSpan currentTime = DateTime.Now.TimeOfDay;

        //async Task CreateTimer()
        //{
        //    if (IsBusy)
        //        return;
        //    try
        //    {
        //        IsBusy = true;
        //        FeedTimer.Date = currentTime;

        //    }
        //    catch (Exception ex)
        //    {
        //        Debug.WriteLine(ex);
        //        await Shell.Current.DisplayAlert("Error", "Something went wrong! Contact Kasper", "OK!");
        //    }
        //    finally { IsBusy = false; }
        //}


    }

}