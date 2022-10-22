using System;

namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            DataBase dataBase = DataBase.GetInstance();
            dataBase.SomeBusinessLogic();
        }
    }
}