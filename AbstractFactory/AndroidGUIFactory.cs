using System;

namespace AbstractFactory
{
    public class AndroidButton : IButton
    {
        public void Click()
        {
            Console.WriteLine("android btn was pressed");
        }
    }

    public class AndroidCheckBox : ICheckBox
    {
        public void Check()
        {
            Console.WriteLine("android checkbox was checked");
        }
    }
    
    public class AndroidGUIFactory : IGUIFactory
    {
        public IButton CreateButton()
        {
            return new AndroidButton();
        }

        public ICheckBox CreateCheckBox()
        {
            return new AndroidCheckBox();
        }
    }
}