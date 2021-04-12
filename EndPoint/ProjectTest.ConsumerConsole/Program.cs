using Infastracture.RabbitMq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProjectTest.CoreDomain.TicketUser.Events;
using ProjectTest.CoreDomain.UserProfile.Events;
using ProjectTest.Rabbit.Bus;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using static MassTransit.MessageHeaders;

namespace ProjectTest.ConsumerConsole
{
    class Program
    {
        public async static Task Main(string[] args)
        {
            ServiceProvider serviceProvider = Dependendency();

            var bar = serviceProvider.GetService<IEventBus>();
            await bar.Subscribe<TicketCreated>();
            await bar.Subscribe<UserTicketCreated>();
            await bar.Subscribe<UserRegistered>();
            
            Console.ReadKey();
        }
        static ServiceProvider Dependendency()
        {
            return new ServiceCollection()
                .AddScoped<IEventBus, RabbitMqBus>()
                 .BuildServiceProvider();
        }
    }

   
}
