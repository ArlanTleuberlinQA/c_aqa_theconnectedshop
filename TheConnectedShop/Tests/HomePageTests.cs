using NUnit.Framework;
using OpenQA.Selenium;
using TheConnectedShop.Drivers;
using Theconnectedshop.Pages;
namespace Theconnectedshop.Tests
{
public class HomePageTests
{
private IWebDriver driver;
private HomePage homePage;
[SetUp]
public void SetUp()
{
driver = WebDriverFactory.Create();
homePage = new HomePage(driver);
homePage.Open();
}
[Test]
public void Header_ShouldHaveLogoAndAccountButton()
{
Assert.That(homePage.Header.IsLogoDisplayed(), "Logo is not displayed");
Assert.That(homePage.Header.GetLogoHeight(), Is.EqualTo("75"));
Assert.That(homePage.Header.GetLogoWidth(), Is.EqualTo("250"));
homePage.Header.ClickLogo();
Assert.That(homePage.Header.IsAccountButtonDisplayed(), "Account button not visible");
Assert.That(homePage.Header.GetAccountButtonHeight(), Is.EqualTo("16.5px"));
Assert.That(homePage.Header.GetAccountButtonWidth(), Is.EqualTo("65.6875px"));
}
[Test]
public void CartButton_ShouldBeVisibleAndHaveZeroCount()
{
Assert.That(homePage.Header.IsCartButtonDisplayed(), "Cart button not visible");
Assert.That(homePage.Header.GetCartCountText(), Is.EqualTo("0"), "Cart count should be 0");
}
[TearDown]
public void TearDown()
{
driver.Quit();
}
}
}