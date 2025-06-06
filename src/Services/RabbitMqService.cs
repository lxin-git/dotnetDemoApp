using RabbitMQ.Client;
using System.Text;
using Microsoft.Extensions.Options;

namespace DemoApp.Services
{
    public class RabbitMqService
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;

        public RabbitMqService(IOptions<RabbitMqOptions> options)
        {
            var config = options.Value;
            var factory = new ConnectionFactory()
            {
                HostName = config.HostName,
                UserName = config.UserName,
                Password = config.Password,
                Port = config.Port
            };
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.QueueDeclare(queue: "demoqueue", durable: false, exclusive: false, autoDelete: false, arguments: null);
        }

        public void SendMessage(string message)
        {
            var body = Encoding.UTF8.GetBytes(message);
            _channel.BasicPublish(exchange: "", routingKey: "demoqueue", basicProperties: null, body: body);
        }
    }
}