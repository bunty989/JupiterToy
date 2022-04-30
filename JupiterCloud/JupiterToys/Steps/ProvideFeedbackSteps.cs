using NUnit.Framework;
using TechTalk.SpecFlow;
using JupiterCloud.Framework.Drivers;
using JupiterCloud.Framework.Wrapper;
using JupiterCloud.JupiterToys.PageObject;
using JupiterCloud.JupiterToys.Setup;
using ConfigType = JupiterCloud.Framework.Wrapper.TestConstant.ConfigTypes;
using ConfigKey = JupiterCloud.Framework.Wrapper.TestConstant.ConfigTypesKey;

namespace JupiterCloud.JupiterToys.Steps
{
    [Binding]
    public class ProvideFeedbackSteps
    {
        private readonly HomePage _homePage;
        private readonly ContactPage _contactPage;
        private readonly DriverHelper _driverHelper;
        private readonly CommonMethods _commonMethods;
        private static string Protocol => ConfigHelper.ReadConfigValue(ConfigType.WebDriverConfig, ConfigKey.Protocol);
        private static string Url => SetAppUrl.SetUrl(Protocol);
        private static string? _foreName;

        public ProvideFeedbackSteps(ScenarioContext scenarioContext, DriverHelper driverHelper)
        {
            _driverHelper = driverHelper;
            var driver = driverHelper.Driver;
            _commonMethods = new CommonMethods();
            _homePage = new HomePage(driver);
            _contactPage = new ContactPage(driver);
        }

        [Given(@"the user open the Jupiter Toys App")]
        public void GivenTheUserOpenTheJupiterToysApp() => _driverHelper.Navigate(Url);

        [Given(@"navigates to the Contacts Page")]
        public void GivenNavigatesToTheContactsPage() => _homePage.ClickContactButton();

        [Given(@"the mandatory field validation errors are present")]
        public void GivenTheMandatoryFieldValidationErrorsArePresent() => 
            _contactPage.GenerateMandatoryFieldsError();

        [When(@"the user clicks on Submit button")]
        public void WhenTheUserClicksOnSubmitButton() => 
            _contactPage.GenerateMandatoryFieldsError();

        [When(@"the user enters any value for the mandatory fields")]
        public void WhenTheUserEntersAnyValueForTheMandatoryFields()
        {
            _foreName = _commonMethods.GenerateRandomString(5);
            _contactPage.EnterForeName(_foreName);
            _contactPage.EnterEmail(_commonMethods.GenerateRandomString(10)+"@gmail.com");
            _contactPage.EnterMessage(_commonMethods.GenerateRandomString(20));
        }

        [When(@"clicks on Submit button")]
        public void WhenClicksOnSubmitButton() => _contactPage.ClickSubmitButton();

        [Then(@"the user should see the error message for ForeName")]
        public void ThenTheUserShouldSeeTheErrorMessageForForeName()
        {
            Assert.True(!string.IsNullOrEmpty(_contactPage.GetForeNameError()));
        }

        [Then(@"the user should see the error message for Email")]
        public void ThenTheUserShouldSeeTheErrorMessageForEmail() => 
            Assert.True(!string.IsNullOrEmpty(_contactPage.GetEmailError()));

        [Then(@"the user should see the error message for Message")]
        public void ThenTheUserShouldSeeTheErrorMessageForMessage() => 
            Assert.True(!string.IsNullOrEmpty(_contactPage.GetMessageError()));

        [Then(@"the user should not see the error message for ForeName")]
        public void ThenTheUserShouldNotSeeTheErrorMessageForForeName() => 
            Assert.True(string.IsNullOrEmpty(_contactPage.GetForeNameError()));

        [Then(@"the user should not see the error message for Email")]
        public void ThenTheUserShouldNotSeeTheErrorMessageForEmail() => 
            Assert.True(string.IsNullOrEmpty(_contactPage.GetEmailError()));

        [Then(@"the user should not see the error message for Message")]
        public void ThenTheUserShouldNotSeeTheErrorMessageForMessage() => 
            Assert.True(string.IsNullOrEmpty(_contactPage.GetMessageError()));

        [Then(@"the user should see the feedback submission in progress")]
        public void ThenTheUserShouldSeeTheFeedbackSubmissionInProgress() => 
            Assert.True(_contactPage.FeedbackSubmissionProgress());

        [Then(@"the feedback should be successfully submitted")]
        public void ThenTheFeedbackShouldBeSuccessfullySubmitted() =>
            Assert.AreEqual("Thanks "+_foreName+", we appreciate your feedback.", 
                _contactPage.FeedbackSubmissionSuccessMessage());
    }
}
