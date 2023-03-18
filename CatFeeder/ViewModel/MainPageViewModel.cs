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

namespace CatFeeder.ViewModel
{
    public partial class MainPageViewModel : BaseViewModel
    {
        MQTTService mqttService;
        public ObservableCollection<FeedResponse> FeedResponses { get; set; }
        
        public MainPageViewModel(MQTTService MqttService)
        {
            Title = "Feeder";
            this.mqttService = MqttService;

        }

        [RelayCommand]
        async Task FeedAsync()
        {
            if (IsBusy)
                return;
            
            try
            {
                IsBusy = true;
                //await mqttService.Feed();
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
