namespace StoreSeleniumProject.PageObject;

public class SignUpPage
{
    private IWebDriver _driver;
    private WebDriverWait _wait;

    public SignUpPage(IWebDriver driver)
    {
        _driver = driver;
        _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
    }

    public IWebElement SignUpLink => _driver.FindElement(By.Id("signin2"));
    public IWebElement TxtUsername => SignUpPopUp.FindElement(By.Id("sign-username"));
    public IWebElement TxtPassword => SignUpPopUp.FindElement(By.Id("sign-password"));
    public IWebElement SignUpBtn => SignUpPopUp.FindElement(By.ClassName("btn-primary"));
    public IWebElement CloseBtn => SignUpPopUp.FindElement(By.ClassName("btn-secondary"));
    public IWebElement SignUpPopUp => _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("signInModal")));

    public void NavigateToSignUp()
    {
        SignUpLink.Click();
    }

    public void SignUp()
    {
        var username_ending = DateTime.Now.Ticks;

        var username = "JT" + username_ending;
        var password = "Password96@";

        TxtUsername.SendKeys(username);
        TxtPassword.SendKeys(password);
        SignUpBtn.Click();
    }

    public void SignUp(string username, string password)
    {
        TxtUsername.SendKeys(username);
        TxtPassword.SendKeys(password);
        SignUpBtn.Click();
    }

    public void CloseSignUpPopUp()
    { 
        CloseBtn.Click();
    }
}
