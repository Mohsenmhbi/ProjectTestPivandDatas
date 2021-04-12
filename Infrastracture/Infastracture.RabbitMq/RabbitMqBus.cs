using ProjectTest.FrameWork.Events;
using ProjectTest.Rabbit.Bus;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using System.Threading.Tasks;

namespace Infastracture.RabbitMq
{
    public class RabbitMqBus: IEventBus
    {
        public async Task Publish<T>(T @event) where T : IEvent
        {

            #region Publish

            var factory = new ConnectionFactory()
            {
                HostName = "localhost"
            };
            using (var connection = factory.CreateConnection())
            using (var chanell = connection.CreateModel())
            {
                var eventName = @event.GetType().Name;
                chanell.QueueDeclare(eventName, false, false, false, null);
                string message = Newtonsoft.Json.JsonConvert.SerializeObject(@event);
                byte[] body = Encoding.UTF8.GetBytes(message);
                chanell.BasicPublish("", eventName, null, body);
            }
            #endregion
        }


        public async Task Subscribe<T>() where T : IEvent
        {
            #region Ok2
            var factory = new ConnectionFactory()
            {
                HostName = "localhost",
                DispatchConsumersAsync = true

            };
            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();
            var eventName = typeof(T).Name;
            channel.QueueDeclare
                (eventName, false, false, false, null);

            var consumer = new
                AsyncEventingBasicConsumer(channel);
            consumer.Received += Consumer_Received;
            channel.BasicConsume(eventName, true, consumer);
            #endregion
        }


        #region Consumer_Received
        private Task Consumer_Received(object sender, BasicDeliverEventArgs e)
        {
            var eventName = e.RoutingKey;
            string message = Encoding.UTF8.GetString(e.Body.ToArray());

            try
            {
                Console.WriteLine(message);
                Console.ReadKey();
                return Task.CompletedTask;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        #endregion
    }
}

