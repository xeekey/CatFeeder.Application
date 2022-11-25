using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatFeeder.ViewModel
{
    [INotifyPropertyChanged]
    public partial class CreateTimerPageViewModel
    {
        public CreateTimerPageViewModel() 
        {
            
        }

        [ObservableProperty]
        TimeSpan currentTime = DateTime.Now.TimeOfDay;
    }

}
