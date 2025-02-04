namespace StoreSeleniumProject.PageObject;
public class CheckoutPage
{
    private IWebDriver _driver;
    private WebDriverWait _wait;

    public CheckoutPage(IWebDriver driver)
    {
        _driver = driver;
        _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
    }

    public IWebElement CheckoutBtn => _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("[data-target='#orderModal']")));
    public IWebElement CheckoutForm => _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("orderModal")));
    public IWebElement TxtName => CheckoutForm.FindElement(By.Id("name"));
    public IWebElement TxtCountry => CheckoutForm.FindElement(By.Id("country"));
    public IWebElement TxtCity => CheckoutForm.FindElement(By.Id("city"));
    public IWebElement TxtCreditCard => CheckoutForm.FindElement(By.Id("card"));
    public IWebElement TxtMonth => CheckoutForm.FindElement(By.Id("month"));
    public IWebElement TxtYear => CheckoutForm.FindElement(By.Id("year"));
    public IWebElement PurchaseBtn => CheckoutForm.FindElement(By.ClassName("btn-primary"));
    public IWebElement CompletedPurchasePopup
    {
        get
        {
            try
            {
                return _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.ClassName("showSweetAlert")));
            }
            catch (Exception ex) when (ex is NoSuchElementException || ex is WebDriverTimeoutException)
            {
                return null;
            }
        }
    }

    public void ClickOnCheckoutButton()
    {
        CheckoutBtn.Click();
    }

    public void FillInCheckoutForm(string name, string country, string city, string creditCard, string month, string year)
    {
        TxtName.SendKeys(name);
        TxtCountry.SendKeys(country);
        TxtCity.SendKeys(city);
        TxtCreditCard.SendKeys(creditCard);
        TxtMonth.SendKeys(month);
        TxtYear.SendKeys(year); 
        PurchaseBtn.Click();
    }

    public void ClickOnPurchaseButton()
    {
        PurchaseBtn.Click();
    }

    public bool IsOrderPlaced() 
    {
        return CompletedPurchasePopup != null && CompletedPurchasePopup.Displayed;
    }
}
