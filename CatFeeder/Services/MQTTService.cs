using Microsoft.Maui.Devices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace CatFeeder.Services
{
    
    public class MQTTService
    {
        static MqttClient mqttClient = new MqttClient("tickrider.cloud.shiftr.io", 1883, false, null, null, MqttSslProtocols.None);
        public async Task ConnectToMQTT()
        {
            if (!mqttClient.IsConnected)
                mqttClient.Connect("AppUser", "tickrider", "110899");
        }

        public async Task Feed()
        {
            if (!mqttClient.IsConnected)
                await ConnectToMQTT();
                mqttClient.Publish("/feed", Encoding.UTF8.GetBytes("feedingtime"));
        }


        //public async Task SubscribeAsync()
        //{
        //    if (!mqttClient.IsConnected) // If we arent connected, call connect func again 
        //        await ConnectToMQTTAsync();
         
        //    if (mqttClient.IsConnected) // if we are connected
        //        mqttClient.Subscribe(new string[] { "/feedDone" }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE }); // Subscribe to the topic feedDone
        //}
    }
}
