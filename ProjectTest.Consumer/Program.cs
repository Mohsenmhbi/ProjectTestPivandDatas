using MassTransit;
using ProjectTest.FrameWork.Events;
using ProjectTest.Rabbit.Bus;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTest.Consumer
{

    public class Program
    {

        public static async Task Main()
        {
           


        }


        public class Display
        {
            private readonly IEventBus eventBus;

            public Display(IEventBus eventBus)
            {
                this.eventBus = eventBus;
            }

            public async Task ShowEvents()
            {
                 await  eventBus.Subscribe();
            }

        }
    }
}

