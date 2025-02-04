using StoreSeleniumProject.Driver;
using StoreSeleniumProject.PageObject;
using StoreSeleniumProject.Tests.Common;
using StoreSeleniumProject.Utils.Common;

namespace StoreSeleniumProject.Tests;

[TestFixture(DriverType.Firefox)]
[TestFixture(DriverType.Chrome)]
[TestFixture(DriverType.Edge)]

public class CartPageTest : TestBase
{
    public CartPageTest(DriverType driverType) : base(driverType)
    {
    }


    [SetUp]
    public void SetUp()
    {
        base.Setup();
    }

    [Test]
    public void AddToCartButonTest()
    {
        CartPage addToCart = new CartPage(_driver);
        addToCart.ClickOnAProductPage();
        Assert.IsTrue(addToCart.IsOnProductPage());

        addToCart.AddToCartProduct();
        (bool isAlertVisible, string alertText) = AlertHandler.HandleAlert(_driver);
        Assert.AreEqual("Product added", alertText);

        addToCart.NagivateToShoppingCart();
        Assert.IsTrue(addToCart.IsOnBasketPage());
    }
}
