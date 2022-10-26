namespace AbstractFactory
{
    public interface IButton
    {
        void Click();
    }

    public interface ICheckBox
    {
        void Check();
    }
    
    public interface IGUIFactory
    {
        IButton CreateButton();
        ICheckBox CreateCheckBox();
    }
}