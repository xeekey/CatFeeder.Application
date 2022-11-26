using System.ComponentModel.DataAnnotations;
using SQLite;

namespace CatFeeder.DbEntities
{
    [Table("Timers")]
    public class Timer
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [Required]
        public DateTime Date { get; set; }
    }
}
