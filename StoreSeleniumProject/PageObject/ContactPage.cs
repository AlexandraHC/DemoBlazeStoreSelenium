namespace StoreSeleniumProject.PageObject;

public class ContactPage
{
    private IWebDriver _driver;
    private WebDriverWait _wait;

    public ContactPage(IWebDriver driver)
    {
        _driver = driver;
        _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
    }

    public IWebElement ContactLink => _driver.FindElement(By.CssSelector("#navbarExample > ul > li:nth-child(2) > a"));
    public IWebElement ContactPopup
    {
        get
        {
            try
            {
                return _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("exampleModal")));
            }
            catch (Exception ex) when (ex is NoSuchElementException || ex is WebDriverTimeoutException)
            {
                return null;
            }
        }
    } 
    public IWebElement TxtContactEmail => ContactPopup.FindElement(By.Id("recipient-email"));
    public IWebElement TxtContactName => ContactPopup.FindElement(By.Id("recipient-name"));
    public IWebElement TxtMessage => ContactPopup.FindElement(By.Id("message-text"));
    public IWebElement CloseButton => ContactPopup.FindElement(By.ClassName("btn-secondary"));
    public IWebElement SendMessageBtn => ContactPopup.FindElement(By.ClassName("btn-primary"));

    public void NavigateToContactLink()
    {
        ContactLink.Click();
    }

    public void FillInContactForm(string email, string name, string message)
    {
        TxtContactEmail.SendKeys(email);
        TxtContactName.SendKeys(name);
        TxtMessage.SendKeys(message);
        SendMessageBtn.Click();
    }

    public void CloseContactsPopup()
    {
        CloseButton.Click();
    }

    public bool IsContactPopupVisible()
    {
        return ContactPopup != null && ContactPopup.Displayed;
    }
}
