using System;

namespace ChainOfResponsibility
{
    class Program
    {
        static void Main(string[] args)
        {
            PasswordIsLongerThan handler1 = new PasswordIsLongerThan(9);
            PasswordHaveUpperAndLowerCase handler2 = new PasswordHaveUpperAndLowerCase();
            PasswordContainsNumbers handler3 = new PasswordContainsNumbers();
            PasswordContainsSpecialCharacter handler4 = new PasswordContainsSpecialCharacter();

            handler1.NextHandler = handler2;
            handler2.NextHandler = handler3;
            handler3.NextHandler = handler4;

            var password = "HasłoHasło+";
            var result = handler1.IsValid(password);
            Console.WriteLine(result);
        }
    }
}