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
            SendFeedRequest();
            SendNotification(context);
        }

        private async void SendFeedRequest()
        {
            MQTTService mqttService = new MQTTService();
            await mqttService.ConnectToMQTT();
            await mqttService.Feed();
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