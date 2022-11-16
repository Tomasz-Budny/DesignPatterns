using System.Collections.Generic;
using System.Linq;
using System.Threading.Channels;

namespace Decorator
{
    public abstract class LettersOperationComponent
    {
        public abstract string CountLetters(string text);
        
        protected Dictionary<char, int> InitializeAlphabet()
        {
            Dictionary<char, int> dictionary = new Dictionary<char, int>();
            for (char c = 'A'; c <= 'Z'; c++)
            {
                dictionary.Add(c, 0);
                dictionary.Add(char.ToLower(c), 0);
            }

            return dictionary;
        }
    }
    
    public class LettersCounter : LettersOperationComponent
    {
        public override string CountLetters(string text)
        {
            Dictionary<char, int> lettersOccurence = InitializeAlphabet();
            foreach (char c in text)
            {
                try
                {
                    lettersOccurence[c]++;
                }
                catch (KeyNotFoundException)
                {
                    
                }
            }

            return GetNumberOfLetters(lettersOccurence);
        }

        private string GetNumberOfLetters(Dictionary<char, int> dict)
        {
            string final = "";
            foreach (var el in dict)
            {
                if (el.Value != 0)
                {
                    final += $" {el.Key}: {el.Value},";
                }
            }

            return final.Trim().TrimEnd(',');
        }
    }

    public abstract class LettersOperationDecorator : LettersOperationComponent
    {
        protected LettersOperationComponent LettersOperationComponent;

        protected LettersOperationDecorator(LettersOperationComponent component)
        {
            LettersOperationComponent = component;
        }

        public override string CountLetters(string text)
        {
            if (LettersOperationComponent is null)
            {
                return "";
            }

            return LettersOperationComponent.CountLetters(text);
        }
    }

    public class LettersNewLine : LettersOperationDecorator
    {
        public LettersNewLine(LettersOperationComponent component) : base(component)
        {
        }

        public override string CountLetters(string text)
        {
            
            return GetSummaryInSpecificFormat(base.CountLetters(text));
        }

        private string GetSummaryInSpecificFormat(string text)
        {
            return text.Replace(", ", ",\n");
        }
    }
    
    public class LettersOperationWriter : LettersOperationDecorator{
        public LettersOperationWriter(LettersOperationComponent component) : base(component)
        {
        }

        public override string CountLetters(string text)
        {
            // save to file and return string
            return base.CountLetters(text);
        }
        
        
    }
}