﻿using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CatFeeder.Models;

namespace CatFeeder.Services
{
    public class TimerService
    {
        public string StatusMessage { get; private set; }
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

        public async Task<FeedTimer> AddNewTimer(FeedTimer feedTimer)
        {
            try
            {
                DbEntities.Timer timerToInsert = new DbEntities.Timer
                {
                    Time = feedTimer.Time,
                    RepeatDays = feedTimer.RepeatDays.ToInt(),
                    IsToggled = feedTimer.IsToggled
                };

                int result = await conn.InsertAsync(timerToInsert);

                StatusMessage = string.Format("{0} record(s) added (Name: {1})", result, feedTimer.Time);

                feedTimer.Id = timerToInsert.Id; // Update the Id of the passed feedTimer object

                return feedTimer;
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to add {0}. Error: {1}", feedTimer.Time, ex.Message);
                return null;
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
                StatusMessage = string.Format("Failed to edit {0}. Error: {1}", timer.Time, ex.Message);
            }
        }

        public async Task<IEnumerable<FeedTimer>> GetAllTimers()
        {
            try
            {
                var timers = await Task.Run(() => conn.Table<DbEntities.Timer>().ToListAsync());

                if (timers == null || !timers.Any())
                    return Enumerable.Empty<FeedTimer>();

                return timers.Select(timer => new FeedTimer
                {
                    Id = timer.Id,
                    Time = timer.Time,
                    RepeatDays = RepeatDays.FromInt(timer.RepeatDays),
                    IsToggled = timer.IsToggled
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
    }
}
