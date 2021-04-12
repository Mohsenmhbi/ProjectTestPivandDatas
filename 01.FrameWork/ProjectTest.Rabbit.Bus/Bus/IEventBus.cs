using ProjectTest.FrameWork.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTest.Rabbit.Bus
{
    public interface IEventBus
    {

        Task Publish<T>(T @event) where T : IEvent;

        Task Subscribe<T>() where T : IEvent;


    }
}
