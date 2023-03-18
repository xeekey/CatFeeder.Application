using Android.App;
using Android.Content;
using Android.OS;
using Android.Util;
using CatFeeder.Models;
using System;
using Application = Android.App.Application;

namespace CatFeeder.Platforms.Android
{
    public static class FeedAlarmScheduler
    {
        public static void ScheduleFeedAlarm(FeedTimer timer)
        {
            Context context = Application.Context;
            AlarmManager alarmManager = (AlarmManager)context.GetSystemService(Context.AlarmService);
            Intent alarmIntent = new Intent(context, typeof(FeedAlarmReceiver));
            alarmIntent.PutExtra("AlarmTime", timer.Time.ToString());
            PendingIntent pendingIntent = PendingIntent.GetBroadcast(context, timer.Id, alarmIntent, PendingIntentFlags.Immutable);

            // Calculate the time until the next alarm
            DateTime now = DateTime.Now;
            DateTime todayScheduledTime = DateTime.Today.Add(timer.Time);
            DateTime nextTriggerTime = todayScheduledTime;

            if (todayScheduledTime < now)
            {
                nextTriggerTime = nextTriggerTime.AddDays(1);
            }

            TimeSpan timeUntilTrigger = nextTriggerTime - now;
            long triggerAtMillis = SystemClock.ElapsedRealtime() + (long)timeUntilTrigger.TotalMilliseconds;

            // Schedule the alarm
            alarmManager.SetInexactRepeating(AlarmType.ElapsedRealtimeWakeup, triggerAtMillis, AlarmManager.IntervalDay, pendingIntent);
            Log.Debug("FeedAlarmScheduler", $"Scheduling alarm with ID {timer.Id} at {nextTriggerTime}");
        }
    }
}