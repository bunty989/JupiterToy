using JupiterCloud.Framework.Drivers;
using JupiterCloud.JupiterToys.PageObject;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace JupiterCloud.JupiterToys.Steps
{
    [Binding]
    public class ShoppingTestSteps
    {
        private readonly HomePage _homePage;
        private readonly ShopPage _shopPage;
        private readonly ShoppingCartPage _shoppingCartPage;
        private string[]? _items;
        private string[]? _itemsBought;
        private int[]? _countOfEachItem;

        public ShoppingTestSteps(ScenarioContext scenarioContext, DriverHelper driverHelper)
        {
            var driver = driverHelper.Driver;
            _homePage = new HomePage(driver);
            _shopPage = new ShopPage(driver);
            _shoppingCartPage = new ShoppingCartPage(driver);
        }

        [Given(@"navigates to the Shops Page")]
        public void GivenNavigatesToTheShopsPage() => _homePage.ClickShopButton();

        [When(@"the user buys item\(s\) '(.*)'")]
        public void WhenTheUserBuysItemS(string itemsBought)
        {
            _items = itemsBought.Split(",");
            _countOfEachItem = new int[_items.Length];
            _itemsBought = new string[_items.Length];
            for (var index = 0; index < _items.Length; index++)
            {
                var item = _items[index];
                var countOfItem = int.Parse(item.Trim().Split("-")[0]);
                _countOfEachItem[index] = countOfItem;
                _itemsBought[index] = item.Trim().Split("-")[1];
                for (var i = 0; i < countOfItem; i++)
                {
                    _shopPage.BuyItem(item.Trim().Split("-")[1]);
                }
            }
        }

        [When(@"goes to the shopping cart")]
        public void WhenGoesToTheShoppingCart() => _homePage.ClickCartButton();

        [Then(@"see the total number of item as '(.*)'")]
        public void ThenSeeTheTotalNumberOfItemAs(int itemCount) =>
            Assert.That(_shoppingCartPage.GetNumberOfItemsOnCart(), Is.EqualTo(itemCount));

        [Then(@"verify the count of '(.*)' as '(.*)'")]
        public void ThenVerifyTheCountOfAs(string itemName, int itemCount)
        {
            var item = GetItemNumber(itemName);
            Assert.That(_shoppingCartPage.GetQuantityOfItem(item), Is.EqualTo(itemCount));
        }

        [Then(@"the user verifies the subtotal of '(.*)' as '(.*)'")]
        public void ThenTheUserVerifiesTheSubtotalOf(string itemName, string subtotal)
        {
            var item = GetItemNumber(itemName);
            Assert.That(_shoppingCartPage.GetSubTotals(item), Is.EqualTo(subtotal));
        }

        [Then(@"the user verifies the price of '(.*)' as '(.*)'")]
        public void ThenTheUserVerifiesThePriceOfAs(string itemName, string price)
        {
            var item = GetItemNumber(itemName);
            Assert.That(_shoppingCartPage.GetIndividualPrice(item), Is.EqualTo(price));
        }

        [Then(@"the user verifies the sumtotal of all items is calculated correctly")]
        public void ThenTheUserVerifiesTheSumtotalOfAllItemsIsCalculatedCorrectly()
        {
            Assert.That(_shoppingCartPage.GetSubTotalAll() == _shoppingCartPage.GetTotal());
        }

        [Then(@"the value of total displayed is '(.*)'")]
        public void ThenTheValueOfTotalDisplayedIs(string totalValue)
        {
            Assert.That(_shoppingCartPage.GetTotal(), Is.EqualTo(totalValue));
        }

        private static int GetItemNumber(string itemName)
        {
            var item = itemName.ToLowerInvariant() switch
            {
                "teddy bear" => 4,
                "stuffed frog" => 1,
                "handmade doll" => 5,
                "fluffy bunny" => 2,
                "smiley bear" => 6,
                "funny cow" => 7,
                "valentine bear" => 3,
                "smiley face" => 8,
                _ => 0
            };
            return item;
        }
    }
}
