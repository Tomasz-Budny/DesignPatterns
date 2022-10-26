namespace AbstractFactory
{
    public  static class Client
    {
        public static void CreateUI(IGUIFactory factory)
        {
            var btn = factory.CreateButton();
            var checkBox = factory.CreateCheckBox();
            
            btn.Click();
            checkBox.Check();
        }
    }
}