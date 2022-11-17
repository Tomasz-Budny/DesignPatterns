using System;
using System.Linq;

namespace ChainOfResponsibility
{
    public interface IPasswordCheckerHandler
    {
        bool IsValid(string password);
    }
    
    public abstract class PasswordCheckerHandler : IPasswordCheckerHandler
    {
        public IPasswordCheckerHandler NextHandler { get; set; }

        public abstract bool IsValid(string password);

        protected void ErrorMessage(string message)
        {
            Console.WriteLine($"Password is invalid: {message}");
        }
    }

    public class PasswordIsLongerThan : PasswordCheckerHandler
    {
        private int minLength;
        
        public PasswordIsLongerThan(int minLength)
        {
            this.minLength = minLength;
        }
        
        public override bool IsValid(string password)
        {
            if (password.Length >= minLength)
            {
                if (NextHandler != null)
                    return NextHandler.IsValid(password);
                return true;
            }

            ErrorMessage($"Password is shorter than {minLength}");
            return false;
        }
    }

    public class PasswordHaveUpperAndLowerCase : PasswordCheckerHandler
    {
        public override bool IsValid(string password)
        {
            if (password.ToUpper() != password)
            {
                if (NextHandler != null)
                    return NextHandler.IsValid(password);
                return true;
            }

            ErrorMessage("Password doesnt contains upper and lower cases");
            return false;
        }
    }

    public class PasswordContainsNumbers : PasswordCheckerHandler
    {
        public override bool IsValid(string password)
        {
            if (IsContainsNumbers(password))
            {
                if (NextHandler != null)
                    return NextHandler.IsValid(password);
                return true;
            }

            ErrorMessage($"Password doesnt contains any number!");
            return false;
        }

        private bool IsContainsNumbers(string password)
        {
            foreach (var c in password)
            {
                if (c >= '0' && c <= '9')
                    return true;
            }

            return false;
        }
    }
    
    public class PasswordContainsSpecialCharacter : PasswordCheckerHandler
    {
        public override bool IsValid(string password)
        {
            if (password.Any(c => char.IsSymbol(c) || char.IsControl(c)))
            {
                if (NextHandler != null)
                    return NextHandler.IsValid(password);
                return true;
            }

            ErrorMessage($"Password doesnt contains any special characters");
            return false;
        }
    }
}