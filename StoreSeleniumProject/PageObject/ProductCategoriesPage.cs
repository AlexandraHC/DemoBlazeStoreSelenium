namespace StoreSeleniumProject.PageObject;

public class ProductCategoriesPage
{
    private IWebDriver _driver;
    private WebDriverWait _wait;

    public ProductCategoriesPage(IWebDriver driver)
    {
        _driver = driver;
        _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
    }

    By NextPageLocator => By.Id("next2");
    public IWebElement Pager => _driver.FindElement(By.ClassName("pagination"));
    public IWebElement CategoriesList => _driver.FindElement(By.Id("cat"));
    List<IWebElement> ProductCategories => new List<IWebElement>(_driver.FindElements(By.Id("itemc")));
    public IWebElement CategoryOfMobilePhones => ProductCategories[0];
    public IWebElement CategoryOfLaptops => ProductCategories[1];
    public IWebElement CategoryOfMonitors => ProductCategories[2];
    public IWebElement PreviosProductsPage => Pager.FindElement(By.Id("prev2"));
    public IWebElement NextProductsPage  => Pager.FindElement(NextPageLocator);
    public IWebElement ProductMonitor => _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.LinkText("ASUS Full HD")));
    public IWebElement ProductMobilePhone=> _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.LinkText("Iphone 6 32gb")));
    public IWebElement ProductLaptop => _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.LinkText("MacBook Pro")));
    public IWebElement AddToCartBtn => _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.ClassName("btn-lg")));
    public IWebElement ArrowOnTheLeftCarousel => _driver.FindElement(By.ClassName("carousel-control-prev-icon"));
    public IWebElement ArrowOnTheRightCarousel => _driver.FindElement(By.ClassName("carousel-control-prev-icon"));
    public IWebElement Carousel => _driver.FindElement(By.Id("contcar"));
    public List <IWebElement> CarouselImages => new List<IWebElement>(Carousel.FindElements(By.ClassName("img-fluid")));
    //public IWebElement ImageWithMobilePhone => CarouselImages[0]; 
    //public IWebElement ImageWithMobilePhones => CarouselImages[1];
    //public IWebElement ImageWithLaptop => CarouselImages[2];
    

    public void ClickOnCategoryOfMobilePhones()
    {
        CategoryOfMobilePhones.Click();
    }

    public void ClickOnCategoryOfLaptops()
    {
        CategoryOfLaptops.Click();
    }

    public void ClickOnCategoryOfMonitors()
    {
        CategoryOfMonitors.Click();
    }

    public bool IsOnMonitorsListingPage()
    {
        return ProductMonitor.Displayed;
    }

    public bool IsOnMobilePhoneListingPage()
    {
        return ProductMobilePhone.Displayed;
    }

    public bool IsOnLaptopsListingPage()
    {
        return ProductLaptop.Displayed;
    }

    public bool IsDisplayedAddToCartBtn()
    {
        return AddToCartBtn.Displayed;
    }

    public bool IsDisplayedNextProductPageButton()
    {
        return NextProductsPage.Displayed;
    }

    public bool HasTheCarousel3Images()
    {
        return CarouselImages.Count() == 3;
    }

}
