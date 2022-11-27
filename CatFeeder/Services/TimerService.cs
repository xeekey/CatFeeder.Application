using SQLite;
using System;
using CatFeeder.Models;

namespace CatFeeder.Services
{
    public class TimerService
    {
        public string StatusMessage { get; set; }
        SQLiteAsyncConnection conn;

        async Task Init()
        {
            if (conn != null)
                return;

            var dbPath = Path.Combine(FileSystem.AppDataDirectory, "MyData.db"); 
            conn = new SQLiteAsyncConnection(dbPath);
            await conn.CreateTableAsync<CatFeeder.DbEntities.Timer>();
        }

        public async Task AddNewTimer(DateTime date, TimeSpan time)
        {
            int result = 0;
            try
            {
                await Init();
                result = await conn.InsertAsync(new DbEntities.Timer { Date = date, Time = time, IsToggled = true });
                StatusMessage = string.Format("{0} record(s) added (Name: {1})", result, date);
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to add {0}. Error: {1}", date, ex.Message);
            }
        }

        public async Task UpdateTimer(FeedTimer timer)
        {
            try
            {
                await Init();
                var result = await conn.UpdateAsync(timer);
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to edit {0}. Error: {1}", timer.Date, ex.Message);
            }
        }



        public async Task<IEnumerable<FeedTimer>> GetAllTimers()
        {
            try
            {
                await Init();
                var timers = await conn.Table<DbEntities.Timer>().Where(x => x.Date >= DateTime.Today).OrderBy(x => x.Date).ToListAsync();

                if (timers.Count() == 0)
                    return new List<FeedTimer>();

                return ParseToViewModelData(timers);
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
            }
            return null;
        }

        public async Task RemoveTimer(int id)
        {
            await Init();
            await conn.DeleteAsync<DbEntities.Timer>(id);
        }

        public IEnumerable<FeedTimer> ParseToViewModelData(IEnumerable<DbEntities.Timer> timers)
        {
            List<FeedTimer> feedTimers = new List<FeedTimer>();
            foreach (var timer in timers)
            {
                FeedTimer feedTimer = new FeedTimer
                {
                    Id = timer.Id,
                    Date = timer.Date.ToShortDateString(),
                    Time = timer.Time.ToString()
                };
                feedTimers.Add(feedTimer);
            }
            return feedTimers;
        }
    }
}