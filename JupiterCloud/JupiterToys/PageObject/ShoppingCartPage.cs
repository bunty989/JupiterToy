using System.Collections.Generic;
using System.Globalization;
using OpenQA.Selenium;
using JupiterCloud.Framework.Wrapper;
using LocatorType = JupiterCloud.Framework.Wrapper.TestConstant.LocatorType;

namespace JupiterCloud.JupiterToys.PageObject
{
    internal class ShoppingCartPage
    {
        private readonly WebHelper _webHelper;

        protected IWebElement? BtnCheckOut =>
            _webHelper.InitialiseDynamicWebElement(LocatorType.CssSelector,
                "[class*='btn-checkout']");
        protected IWebElement? BtnEmptyCart =>
            _webHelper.InitialiseDynamicWebElement(LocatorType.CssSelector,
                "[class*='btn-danger']");
        protected List<IWebElement?> TableItemsBoughtRows =>
            _webHelper.InitialiseWebElementsCollection(LocatorType.CssSelector,
                "[class$='cart-items'] tr.cart-item.ng-scope");
        protected List<IWebElement?> QuantityOfEachItem =>
            _webHelper.InitialiseWebElementsCollection(LocatorType.CssSelector,
                "[class$='cart-items'] tr.cart-item.ng-scope input");
        protected IWebElement? TxtQuantityOfItem1 => QuantityOfEachItem[0];
        protected IWebElement? TxtQuantityOfItem2 => QuantityOfEachItem[1];
        protected IWebElement? TxtQuantityOfItem3 => QuantityOfEachItem[2];
        protected IWebElement? TxtQuantityOfItem4 => QuantityOfEachItem[3];
        protected IWebElement? TxtQuantityOfItem5 => QuantityOfEachItem[4];
        protected IWebElement? TxtQuantityOfItem6 => QuantityOfEachItem[5];
        protected IWebElement? TxtQuantityOfItem7 => QuantityOfEachItem[6];
        protected IWebElement? TxtQuantityOfItem8 => QuantityOfEachItem[7];
        protected List<IWebElement?> PriceOfEachItem =>
            _webHelper.InitialiseWebElementsCollection(LocatorType.CssSelector,
                "[class$='cart-items'] tr.cart-item.ng-scope td");
        protected IWebElement? LabelPriceItem1 => PriceOfEachItem[1];
        protected IWebElement? LabelPriceItem2 => PriceOfEachItem[6];
        protected IWebElement? LabelPriceItem3 => PriceOfEachItem[11];
        protected IWebElement? LabelPriceItem4 => PriceOfEachItem[16];
        protected IWebElement? LabelPriceItem5 => PriceOfEachItem[21];
        protected IWebElement? LabelPriceItem6 => PriceOfEachItem[26];
        protected IWebElement? LabelPriceItem7 => PriceOfEachItem[31];
        protected IWebElement? LabelPriceItem8 => PriceOfEachItem[36];
        protected IWebElement? LabelSubtotalPriceItem1 => PriceOfEachItem[3];
        protected IWebElement? LabelSubtotalPriceItem2 => PriceOfEachItem[8];
        protected IWebElement? LabelSubtotalPriceItem3 => PriceOfEachItem[13];
        protected IWebElement? LabelSubtotalPriceItem4 => PriceOfEachItem[18];
        protected IWebElement? LabelSubtotalPriceItem5 => PriceOfEachItem[23];
        protected IWebElement? LabelSubtotalPriceItem6 => PriceOfEachItem[28];
        protected IWebElement? LabelSubtotalPriceItem7 => PriceOfEachItem[33];
        protected IWebElement? LabelSubtotalPriceItem8 => PriceOfEachItem[38];
        protected IWebElement? LabelSumTotalPrice => _webHelper.InitialiseDynamicWebElement(LocatorType.CssSelector,
            "[class*='total']");

        public ShoppingCartPage(IWebDriver? driver) => _webHelper = new WebHelper(driver);

        public int GetNumberOfItemsOnCart() => TableItemsBoughtRows.Count;

        public string? GetIndividualPrice(int item)
        {
            var individualPrice = item switch
            {
                1 => GetText(LabelPriceItem1),
                2 => GetText(LabelPriceItem2),
                3 => GetText(LabelPriceItem3),
                4 => GetText(LabelPriceItem4),
                5 => GetText(LabelPriceItem5),
                6 => GetText(LabelPriceItem6),
                7 => GetText(LabelPriceItem7),
                8 => GetText(LabelPriceItem8),
                _ => "0"
            };
            return individualPrice;
        }

        public int GetQuantityOfItem(int item)
        {
            var quantityOfItem = item switch
            {
                1 => GetValue(TxtQuantityOfItem1),
                2 => GetValue(TxtQuantityOfItem2),
                3 => GetValue(TxtQuantityOfItem3),
                4 => GetValue(TxtQuantityOfItem4),
                5 => GetValue(TxtQuantityOfItem5),
                6 => GetValue(TxtQuantityOfItem6),
                7 => GetValue(TxtQuantityOfItem7),
                8 => GetValue(TxtQuantityOfItem8),
                _ => "0"
            };
            return int.Parse(quantityOfItem);
        }

        public string? GetSubTotals(int item)
        {
            var subTotals = item switch
            {
                1 => GetText(LabelSubtotalPriceItem1),
                2 => GetText(LabelSubtotalPriceItem2),
                3 => GetText(LabelSubtotalPriceItem3),
                4 => GetText(LabelSubtotalPriceItem4),
                5 => GetText(LabelSubtotalPriceItem5),
                6 => GetText(LabelSubtotalPriceItem6),
                7 => GetText(LabelSubtotalPriceItem7),
                8 => GetText(LabelSubtotalPriceItem8),
                _ => "0"
            };
            return subTotals;
        }

        public string? GetTotal() => GetText(LabelSumTotalPrice)?.Split(":")[1].Trim();

        public string GetSubTotalAll()
        {
            var sbTotal = 0.00;
            for (var i = 1; i <= 3; i++)
            {
                var sTotal = GetSubTotals(i);
                sbTotal = sbTotal + double.Parse(sTotal?.Trim().Substring(1, sTotal.Length-1));
            }

            return sbTotal.ToString(CultureInfo.InvariantCulture);
        }

        private string? GetText(IWebElement elementName) => _webHelper.ReturnVisibleText(elementName);

        private string? GetValue(IWebElement elementName) => _webHelper.ReturnWebAttribute(elementName,"value");
    }
}
