using CatFeeder.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatFeeder.Models
{
    public class FeedTimer
    {
        public TimeSpan TimeOfDay { get; set; }
        public List<Weekdays> RepeatingDays { get; set; }

    }
}
