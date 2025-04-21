using OpenQA.Selenium;
using Theconnectedshop.Pages.Components;
using TheConnectedShop.Config;

namespace Theconnectedshop.Pages
{
public class HomePage
{
private readonly IWebDriver driver;
public HomePage(IWebDriver driver)
{
this.driver = driver;
Header = new HeaderComponent(driver);
Search = new SearchComponent(driver);
}
public HeaderComponent Header { get; }
public SearchComponent Search { get; }
public void Open() => driver.Navigate().GoToUrl(Settings.BaseURL);
}
}