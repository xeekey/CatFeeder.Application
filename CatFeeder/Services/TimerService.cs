using SQLite;
using System;
using CatFeeder.Models;

namespace CatFeeder.Services
{
    public class TimerService
    {
        public string StatusMessage { get; set; }
        private readonly SQLiteAsyncConnection conn;

        public TimerService()
        {
            try
            {
                var dbPath = Path.Combine(FileSystem.AppDataDirectory, "MyData.db");
                conn = new SQLiteAsyncConnection(dbPath);
                conn.CreateTableAsync<CatFeeder.DbEntities.Timer>().Wait();
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to initialize database. {0}", ex.Message);
            }
        }
        public async Task AddNewTimer(DateTime date, TimeSpan time)
        {
            try
            {
                var result = await conn.InsertAsync(new DbEntities.Timer { Date = date, Time = time, IsToggled = true });
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
                await conn.UpdateAsync(timer);
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
                var timers = await conn.Table<DbEntities.Timer>()
                    .Where(x => x.Date >= DateTime.Today)
                    .OrderBy(x => x.Date)
                    .ToListAsync();

                if (timers == null || !timers.Any())
                    return Enumerable.Empty<FeedTimer>();

                return timers.Select(timer => new FeedTimer
                {
                    Id = timer.Id,
                    Date = timer.Date.ToShortDateString(),
                    Time = timer.Time.ToString()
                });
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
                return Enumerable.Empty<FeedTimer>();
            }
        }

        public async Task RemoveTimer(int id)
        {
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