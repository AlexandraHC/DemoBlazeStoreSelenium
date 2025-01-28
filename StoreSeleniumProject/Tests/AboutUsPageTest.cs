using StoreSeleniumProject.Driver;
using StoreSeleniumProject.PageObject;
using StoreSeleniumProject.Tests.Common;

namespace StoreSeleniumProject.Tests
{
    [TestFixture(DriverType.Firefox)]
    [TestFixture(DriverType.Chrome)]
    [TestFixture(DriverType.Edge)]

    public class AboutUsPageTest : TestBase
    {
        public AboutUsPageTest(DriverType driverType) : base(driverType)
        {
        }

        [SetUp]
        public void SetUp()
        {
            base.Setup();
        }

        [Test]
        public void AboutUsPopUpTest()
        {
            AboutUsPage aboutUs = new AboutUsPage(_driver);
            aboutUs.NavigateToAboutUsLink();
            aboutUs.PlayVideoButton();
            Assert.True(aboutUs.IsVideoStarted());

            aboutUs.CloseTheAboutUsPopup();
        }
    }
}
