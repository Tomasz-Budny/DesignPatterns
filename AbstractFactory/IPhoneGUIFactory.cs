using System;

namespace AbstractFactory
{
    public class IPhoneButton : IButton
    {
        public void Click()
        {
            Console.WriteLine("iphone btn was pressed");
        }
    }

    public class IPhoneCheckBox : ICheckBox
    {
        public void Check()
        {
            Console.WriteLine("iphone checkbox was checked");
        }
    }
    
    public class IPhoneGUIFactory : IGUIFactory
    {
        public IButton CreateButton()
        {
            return new IPhoneButton();
        }

        public ICheckBox CreateCheckBox()
        {
            return new IPhoneCheckBox();
        }
    }
}