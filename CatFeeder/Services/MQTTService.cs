using Microsoft.Maui.Devices;
using Microsoft.Maui.Storage;
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
        static MqttClient mqttClient = new MqttClient("kasp827b.cloud.shiftr.io", 1883, false, null, null, MqttSslProtocols.None);
        public async Task ConnectToMQTT()
        {
            if (!mqttClient.IsConnected)
                mqttClient.Connect("AppUser", "kasp827b", "54q8XajqeRHAFT5W");
        }

        public async Task Feed()
        {
            if (!mqttClient.IsConnected)
                await ConnectToMQTT();
            mqttClient.Publish("/feed", Encoding.UTF8.GetBytes("feedingtime"));
        }

    }
}
