using OpenQA.Selenium;
using JupiterCloud.Framework.Wrapper;
using LocatorType = JupiterCloud.Framework.Wrapper.TestConstant.LocatorType;
using WebDriverAction = JupiterCloud.Framework.Wrapper.TestConstant.WebDriverAction;

namespace JupiterCloud.JupiterToys.PageObject
{
    internal class ShopPage
    {
        private readonly WebHelper _webHelper;

        protected IWebElement? BtnBuyTeddyBear =>
            _webHelper.InitialiseDynamicWebElement(LocatorType.CssSelector,
                "#product-1 a");
        protected IWebElement? BtnBuyStuffedFrog =>
            _webHelper.InitialiseDynamicWebElement(LocatorType.CssSelector,
                "#product-2 a");
        protected IWebElement? BtnBuyHandmadeDoll =>
            _webHelper.InitialiseDynamicWebElement(LocatorType.CssSelector,
                "#product-3 a");
        protected IWebElement? BtnBuyFluffyBunny =>
            _webHelper.InitialiseDynamicWebElement(LocatorType.CssSelector,
                "#product-4 a");
        protected IWebElement? BtnBuySmileyBear =>
            _webHelper.InitialiseDynamicWebElement(LocatorType.CssSelector,
                "#product-5 a");
        protected IWebElement? BtnBuyFunnyCow =>
            _webHelper.InitialiseDynamicWebElement(LocatorType.CssSelector,
                "#product-6 a");
        protected IWebElement? BtnBuyValentineBear =>
            _webHelper.InitialiseDynamicWebElement(LocatorType.CssSelector,
                "#product-7 a");
        protected IWebElement? BtnBuySmileyFace =>
            _webHelper.InitialiseDynamicWebElement(LocatorType.CssSelector,
                "#product-8 a");
        protected IWebElement? LabelPriceTeddyBear =>
            _webHelper.InitialiseDynamicWebElement(LocatorType.CssSelector,
                "#product-1 span");
        protected IWebElement? LabelPriceStuffedFrog =>
            _webHelper.InitialiseDynamicWebElement(LocatorType.CssSelector,
                "#product-2 span");
        protected IWebElement? LabelPriceHandmadeDoll =>
            _webHelper.InitialiseDynamicWebElement(LocatorType.CssSelector,
                "#product-3 span");
        protected IWebElement? LabelPriceFluffyBunny =>
            _webHelper.InitialiseDynamicWebElement(LocatorType.CssSelector,
                "#product-4 span");
        protected IWebElement? LabelPriceSmileyBear =>
            _webHelper.InitialiseDynamicWebElement(LocatorType.CssSelector,
                "#product-5 span");
        protected IWebElement? LabelPriceFunnyCow =>
            _webHelper.InitialiseDynamicWebElement(LocatorType.CssSelector,
                "#product-6 span");
        protected IWebElement? LabelPriceValentineBear =>
            _webHelper.InitialiseDynamicWebElement(LocatorType.CssSelector,
                "#product-7 span");
        protected IWebElement? LabelPriceSmileyFace =>
            _webHelper.InitialiseDynamicWebElement(LocatorType.CssSelector,
                "#product-8 span");

        public ShopPage(IWebDriver? driver) => _webHelper = new WebHelper(driver);

        public string? GetPriceOfItem(string itemName)
        {
            return itemName.ToLowerInvariant() switch
            {
                "teddy bear" => GetPrice(LabelPriceTeddyBear),
                "stuffed frog" => GetPrice(LabelPriceStuffedFrog),
                "handmade doll" => GetPrice(LabelPriceHandmadeDoll),
                "fluffy bunny" => GetPrice(LabelPriceFluffyBunny),
                "smiley bear" => GetPrice(LabelPriceSmileyBear),
                "funny cow" => GetPrice(LabelPriceFunnyCow),
                "valentine bear" => GetPrice(LabelPriceValentineBear),
                "smiley face" => GetPrice(LabelPriceSmileyFace),
                _=> null
            };
        }

        public void BuyItem(string itemName)
        {
            var itemWebElement = itemName.ToLowerInvariant() switch
            {
                "teddy bear" => BtnBuyTeddyBear,
                "stuffed frog" => BtnBuyStuffedFrog,
                "handmade doll" => BtnBuyHandmadeDoll,
                "fluffy bunny" => BtnBuyFluffyBunny,
                "smiley bear" => BtnBuySmileyBear,
                "funny cow" => BtnBuyFunnyCow,
                "valentine bear" => BtnBuyValentineBear,
                "smiley face" => BtnBuySmileyFace,
                _ => null
            };
            BuyItem(itemWebElement);
        }


        private string? GetPrice(IWebElement item) => _webHelper.ReturnVisibleText(item);

        private void BuyItem(IWebElement item) => _webHelper.PerformWebDriverAction(item, WebDriverAction.Click);
    }
}
