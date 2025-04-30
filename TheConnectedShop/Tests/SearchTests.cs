using NUnit.Framework;
using OpenQA.Selenium;
using TheConnectedShop.Drivers;
using OpenQA.Selenium.Support.UI;
using Theconnectedshop.Pages;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Chrome;
using SeleniumExtras.WaitHelpers;
using Theconnectedshop.Config.Utils;


namespace Theconnectedshop.Tests
{
public class SearchTests
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
public void SearchButtonAndInput_ShouldBeVisible()
{
Assert.That(homePage.Search.IsSearchButtonDisplayed(), "Search button is not visible");
Assert.That(homePage.Search.GetSearchHref().EndsWith("/search"), "Search button href is incorrect");
homePage.Search.ClickSearchButton();
Assert.That(homePage.Search.IsSearchInputDisplayed(), "Search input is not displayed");
Assert.That(homePage.Search.GetSearchPlaceholder(), Is.EqualTo("Search..."), "Search placeholder is incorrect");
}
[Test]
public void Found_RealItem_CustomSoftAssert()
{
var errors = new List<Exception>();
try
{
Assert.That(homePage.Search.IsSearchButtonDisplayed(), "Search button is not visible");
}
catch (Exception ex)
{
errors.Add(ex);
}
try
{
homePage.Search.ClickSearchButton();
}
catch (Exception ex)
{
errors.Add(ex);
}
try
{
Assert.That(homePage.Search.IsSearchInputDisplayed(), "Search input is not displayed");
}
catch (Exception ex)
{
errors.Add(ex);
}
try
{
homePage.Search.EnterSearchQuery("Smart Door Lock Slim");
}
catch (Exception ex)
{
errors.Add(ex);
}
try
{
string actual = homePage.Search.GetSearchInputValue();
Assert.That(actual, Is.EqualTo("Smart Door Lock Slim"), "Search input value is incorrect");
}
catch (Exception ex)
{
errors.Add(ex);
}
try
{
Assert.That(homePage.Search.IsItemNotFoundDisplayed(), Is.False, "Item should be found, but 'no results' message is visible");
}
catch (Exception ex)
{
errors.Add(ex);
}
try
{
Assert.That(homePage.Search.IsItemDisplayed(), "Expected item to be visible in search results");
}
catch (Exception ex)
{
errors.Add(ex);
}
try
{
Assert.That(homePage.Search.GetItemhHref(), Does.Contain("smart-door-lock-slim"), "Item href is incorrect");
}
catch (Exception ex)
{
errors.Add(ex);
}

if (errors.Any())
throw new AggregateException("Ошибки при выполнении soft asserts:", errors);
}

[Test]
public void Found_UnavailableItem()
{
    var soft = new UniversalMethods.SoftAssert();

    soft.That(() => Assert.That(homePage.Search.IsSearchButtonDisplayed(), "Search button is not visible"));
    soft.That(() => homePage.Search.ClickSearchButton());
    soft.That(() => Assert.That(homePage.Search.IsSearchInputDisplayed(), "Search input is not displayed"));
    soft.That(() => homePage.Search.EnterSearchQuery("undefined"));
    soft.That(() => Assert.That(homePage.Search.IsItemDisplayed(),Is.False));
    soft.That(() => Assert.That(homePage.Search.IsItemNotFoundDisplayed()));
    soft.That(() => Assert.That(homePage.Search.GetNoResultsText(), Is.EqualTo("No results could be found")));

    soft.AssertAll();

}
[Test]
public void AddItemToCart()
{
    Assert.That(homePage.Search.IsSearchButtonDisplayed(), "Search button is not visible");
    homePage.Search.ClickSearchButton();
    Assert.That(homePage.Search.IsSearchInputDisplayed(), "Search input is not displayed");
    homePage.Search.EnterSearchQuery("Smart Door Lock Slim");
    string actual = homePage.Search.GetSearchInputValue();
    Assert.That(actual, Is.EqualTo("Smart Door Lock Slim"), "Search input value is incorrect");
    Assert.That(homePage.Search.IsItemDisplayed(), "Expected item to be visible in search results");
    homePage.Search.ClickOnItem();
    homePage.Search.ClickOnAddToCart();
    Assert.That(homePage.Search.IsRemoveButtomDisplayed(),"Remove button not appear");
    homePage.Search.ClickOnCloseCart();
    Assert.That(homePage.Header.GetCartCountText(),Is.EqualTo("1"));
    homePage.Header.ClickOnCart();
    homePage.Search.ClickOnRemove();



}
[TearDown]
public void TearDown()
{
driver.Quit();
}
}
}