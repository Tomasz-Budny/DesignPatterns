using System;
using System.Collections.Generic;

namespace Observer
{
    public interface ISubscriber
    {
        void Update(Publisher publisher);
    }
    
    public abstract class Publisher
    {
        protected readonly List<ISubscriber> Subscribers = new List<ISubscriber>();

        public abstract void Subscribe(ISubscriber subscriber);
        public abstract void Unsubscribe(ISubscriber subscriber);
        public abstract void NotifySubscribers();
    }

    public enum Room
    {
        Bedroom,
        Kitchen,
        Bathroom,
        Livingroom
    }

    public class SmartHouseUser : Publisher
    {
        public Room State { get; set; }

        public SmartHouseUser(Room initialState)
        {
            State = initialState;
        }
        
        public override void Subscribe(ISubscriber subscriber)
        {
            if(subscriber != null)
                Subscribers.Add(subscriber);
        }

        public override void Unsubscribe(ISubscriber subscriber)
        {
            if (subscriber != null)
                Subscribers.Remove(subscriber);
        }

        public override void NotifySubscribers()
        {
            foreach (var sub in Subscribers)
            {
                sub.Update(this);
            }
        }
    }
    
    #region Subscribers classes

    public class LightBulb : ISubscriber
    {
        private readonly int id;

        public LightBulb(int id)
        {
            this.id = id;
        }
        public void Update(Publisher publisher)
        {
            Console.WriteLine($"The light bulb with id: {id}, was turned on in the: {((SmartHouseUser)publisher).State}");
        }
    }

    public class Kettle : ISubscriber
    {
        private readonly int id;

        public Kettle(int id)
        {
            this.id = id;
        }
        public void Update(Publisher publisher)
        {
            if (((SmartHouseUser)publisher).State == Room.Kitchen)
            {
                Console.WriteLine("Kettle: I set the temperature to N degrees");
            }
        }
    }
    
    #endregion
}