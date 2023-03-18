using System.Threading.Tasks;
using MQTTnet;
using MQTTnet.Client;

public class MQTTService
{
    private readonly IMqttClient mqttClient;
    private const string BrokerAddress = "kasp827b.cloud.shiftr.io";
    private const int BrokerPort = 1883;
    private const string ClientId = "AppUser";
    private const string Username = "kasp827b";
    private const string Password = "54q8XajqeRHAFT5W";

    public MQTTService()
    {
        var mqttFactory = new MqttFactory();
        mqttClient = mqttFactory.CreateMqttClient();
    }

    public async Task ConnectToMQTT()
    {
        if (!mqttClient.IsConnected)
        {
            var options = new MqttClientOptionsBuilder()
                .WithClientId(ClientId)
                .WithTcpServer(BrokerAddress, BrokerPort)
                .WithCredentials(Username, Password)
                .WithCleanSession()
                .Build();

            mqttClient.DisconnectedAsync += async (s) =>
            {
                await Task.Delay(TimeSpan.FromSeconds(5));
                try
                {
                    await mqttClient.ConnectAsync(options, CancellationToken.None);
                }
                catch
                {
                    // Log exception or handle reconnection failure
                }
            };

            try
            {
                await mqttClient.ConnectAsync(options, CancellationToken.None);
            }
            catch (Exception ex)
            {
                // Log exception or handle connection failure
            }
        }
    }


    public async Task Feed()
    {
        if (!mqttClient.IsConnected)
            await ConnectToMQTT();

        var message = new MqttApplicationMessageBuilder()
            .WithTopic("/feed")
            .WithPayload("feedingtime")
            .WithRetainFlag()
            .Build();

        await mqttClient.PublishAsync(message, CancellationToken.None);
    }
}
