using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using TheConnectedShop.Config;
namespace Theconnectedshop.Pages.Components
{
public class HeaderComponent
{
private readonly IWebDriver driver;
private readonly WebDriverWait wait;
public HeaderComponent(IWebDriver driver)
{
this.driver = driver;
this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(Settings.DefaultTimeout));
}
private By Logo => By.ClassName("Header__LogoImage--transparent");
private By AccountButton => By.CssSelector("a.Heading.Link.Link--primary.Text--subdued.u-h8");
private By CartButton => By.CssSelector("a[aria-label='Open cart']");
private By CartCount => By.CssSelector(".Header__CartCount");
public void WaitForPageToLoad()
{
wait.Until(driver => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));
}
public bool IsLogoDisplayed() => driver.FindElement(Logo).Displayed;
public string GetLogoHeight() => driver.FindElement(Logo).GetAttribute("height");
public string GetLogoWidth() => driver.FindElement(Logo).GetAttribute("width");
public void ClickLogo() => driver.FindElement(Logo).Click();
public bool IsAccountButtonDisplayed() => driver.FindElement(AccountButton).Displayed;
public string GetAccountButtonHeight() => driver.FindElement(AccountButton).GetCssValue("height");
public string GetAccountButtonWidth() => driver.FindElement(AccountButton).GetCssValue("width");
public bool IsCartButtonDisplayed() => driver.FindElement(CartButton).Displayed;
public string GetCartCountText() => driver.FindElement(CartCount).Text;
}
}