namespace StoreSeleniumProject.PageObject
{
    public class LoginPage
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;

        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        }

        public IWebElement TxtUserName => LoginPopUp.FindElement(By.Id("loginusername"));
        public IWebElement TxtPassword => LoginPopUp.FindElement(By.Id("loginpassword"));
        public IWebElement LoginLink => _driver.FindElement(By.Id("login2"));
        public IWebElement LoginBtn => LoginPopUp.FindElement(By.ClassName("btn-primary"));
        public IWebElement LoginPopUp => _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("logInModal")));
        public IWebElement NameOfUserLabel => _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("nameofuser")));
        public IWebElement LogoutLink => _driver.FindElement(By.Id("logout2"));

        public void NavigateToLogin()
        {
            LoginLink.Click();
        }

        public void Login(string username, string password)
        {
            TxtUserName.SendKeys(username);
            TxtPassword.SendKeys(password);
            LoginBtn.Click();
        }

        public bool IsLoggedIn(string username)
        {
            return NameOfUserLabel.Displayed && NameOfUserLabel.Text == "Welcome " + username;
        }

        public bool IsNotLoggedIn()
        {
            return LoginBtn.Displayed;
        }

        public bool IsDisplayedLoginLink()
        {
            return LoginLink.Displayed;
        }
    }
}
