using System;

namespace Observer
{
    class Program
    {
        static void Main(string[] args)
        {
            SmartHouseUser user = new SmartHouseUser(Room.Bedroom);
            
            user.State = Room.Kitchen;
            
            user.Subscribe(new LightBulb(1));
            user.Subscribe(new LightBulb(3));
            user.Subscribe(new Kettle(2));
            
            user.NotifySubscribers();
        }
    }
}