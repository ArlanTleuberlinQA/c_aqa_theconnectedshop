using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.WaitHelpers;
using System;
using System.IO;
using System.Threading;

namespace SeleniumTests
{
public class Program
{
private IWebDriver? driver;
[SetUp]
public void SetUp()
{
try
{
System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
{
FileName = "taskkill",
Arguments = "/IM chromedriver.exe /F",
CreateNoWindow = true,
UseShellExecute = false
})?.WaitForExit();
}
catch (Exception ex)
{
Console.WriteLine($"Failed to kill chromedriver processes: {ex.Message}");
}
ChromeOptions options = new ChromeOptions();
options.AddArgument($"user-data-dir={Path.Combine(Directory.GetCurrentDirectory(), "ChromeTestProfile")}");
options.AddArgument("--disable-notifications");
options.AddArgument("--disable-popup-blocking");
options.AddArgument("--no-sandbox");
options.AddArgument("--disable-dev-shm-usage");
driver = new ChromeDriver(options);
driver.Manage().Window.Maximize();
}
[Test]
public void SearchItems()
{
driver.Navigate().GoToUrl("https://theconnectedshop.com/");
WebDriverWait waitForPageLoad = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
waitForPageLoad.Until(drv => ((IJavaScriptExecutor)drv).ExecuteScript("return document.readyState").Equals("complete"));
try
{
WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
IWebElement searchLink = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("[data-action='toggle-search']")));
searchLink.Click();
}
catch (WebDriverTimeoutException)
{
Console.WriteLine("Search toggle button not found, assuming search is already visible.");
}
try
{
WebDriverWait waitSearch = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
IWebElement inputSearch = waitSearch.Until(ExpectedConditions.ElementIsVisible(By.ClassName("Search__Input")));
inputSearch.SendKeys("Smart Door Lock Slim");
WebDriverWait waitItem = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
IWebElement findedProduct = waitItem.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("[href*='42880260374769']")));
Assert.That(findedProduct.Displayed, "Product link should be displayed.");
}
catch (WebDriverTimeoutException ex)
{
Console.WriteLine($"Search input or product not found: {ex.Message}");
Assert.Fail("Failed to find search input or product");
}
try{
WebDriverWait waitSearch = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
IWebElement inputSearch = waitSearch.Until(ExpectedConditions.ElementIsVisible(By.ClassName("Search__Input")));
inputSearch.Clear();
inputSearch.SendKeys("undefined");
WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
IWebElement unfindedProduct = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("div:nth-child(1) > div > div.Segment__Content > p")));
Assert.That(unfindedProduct.Displayed, "Info text about no results");
}
catch (WebDriverTimeoutException ex)
{
Console.WriteLine($"Result text not appear or product was found {ex.Message}");
Assert.Fail("Failed to show result text or product found");
}
}
[TearDown]
public void TearDown()
{
try
{
if (driver != null)
{
driver.Quit();
driver.Dispose();
}
}
catch (Exception ex)
{
Console.WriteLine($"Error during teardown: {ex.Message}");
}
finally
{
driver = null;
}
}
}
}