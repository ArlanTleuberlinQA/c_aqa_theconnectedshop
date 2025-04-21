using NUnit.Framework;
using OpenQA.Selenium;
using TheConnectedShop.Drivers;
using OpenQA.Selenium.Support.UI;
using Theconnectedshop.Pages;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Chrome;
using SeleniumExtras.WaitHelpers;


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
public void Found_RealItem()
{
    homePage.Search.ClickSearchButton();
    Assert.That(homePage.Search.IsSearchInputDisplayed(), "Search input is not displayed");
    homePage.Search.EnterSearchQuery("Smart Door Lock Slim");
    // Assert.That(homePage.Search.GetSearchInputValue(),Is.EqualTo("Smart Door Lock Slim"));
    string actual = homePage.Search.GetSearchInputValue();
    Assert.That(actual,Is.EqualTo("Smart Door Lock Slim"));
    Assert.That(homePage.Search.IsItemNotFoundDisplayed(),Is.False);
    Assert.That(homePage.Search.IsItemDisplayed(),"Item isn't visible");
    Assert.That(homePage.Search.GetItemhHref(),Does.Contain("smart-door-lock-slim"));

}
[Test]
public void Found_UnavailableItem()
{
    homePage.Search.ClickSearchButton();
    Assert.That(homePage.Search.IsSearchInputDisplayed(), "Search input is not displayed");
    homePage.Search.EnterSearchQuery("undefined");
    Assert.That(homePage.Search.IsItemDisplayed(),Is.False);
    Assert.That(homePage.Search.IsItemNotFoundDisplayed());
    Assert.That(homePage.Search.GetNoResultsText(), Is.EqualTo("No results could be found"));


}
[TearDown]
public void TearDown()
{
driver.Quit();
}
}
}