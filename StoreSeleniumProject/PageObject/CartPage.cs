namespace StoreSeleniumProject.PageObject;

public class CartPage
{
    private IWebDriver _driver;
    private WebDriverWait _wait;

    public CartPage(IWebDriver driver)
    {
        _driver = driver;
        _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
    }

    public IWebElement ShoppingCartLink => _driver.FindElement(By.CssSelector("#navbarExample > ul > li:nth-child(4) > a"));
    public IWebElement BasketPage => _driver.FindElement(By.ClassName("col-lg-8"));
    public IWebElement ShoppingCartPage => _driver.FindElement(By.Id("page-wrapper"));
    public IWebElement ProductLinkSamsungS6 => _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.LinkText("Samsung galaxy s6")));
    public IWebElement AddItemBtn => _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible((By.ClassName("btn-lg"))));
    public IWebElement RemoveItemBtn => _driver.FindElement(By.CssSelector("#tbodyid > tr > td:nth-child(4) > a"));
    public IWebElement CheckoutBtn => _driver.FindElement(By.ClassName("btn-success"));
    public IWebElement ProductDetailsPage => _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.ClassName("product-content")));
    public IWebElement ProductDetailsSamsungS6 => _wait.Until(d => ProductDetailsPage.FindElement(By.ClassName("name")));

    public void ClickOnAProductPage()
    {
        ProductLinkSamsungS6.Click();
    }

    public bool IsOnProductPage()
    {
        return ProductDetailsSamsungS6.Displayed;
    }

    public void AddToCartProduct()
    {
        AddItemBtn.Click();
    }

    public void NagivateToShoppingCart()
    {
        ShoppingCartLink.Click();
    }

    public bool IsOnBasketPage()
    {
        return BasketPage.Displayed;
    }
}
