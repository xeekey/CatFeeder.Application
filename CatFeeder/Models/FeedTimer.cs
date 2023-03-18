using CommunityToolkit.Mvvm.Input;
using SQLite;

namespace CatFeeder.Models
{
    public class FeedTimer
    {
        public int Id { get; set; }
        public TimeSpan Time { get; set; }
        public RepeatDays RepeatDays { get; set; }
        public bool IsToggled { get; set; }
        public RelayCommand ToggleCommand { get; set; }
    }

    public class RepeatDays
    {
        [Column("Monday")]
        public int MondayInt { get; set; }

        [Column("Tuesday")]
        public int TuesdayInt { get; set; }

        [Column("Wednesday")]
        public int WednesdayInt { get; set; }

        [Column("Thursday")]
        public int ThursdayInt { get; set; }

        [Column("Friday")]
        public int FridayInt { get; set; }

        [Column("Saturday")]
        public int SaturdayInt { get; set; }

        [Column("Sunday")]
        public int SundayInt { get; set; }

        [Ignore]
        public bool Monday
        {
            get => MondayInt == 1;
            set => MondayInt = value ? 1 : 0;
        }

        [Ignore]
        public bool Tuesday
        {
            get => TuesdayInt == 1;
            set => TuesdayInt = value ? 1 : 0;
        }

        [Ignore]
        public bool Wednesday
        {
            get => WednesdayInt == 1;
            set => WednesdayInt = value ? 1 : 0;
        }

        [Ignore]
        public bool Thursday
        {
            get => ThursdayInt == 1;
            set => ThursdayInt = value ? 1 : 0;
        }

        [Ignore]
        public bool Friday
        {
            get => FridayInt == 1;
            set => FridayInt = value ? 1 : 0;
        }

        [Ignore]
        public bool Saturday
        {
            get => SaturdayInt == 1;
            set => SaturdayInt = value ? 1 : 0;
        }

        [Ignore]
        public bool Sunday
        {
            get => SundayInt == 1;
            set => SundayInt = value ? 1 : 0;
        }

        // Convert the RepeatDays properties to an int value
        public int ToInt()
        {
            int intValue = 0;

            if (Monday) intValue |= (1 << 0);
            if (Tuesday) intValue |= (1 << 1);
            if (Wednesday) intValue |= (1 << 2);
            if (Thursday) intValue |= (1 << 3);
            if (Friday) intValue |= (1 << 4);
            if (Saturday) intValue |= (1 << 5);
            if (Sunday) intValue |= (1 << 6);

            return intValue;
        }

        // Create a RepeatDays instance from an int value
        public static RepeatDays FromInt(int intValue)
        {
            return new RepeatDays
            {
                Monday = (intValue & (1 << 0)) != 0,
                Tuesday = (intValue & (1 << 1)) != 0,
                Wednesday = (intValue & (1 << 2)) != 0,
                Thursday = (intValue & (1 << 3)) != 0,
                Friday = (intValue & (1 << 4)) != 0,
                Saturday = (intValue & (1 << 5)) != 0,
                Sunday = (intValue & (1 << 6)) != 0
            };
        }
    }
}
