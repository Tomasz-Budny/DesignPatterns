using System;

namespace Adapter
{
    public class ConcreteGraphicLibrary
    {
        public void DrawCar()
        {
            // niekompatybilna metoda z resztą naszego programu
        }

        public void DrawRabbit()
        {
            // niekompatybilna z resztą naszego programu
        }
    }
    
    public class SampleGraphicLibrary
    {
        public void DrawLine(int x, int y, int xz, int yz)
        {
            Console.WriteLine($"Drawing line with parameters: {x} {y}");
        }

        public void DrawCircle(int x, int y, int r)
        {
            Console.WriteLine($"Drawing circle at center in {x}, {y} with radius: {r}");
        }

        public void DrawRectangle(int x, int y, int w, int h)
        {
            Console.WriteLine($"Drawing rectangle with parameters: {x}, {y}, {w}, {h}");
        }
    }

    public class SampleGraphicAdapter : ConcreteGraphicLibrary
    {
        private readonly SampleGraphicLibrary _sampleGraphicLibrary;

        public SampleGraphicAdapter(SampleGraphicLibrary sampleGraphicLibrary)
        {
            _sampleGraphicLibrary = sampleGraphicLibrary;
        }

        public new void DrawCar()
        {
            Console.WriteLine("Drawing car");
            _sampleGraphicLibrary.DrawRectangle(1, 1, 1, 1);
            _sampleGraphicLibrary.DrawCircle(1, 1, 1);
            _sampleGraphicLibrary.DrawCircle(1, 1, 1);
        }

        public new void DrawRabbit()
        {
            Console.WriteLine("Drawing rabbit");
            _sampleGraphicLibrary.DrawCircle(1, 1, 1);
            _sampleGraphicLibrary.DrawCircle(1, 1, 1);
            // reszta metod potrzebnych do stworzenia królika
        }
        
    }
    
}