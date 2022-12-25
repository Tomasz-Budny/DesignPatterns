using System;
using System.Collections.Generic;

namespace Memento
{
    public class Memento
    {
        public string TextLine { get; }

        public Memento(string textLine)
        {
            TextLine = textLine;
        }
    }
    
    public class Notepad
    {
        public string TextLine { get; set; }
        
        public Memento Save()
        {
            var textLine = Console.ReadLine();
            TextLine = textLine;
            return new Memento(textLine);
        }
    }

    public class NotepadCaretaker
    {
        private readonly Notepad _notepad;
        private readonly List<Memento> _history = new List<Memento>();
        
        public NotepadCaretaker(Notepad notepad)
        {
            _notepad = notepad;
        }

        public void Save()
        {
            Console.Write("Your Text goes here: ");
            var memento = _notepad.Save(); 
            _history.Add(memento); 
        }

        public void Undo()
        {
            if (_history.Count > 0)
            {
                var lastLine = _history[^1].TextLine;
                _history.RemoveAt(_history.Count - 1);
                _notepad.TextLine = lastLine;
                Console.Write("Your last line is: ");
                Console.WriteLine(lastLine);
            }
        }

        public void Show()
        {
            Console.WriteLine("Your all saved lines: ");
            foreach (var memento in _history)
            {
                Console.WriteLine(memento.TextLine);
            }
        }
    }
}