namespace StoreSeleniumProject.Utils.Common
{
    public static class AlertHandler
    {
        public static (bool, string) HandleAlert(IWebDriver driver)
        {
            bool isAlertVisible = false;

            try
            {
                // Wait for the alert to appear
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.AlertIsPresent());

                // Switch to the alert
                IAlert alert = driver.SwitchTo().Alert();

                isAlertVisible = alert != null;
                string alertText = alert.Text;

                // Accept the alert (click OK button)
                alert.Accept();

                return (isAlertVisible, alertText);
            }
            catch (NoAlertPresentException)
            {
                Console.WriteLine("No alert found.");
                return (false, string.Empty);
            }
        }
    }
}
