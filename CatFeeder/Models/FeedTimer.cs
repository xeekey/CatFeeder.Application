﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatFeeder.Models
{
    public class FeedTimer
    {
        public int Id { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public bool IsToggled { get; set; }

    }
}
