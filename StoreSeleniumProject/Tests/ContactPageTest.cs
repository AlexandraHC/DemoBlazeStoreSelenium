using StoreSeleniumProject.Driver;
using StoreSeleniumProject.PageObject;
using StoreSeleniumProject.Tests.Common;
using StoreSeleniumProject.Utils.Common;

namespace StoreSeleniumProject.Tests;

[TestFixture(DriverType.Firefox)]
[TestFixture(DriverType.Chrome)]
[TestFixture(DriverType.Edge)]

public class ContactPageTest : TestBase 
{
    public ContactPageTest(DriverType driverType) : base(driverType)
    {
    }

    [SetUp]
    public void SetUp()
    {
        base.Setup();
    }

    [Test]
    public void ContactTestWithValidCredentials()
    {
        ContactPage contact = new ContactPage(_driver);
        contact.NavigateToContactLink();
        contact.FillInContactForm("Roxanne@example.com", "Roxanne", "The login link doesn't work.");

        (bool isAlertVisible, string alertText) = AlertHandler.HandleAlert(_driver);
        Assert.AreEqual("Thanks for the message!!", alertText);
    }

    [Test]
    public void ContactTestWithInvalidCredentials()
    {
        ContactPage contact = new ContactPage(_driver);
        contact.NavigateToContactLink();
        contact.FillInContactForm("2", "#", "$");

        (bool isAlertVisible, string alertText) = AlertHandler.HandleAlert(_driver);
        Assert.AreEqual("Thanks for the message!!", alertText);
    }

    [Test]
    public void ContactTestWithoutCredentials()
    {
        ContactPage contact = new ContactPage(_driver);
        contact.NavigateToContactLink();
        contact.FillInContactForm("", "", "");

        (bool isAlertVisible, string alertText) = AlertHandler.HandleAlert(_driver);
        Assert.AreEqual("Thanks for the message!!", alertText);
    }

    [Test]
    public void ContactTestWithoutContactEmailField()
    {
        ContactPage contact = new ContactPage(_driver);
        contact.NavigateToContactLink();
        contact.FillInContactForm("", "Roxanne", "The login link doesn't work.");

        (bool isAlertVisible, string alertText) = AlertHandler.HandleAlert(_driver);
        Assert.AreEqual("Thanks for the message!!", alertText);
    }

    [Test]
    public void ContactTestWithoutContactNameField()
    {
        ContactPage contact = new ContactPage(_driver);
        contact.NavigateToContactLink();
        contact.FillInContactForm("Roxanne@example.com", "", "The login link doesn't work.");

        (bool isAlertVisible, string alertText) = AlertHandler.HandleAlert(_driver);
        Assert.AreEqual("Thanks for the message!!", alertText);
    }

    [Test]
    public void ContactTestWithMessageFieldEmpty()
    {
        ContactPage contact = new ContactPage(_driver);
        contact.NavigateToContactLink();
        contact.FillInContactForm("Roxanne@example.com", "", "The login link doesn't work.");

        (bool isAlertVisible, string alertText) = AlertHandler.HandleAlert(_driver);
        Assert.AreEqual("Thanks for the message!!", alertText);
    }

    [Test]
    public void TestOpenAndCloseContactFormFunctionalities()
    {
        ContactPage contact = new ContactPage(_driver);
        contact.NavigateToContactLink();
        contact.CloseContactsPopup();

        // wait for UI to refresh
        Thread.Sleep(500);
        Assert.IsFalse(contact.IsContactPopupVisible());
    }
}
