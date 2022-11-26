using SQLite;
using System;
using CatFeeder.Models;

namespace CatFeeder.Services
{
    public class TimerService
    {
        string _dbPath;

        public string StatusMessage { get; set; }
        SQLiteConnection conn;

        private void Init()
        {
            if (conn != null)
                return;
            conn = new SQLiteConnection(_dbPath);
            conn.CreateTable<CatFeeder.DbEntities.Timer>();
        }

        public TimerService(string dbPath)
        {
            _dbPath = dbPath;
        }

        public void AddNewTimer(DateTime date)
        {
            int result = 0;
            try
            {
                Init();
                result = conn.Insert(new DbEntities.Timer { Date = date });
                // TODO: Insert the new person into the database
                result = 0;

                StatusMessage = string.Format("{0} record(s) added (Name: {1})", result, date);
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to add {0}. Error: {1}", date, ex.Message);
            }
        }



        public List<FeedTimer> GetAllTimers()
        {
            // TODO: Init then retrieve a list of Person objects from the database into a list
            try
            {
                Init();
                return ParseToViewModelData(conn.Table<DbEntities.Timer>().ToList());
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
            }

            return new List<FeedTimer>();
        }

        public List<FeedTimer> ParseToViewModelData(List<DbEntities.Timer> timers)
        {
            List<FeedTimer> feedTimers = new List<FeedTimer>();
            foreach (var timer in timers)
            {
                FeedTimer feedTimer = new FeedTimer
                {
                    Date = timer.Date.ToShortDateString(),
                    Time = timer.Date.ToShortTimeString()
                };
                feedTimers.Add(feedTimer);
            }
            return feedTimers;
        }
    }
}