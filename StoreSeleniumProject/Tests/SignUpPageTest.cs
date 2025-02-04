using StoreSeleniumProject.Driver;
using StoreSeleniumProject.PageObject;
using StoreSeleniumProject.Tests.Common;
using StoreSeleniumProject.Utils.Common;

namespace StoreSeleniumProject.Tests;

[TestFixture(DriverType.Firefox)]
[TestFixture(DriverType.Chrome)]
[TestFixture(DriverType.Edge)]

public class SignUpPageTest : TestBase
{
    public SignUpPageTest(DriverType driverType) : base(driverType)
    {

    }

    [SetUp]
    public void Setup()
    {
        base.Setup();
    }

    [Test]
    public void SignUpWithValidCredentials()
    {
        SignUpPage signUp = new SignUpPage(_driver);
        signUp.NavigateToSignUp();
        signUp.SignUp();
        (bool isAlertVisible, string alertText) = AlertHandler.HandleAlert(_driver);
        Assert.IsTrue(isAlertVisible);
        Assert.AreEqual("Sign up successful.", alertText);
    }

    [Test]
    public void SignUpWithInvalidCredentials()
    {
        SignUpPage signUp = new SignUpPage(_driver);
        signUp.NavigateToSignUp();
        signUp.SignUp("*","!");
        (bool isAlertVisible, string alertText) = AlertHandler.HandleAlert(_driver);
        Assert.IsTrue(isAlertVisible);
        Assert.AreEqual("This user already exist.", alertText);
    }

    [Test]
    public void SignUpWithoutCredentials()
    {
        SignUpPage signUp = new SignUpPage(_driver);
        signUp.NavigateToSignUp();
        signUp.SignUp("", "");
        (bool isAlertVisible, string alertText) = AlertHandler.HandleAlert(_driver);
        Assert.IsTrue(isAlertVisible);
        Assert.AreEqual("Please fill out Username and Password.", alertText);
    }

    [Test]
    public void SignUpWithoutUsernameCredentials()
    {
        SignUpPage signUp = new SignUpPage(_driver);
        signUp.NavigateToSignUp();
        signUp.SignUp("", "T");
        (bool isAlertVisible, string alertText) = AlertHandler.HandleAlert(_driver);
        Assert.IsTrue(isAlertVisible);
        Assert.AreEqual("Please fill out Username and Password.", alertText);
    }

    [Test]
    public void SignUpWithoutPasswordCredentials()
    {
        SignUpPage signUp = new SignUpPage(_driver);
        signUp.NavigateToSignUp();
        signUp.SignUp("a", "");
        (bool isAlertVisible, string alertText) = AlertHandler.HandleAlert(_driver);
        Assert.IsTrue(isAlertVisible);
        Assert.AreEqual("Please fill out Username and Password.", alertText);
    }
}