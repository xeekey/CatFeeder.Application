using CatFeeder.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatFeeder.Models
{
    public class Alarm
    {
        public string AlarmName { get; set; }
        public TimeSpan AlarmTime { get; set; }
        public DateTime Date { get; set; }
        public RepeatOption RepeatOption { get; set; }
    }
}
