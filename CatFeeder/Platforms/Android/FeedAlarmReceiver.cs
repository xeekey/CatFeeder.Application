using Android.App;
using Android.Content;
using Android.OS;
using Android.Util;
using AndroidX.Core.App;
using CatFeeder.Services;

namespace CatFeeder
{
    [BroadcastReceiver(Enabled = true, Exported = true, DirectBootAware = true)]

    public class FeedAlarmReceiver : BroadcastReceiver
    {
        public override async void OnReceive(Context context, Intent intent)
        {
            string alarmTime = intent.GetStringExtra("AlarmTime"); // for debugging
            Log.Debug("FeedAlarmReceiver", $"Alarm scheduled for {alarmTime} triggered at {DateTime.Now}"); // for debugging
            //MQTTService mqttService = new MQTTService();
            //await mqttService.Feed();

            // Send a notification to the user
            SendNotification(context);
        }

        private void SendNotification(Context context)
        {
            const int notificationId = 1;
            string channelId = "cat_feeder_channel";
            string channelName = "Cat Feeder Notifications";

            NotificationManager notificationManager = (NotificationManager)context.GetSystemService(Context.NotificationService);

            if (Build.VERSION.SdkInt >= BuildVersionCodes.O)
            {
                NotificationChannel notificationChannel = new NotificationChannel(channelId, channelName, NotificationImportance.Default);
                notificationManager.CreateNotificationChannel(notificationChannel);
            }

            NotificationCompat.Builder builder = new NotificationCompat.Builder(context, channelId)
                .SetContentTitle("Cat Feeder")
                .SetContentText("Feed request sent.")
                .SetSmallIcon(Resource.Drawable.test)
                .SetAutoCancel(true);

            notificationManager.Notify(notificationId, builder.Build());
        }
    }
}