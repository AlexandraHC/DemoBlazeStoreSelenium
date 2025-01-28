namespace StoreSeleniumProject.PageObject
{
    public class AboutUsPage
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;

        public AboutUsPage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10)); ;
        }

        public IWebElement AboutUsLink => _driver.FindElement(By.CssSelector("#navbarExample > ul > li:nth-child(3) > a"));
        public IWebElement AboutUsPopup => _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("videoModal")));
        public IWebElement PlayVideoBtn => AboutUsPopup.FindElement(By.ClassName("vjs-big-play-button"));
        public IWebElement CloseBtn => AboutUsPopup.FindElement(By.ClassName("btn-secondary"));
        public IWebElement PauseVideoBtn => AboutUsPopup.FindElement(By.ClassName("vjs-playing"));

        public void NavigateToAboutUsLink()
        {
            AboutUsLink.Click();
        }

        public void PlayVideoButton()
        {
            PlayVideoBtn.Click();
        }

        public bool IsVideoStarted()
        {
            return PauseVideoBtn.Displayed;
        }

        public void CloseTheAboutUsPopup()
        {
            CloseBtn.Click();
        }
    }
}
