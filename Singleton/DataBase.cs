using System;

namespace Singleton
{
    // Singleton use case example
    public class DataBase
    {
        private DataBase() {}
        private static DataBase _dataBase;

        public static DataBase GetInstance()
        {
            if (_dataBase == null)
            {
                _dataBase = new DataBase();
            }

            return _dataBase;
        }

        public void SomeBusinessLogic()
        {
            Console.WriteLine("Some logic");
        }
    }
}