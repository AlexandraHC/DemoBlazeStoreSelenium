using StoreSeleniumProject.Driver;
using StoreSeleniumProject.PageObject;
using StoreSeleniumProject.Tests.Common;
using StoreSeleniumProject.Utils.Common;

namespace StoreSeleniumProject.Tests
{
    [TestFixture(DriverType.Firefox)]
    [TestFixture(DriverType.Chrome)]
    [TestFixture(DriverType.Edge)]
    public class LoginPageTest : TestBase
    {
        private string _userName;
        public LoginPageTest(DriverType driverType) : base(driverType)
        {

        }

        [SetUp]
        public new void Setup()
        {
            base.Setup();
            SignUpPage signUpPage = new SignUpPage(_driver);
            signUpPage.NavigateToSignUp();
            _userName = "JT" + DateTime.Now.Ticks;
            signUpPage.SignUp(_userName, "Password96@");
            (bool isAlertVisible, string alertText) = AlertHandler.HandleAlert(_driver);
        }

        [Test]
        public void LoginTestWithValidCredentials()
        {
            LoginPage login = new LoginPage(_driver);
            login.NavigateToLogin();
            login.Login(_userName, "Password96@");
            Assert.IsTrue(login.IsLoggedIn(_userName));
        }

        [Test]
        public void LoginTestWithoutUsername()
        {
            LoginPage login = new LoginPage(_driver);
            login.NavigateToLogin();
            login.Login("", "Password");
            (bool isAlertVisible, string alertText) = AlertHandler.HandleAlert(_driver);
            Assert.IsTrue(login.IsNotLoggedIn());
            Assert.AreEqual("Please fill out Username and Password.", alertText);
        }

        [Test]
        public void LoginTestWithoutPassword()
        {
            LoginPage login = new LoginPage(_driver);
            login.NavigateToLogin();
            login.Login("User", "");
            (bool isAlertVisible, string alertText) = AlertHandler.HandleAlert(_driver);
            Assert.IsTrue(login.IsNotLoggedIn());
            Assert.AreEqual("Please fill out Username and Password.", alertText);
        }

        [Test]
        public void LoginWithBothFieldsEmpty()
        {
            LoginPage login = new LoginPage(_driver);
            login.NavigateToLogin();
            login.Login("User", "");
            (bool isAlertVisible, string alertText) = AlertHandler.HandleAlert(_driver);
            Assert.IsTrue(login.IsNotLoggedIn());
            Assert.AreEqual("Please fill out Username and Password.", alertText);
        }

        [Test]
        public void LoginTestWithAnNonexistentUsername()
        {
            LoginPage login = new LoginPage(_driver);
            login.NavigateToLogin();
            login.Login(".", "`");
            (bool isAlertVisible, string alertText) = AlertHandler.HandleAlert(_driver);
            Assert.IsTrue(login.IsNotLoggedIn());
            Assert.AreEqual("Wrong password.", alertText);
        }

        [Test]
        public void LogoutTest()
        {
            LoginPage login = new LoginPage(_driver);
            login.NavigateToLogin();
            login.Login(_userName, "Password96@");
            Assert.IsTrue(login.IsLoggedIn(_userName));
            login.LogoutLink.Click();
            Assert.IsTrue(login.IsDisplayedLoginLink());
        }

    }
}
