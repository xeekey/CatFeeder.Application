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
        FeederService feederService;
        public ObservableCollection<FeedResponse> FeedResponses { get; set; }
        
        public MainPageViewModel(FeederService FeederService)
        {
            Title = "Feeder";
            this.feederService = FeederService;

        }

        [RelayCommand]
        async Task CommandStuffAsync()
        {
            if (IsBusy)
                return;
            
            try
            {
                IsBusy = true;
                var responses = 1;
                await Task.Delay(100000);
                //if (FeedResponses != 0)
                    //FeedResponses = 9;
                    //FeedResponses.Clear();

                //foreach (var response in responses)
                //    FeedResponses.Add(response);

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
