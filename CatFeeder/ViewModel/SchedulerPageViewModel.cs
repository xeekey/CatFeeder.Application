using CatFeeder.Models;
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

namespace CatFeeder.ViewModel
{
    public partial class SchedulerPageViewModel : BaseViewModel
    {

        public SchedulerPageViewModel()
        {
            Title = "Planlægning";
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
                await Shell.Current.DisplayAlert("Error", "Something went wrong! Contact Kasper", "OK!");
            }
            finally { IsBusy = false; }
        }
    }
}
