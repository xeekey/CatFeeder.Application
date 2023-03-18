using Android;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Util;
using AndroidX.Core.App;
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

            if (Build.VERSION.SdkInt >= BuildVersionCodes.S)
            {
                if (context.CheckSelfPermission(Manifest.Permission.ScheduleExactAlarm) != Permission.Granted)
                {
                    // Request the permission from the user
                    ActivityCompat.RequestPermissions((Activity)context, new[] { Manifest.Permission.ScheduleExactAlarm }, 0);

                    // If the permission is still not granted, return without scheduling the alarm
                    if (context.CheckSelfPermission(Manifest.Permission.ScheduleExactAlarm) != Permission.Granted)
                    {
                        return;
                    }
                }
            }

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
            long triggerAtMillis = DateTimeOffset.Now.ToUnixTimeMilliseconds() + (long)timeUntilTrigger.TotalMilliseconds;

            // Schedule the alarm
            if (Build.VERSION.SdkInt >= BuildVersionCodes.M)
            {
                alarmManager.SetExactAndAllowWhileIdle(AlarmType.RtcWakeup, triggerAtMillis, pendingIntent);
            }
            else
            {
                alarmManager.SetExact(AlarmType.RtcWakeup, triggerAtMillis, pendingIntent);
            }
            Log.Debug("FeedAlarmScheduler", $"Scheduling alarm with ID {timer.Id} at {nextTriggerTime}");
        }
    }
}