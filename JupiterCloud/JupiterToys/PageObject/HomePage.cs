using OpenQA.Selenium;
using JupiterCloud.Framework.Wrapper;
using LocatorType = JupiterCloud.Framework.Wrapper.TestConstant.LocatorType;
using WebDriverAction = JupiterCloud.Framework.Wrapper.TestConstant.WebDriverAction;

namespace JupiterCloud.JupiterToys.PageObject
{
    internal class HomePage
    {
        private readonly WebHelper _webHelper;

        protected IWebElement? BtnHome =>
            _webHelper.InitialiseDynamicWebElement(LocatorType.CssSelector,
                "#nav-home a");
        protected IWebElement? BtnShop =>
            _webHelper.InitialiseDynamicWebElement(LocatorType.CssSelector,
                "#nav-shop a");
        protected IWebElement? BtnContact =>
            _webHelper.InitialiseDynamicWebElement(LocatorType.CssSelector,
                "#nav-contact a");
        protected IWebElement? BtnLogin =>
            _webHelper.InitialiseDynamicWebElement(LocatorType.CssSelector,
                "#nav-login a");
        protected IWebElement? BtnCart =>
            _webHelper.InitialiseDynamicWebElement(LocatorType.CssSelector,
                "#nav-cart a");
        protected IWebElement? BtnStartShopping =>
            _webHelper.InitialiseDynamicWebElement(LocatorType.CssSelector,
                "#btn btn-success btn-large");
        protected IWebElement? LabelTitle =>
            _webHelper.InitialiseDynamicWebElement(LocatorType.CssSelector,
                ".hero-unit h1");

        public HomePage(IWebDriver? driver) => _webHelper = new WebHelper(driver);

        public bool? IsHomePageDisplayed => _webHelper.ReturnVisibleText(LabelTitle)?.Equals("Jupiter Toys");

        public void ClickHomeButton() => _webHelper.PerformWebDriverAction(BtnHome,WebDriverAction.Click);

        public void ClickShopButton() => _webHelper.PerformWebDriverAction(BtnShop, WebDriverAction.Click);

        public void ClickContactButton() => _webHelper.PerformWebDriverAction(BtnContact, WebDriverAction.Click);
        
        public void ClickLoginButton() => _webHelper.PerformWebDriverAction(BtnLogin, WebDriverAction.Click);

        public void ClickCartButton() => _webHelper.PerformWebDriverAction(BtnCart, WebDriverAction.Click);

        public void ClickStartShoppingButton() => _webHelper.PerformWebDriverAction(BtnStartShopping, WebDriverAction.Click);

        public string? GetCartItems() => _webHelper.ReturnVisibleText(BtnCart);
    }
}
