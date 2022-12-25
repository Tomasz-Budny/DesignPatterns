using System;

namespace Memento
{

    public class NotepadManager
    {
        private readonly NotepadCaretaker _caretaker = new NotepadCaretaker(new Notepad());
        
        public void Run()
        {
            var isRunning = true;
            while (isRunning)
            {
                var btnPressed = Console.ReadLine();
                switch (btnPressed)
                {
                    case "s":
                        _caretaker.Save();
                        break;
                    case "u":
                        _caretaker.Undo();
                        break;
                    case "a":
                        _caretaker.Show();
                        break;
                    case "e":
                        isRunning = false;
                        break;
                }
            }
        }

        public void DisplayInstruction()
        {
            Console.WriteLine("s - insert one line to memery");
            Console.WriteLine("u - delete last line and display it");
            Console.WriteLine("a - display all saved lines");
            Console.WriteLine("e - exit program");
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            var program = new NotepadManager();
            program.DisplayInstruction();
            program.Run();
        }
    }
}