using System;

namespace Adapter
{
    class Program
    {
        static void Main(string[] args)
        {
            SampleGraphicAdapter sga = new SampleGraphicAdapter(new SampleGraphicLibrary());
            sga.DrawCar();
        }
    }
}