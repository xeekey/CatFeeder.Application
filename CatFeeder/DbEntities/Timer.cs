using CatFeeder.Models;
using SQLite;
using System;
using System.ComponentModel.DataAnnotations;

namespace CatFeeder.DbEntities
{
    [Table("Timers")]
    public class Timer
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [Required]
        public TimeSpan Time { get; set; }
        public int RepeatDays { get; set; }
        public bool IsToggled { get; set; }
    }
}