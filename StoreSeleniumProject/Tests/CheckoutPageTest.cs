using StoreSeleniumProject.Driver;
using StoreSeleniumProject.PageObject;
using StoreSeleniumProject.Tests.Common;
using StoreSeleniumProject.Utils.Common;

namespace StoreSeleniumProject.Tests;

[TestFixture(DriverType.Firefox)]
[TestFixture(DriverType.Chrome)]
[TestFixture(DriverType.Edge)]

public class CheckoutPageTest : TestBase
{
    public CheckoutPageTest(DriverType driverType) : base(driverType)
    {
    }

    [SetUp]
    public void SetUp()
    {
        base.Setup();
        CartPage addToCart = new CartPage(_driver);
        addToCart.ClickOnAProductPage();
        addToCart.AddToCartProduct();
        (bool isAlertVisible, string alertText) = AlertHandler.HandleAlert(_driver);
        addToCart.NagivateToShoppingCart();
    }

    [Test]
    public void CheckoutTestWithValidPersonalData()
    {
        CheckoutPage checkoutPage = new CheckoutPage(_driver);
        checkoutPage.ClickOnCheckoutButton();
        checkoutPage.FillInCheckoutForm("Judy Cruelle", "America", "Florida", "4562136", "02", "2028");
        checkoutPage.ClickOnPurchaseButton();
        Assert.IsTrue(checkoutPage.IsOrderPlaced());
    }

    [Test]
    public void CheckoutTestWithInvalidPersonalData()
    {
        CheckoutPage checkoutPage = new CheckoutPage(_driver);
        checkoutPage.ClickOnCheckoutButton();
        checkoutPage.FillInCheckoutForm("@", "!", "5", "AA", "t", "t");
        checkoutPage.ClickOnPurchaseButton();
        Assert.IsTrue(checkoutPage.IsOrderPlaced());
    }

    [Test]
    public void CheckoutTestWithAllEmptyFields()
    {
        CheckoutPage checkoutPage = new CheckoutPage(_driver);
        checkoutPage.ClickOnCheckoutButton();
        checkoutPage.FillInCheckoutForm("", "", "", "", "", "");
        //checkoutPage.ClickOnPurchaseButton();

        (bool isAlertVisible, string alertText) = AlertHandler.HandleAlert(_driver);
        Assert.AreEqual("Please fill out Name and Creditcard.", alertText);

        // wait for UI to refresh
        Thread.Sleep(500);
        Assert.False(checkoutPage.IsOrderPlaced());
    }
}
