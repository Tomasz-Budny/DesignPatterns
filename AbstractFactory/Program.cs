using System;

namespace AbstractFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            var androidFactory = new AndroidGUIFactory();
            var iphoneFactory = new IPhoneGUIFactory();
            
            Client.CreateUI(androidFactory);
            Client.CreateUI(iphoneFactory);
        }
    }
}