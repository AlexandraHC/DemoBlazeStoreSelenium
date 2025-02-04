using AventStack.ExtentReports.Model;
using StoreSeleniumProject.Driver;
using StoreSeleniumProject.PageObject;
using StoreSeleniumProject.Tests.Common;

namespace StoreSeleniumProject.Tests;

[TestFixture(DriverType.Firefox)]
[TestFixture(DriverType.Chrome)]
[TestFixture(DriverType.Edge)]

public class ProductCategoriesPageTest : TestBase
{
    public ProductCategoriesPageTest(DriverType driverType) : base(driverType)
    {
    }

    [SetUp]
    public void SetUp()
    {
        base.Setup();
    }

    [Test]
    public void ClickingOnCategoryOfMonitorsTest() 
    {
        ProductCategoriesPage productCategories = new ProductCategoriesPage(_driver);
        productCategories.ClickOnCategoryOfMonitors();
        Assert.IsTrue(productCategories.IsOnMonitorsListingPage());
    }

    [Test]
    public void ClickingOnAllCategoriesTest()
    {
        ProductCategoriesPage productCategories = new ProductCategoriesPage(_driver);
        productCategories.ClickOnCategoryOfMonitors();
        Assert.IsTrue(productCategories.IsOnMonitorsListingPage());

        productCategories.ClickOnCategoryOfMobilePhones();
        Assert.IsTrue(productCategories.IsOnMobilePhoneListingPage());

        productCategories.ClickOnCategoryOfLaptops();
        Assert.IsTrue(productCategories.IsOnLaptopsListingPage());
    }

    [Test]
    public void ClickAProductFromCategoriesTest()
    {
        ProductCategoriesPage productCategories = new ProductCategoriesPage(_driver);
        productCategories.ClickOnCategoryOfLaptops();
        Assert.IsTrue(productCategories.IsOnLaptopsListingPage());

        productCategories.ProductLaptop.Click();
        Assert.IsTrue(productCategories.IsDisplayedAddToCartBtn());
    }

    [Test]
    public void ChangeProductCategoryPageNrTest()
    {
        ProductCategoriesPage productCategories = new ProductCategoriesPage(_driver);
        productCategories.ClickOnCategoryOfMonitors();
        Assert.IsTrue(productCategories.IsOnMonitorsListingPage(), "Is on Monitors listing page");

        productCategories.NextProductsPage.Click();

        //wait 2 seconds for UI to refresh
        Thread.Sleep(2000);
        Assert.IsFalse(productCategories.IsDisplayedNextProductPageButton(), "'Next' pager option is not displayed.");
    }

    [Test]
    public void TestCarouselImagesOnProductCategories()
    {
        ProductCategoriesPage productCategories = new ProductCategoriesPage(_driver);
        productCategories.ClickOnCategoryOfMonitors();

        productCategories.ArrowOnTheLeftCarousel.Click();
        Assert.IsTrue(productCategories.HasTheCarousel3Images());
    }
}
