using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CatFeeder.Models;
using SQLite;

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
                conn.CreateTableAsync<Alarm>().Wait();
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
                var result = await conn.InsertAsync(new Alarm { Date = date, AlarmTime = time,});
                StatusMessage = string.Format("{0} record(s) added (Name: {1})", result, date);
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to add {0}. Error: {1}", date, ex.Message);
            }
        }

        public async Task UpdateTimer(Alarm timer)
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

        public async Task<IEnumerable<Alarm>> GetAllTimers()
        {
            try
            {
                var alarms = await conn.Table<Alarm>()
                    .Where(x => x.Date >= DateTime.Today)
                    .OrderBy(x => x.Date)
                    .ToListAsync();

                if (alarms == null || !alarms.Any())
                    return Enumerable.Empty<Alarm>();

                return alarms;
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
                return Enumerable.Empty<Alarm>();
            }
        }

        public async Task RemoveTimer(int id)
        {
            await conn.DeleteAsync<Alarm>(id);
        }
    }
}