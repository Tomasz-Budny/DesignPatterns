using System;

namespace Decorator
{
    class Program
    {
        static void Main(string[] args)
        {
            LettersCounter lc = new LettersCounter();
            string text = "AA aa bb cc";
            string letters = lc.CountLetters(text);
            Console.WriteLine(letters);

            LettersNewLine dec1 = new LettersNewLine(lc);
            string lisiTom = dec1.CountLetters("text");
            Console.WriteLine(lisiTom);
        }
    }
}