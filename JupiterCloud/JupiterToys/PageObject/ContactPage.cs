using OpenQA.Selenium;
using JupiterCloud.Framework.Wrapper;
using LocatorType = JupiterCloud.Framework.Wrapper.TestConstant.LocatorType;
using WebDriverAction = JupiterCloud.Framework.Wrapper.TestConstant.WebDriverAction;

namespace JupiterCloud.JupiterToys.PageObject
{
    internal class ContactPage
    {
        private readonly WebHelper _webHelper;

        protected IWebElement? LabelFeedback =>
            _webHelper.InitialiseDynamicWebElement(LocatorType.CssSelector,
                "#header-message div");
        protected IWebElement? TxtBoxForeName =>
            _webHelper.InitialiseDynamicWebElement(LocatorType.CssSelector,
                "#forename");
        protected IWebElement? LabelForeNameError =>
            _webHelper.FindWebElementFromDomUsingCssSelector("#forename-err");
        protected IWebElement? TxtBoxSurname =>
            _webHelper.InitialiseDynamicWebElement(LocatorType.CssSelector,
                "#surname");
        protected IWebElement? TxtBoxEmail =>
            _webHelper.InitialiseDynamicWebElement(LocatorType.CssSelector,
                "#email");
        protected IWebElement? LabelEmailError =>
            _webHelper.FindWebElementFromDomUsingCssSelector("#email-err");
        protected IWebElement? TxtBoxTelephone =>
            _webHelper.InitialiseDynamicWebElement(LocatorType.CssSelector,
                "#telephone");
        protected IWebElement? TxtBoxMessage =>
            _webHelper.InitialiseDynamicWebElement(LocatorType.CssSelector,
                "#message");
        protected IWebElement? LabelMessageError =>
            _webHelper.FindWebElementFromDomUsingCssSelector("#message-err");
        protected IWebElement? BtnSubmit =>
            _webHelper.InitialiseDynamicWebElement(LocatorType.CssSelector,
                "[class$='btn-primary']");
        protected IWebElement? AlertFormSubmission =>
            _webHelper.InitialiseDynamicWebElement(LocatorType.CssSelector,
                ".modal-header h1");
        protected IWebElement? LabelFeedbackSubmissionSuccess =>
            _webHelper.InitialiseDynamicWebElement(LocatorType.CssSelector,
                "[class*='alert-success']");

        public ContactPage(IWebDriver? driver) => _webHelper = new WebHelper(driver);

        public void EnterForeName(string? foreName) =>
            _webHelper.PerformWebDriverAction(TxtBoxForeName, WebDriverAction.Input, foreName);

        public void EnterSurName(string surName) =>
            _webHelper.PerformWebDriverAction(TxtBoxSurname, WebDriverAction.Input, surName);

        public void EnterEmail(string eMail) =>
            _webHelper.PerformWebDriverAction(TxtBoxEmail, WebDriverAction.Input, eMail);

        public void EnterTelephone(string telePhone) =>
            _webHelper.PerformWebDriverAction(TxtBoxTelephone, WebDriverAction.Input, telePhone);

        public void EnterMessage(string? message) =>
            _webHelper.PerformWebDriverAction(TxtBoxMessage, WebDriverAction.Input, message);

        public void ClickSubmitButton()
        {
            _webHelper.PerformWebDriverAction(BtnSubmit, WebDriverAction.DoubleClick);
        }

        public void GenerateMandatoryFieldsError()
        {
            _webHelper.ReturnCssAttribute(LabelFeedback, "color");
            _webHelper.PerformWebDriverAction(BtnSubmit, WebDriverAction.Click);
            bool error;
            do
            {
                _webHelper.PerformWebDriverAction(TxtBoxForeName,WebDriverAction.Click);
                _webHelper.PerformWebDriverAction(TxtBoxEmail,WebDriverAction.Click);
                _webHelper.PerformWebDriverAction(BtnSubmit, WebDriverAction.Click);
                error = _webHelper.ReturnCssAttribute(LabelFeedback, "color")!.Equals("rgba(185, 74, 72, 1)");
            } while (!error);
        }

        public string? GetForeNameError() => _webHelper.ReturnVisibleText(LabelForeNameError);

        public string? GetEmailError() => _webHelper.ReturnVisibleText(LabelEmailError);

        public string? GetMessageError() => _webHelper.ReturnVisibleText(LabelMessageError);

        public bool? FeedbackSubmissionProgress() => _webHelper.ReturnVisibleText(AlertFormSubmission)?.Equals("Sending Feedback");

        public string? FeedbackSubmissionSuccessMessage() =>
            _webHelper.ReturnVisibleText(LabelFeedbackSubmissionSuccess);
    }
}
