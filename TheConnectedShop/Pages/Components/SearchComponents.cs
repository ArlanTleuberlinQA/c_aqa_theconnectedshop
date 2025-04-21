using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using TheConnectedShop.Config;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Theconnectedshop.Pages.Components

{
    public class SearchComponent
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;
        public SearchComponent(IWebDriver driver)
        {
            this.driver = driver;
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(Settings.DefaultTimeout));
        }
        private By SearchButton => By.CssSelector("a[data-action='toggle-search']");
        private By SearchInput => By.ClassName("Search__Input");
        public bool IsSearchButtonDisplayed() => driver.FindElement(SearchButton).Displayed;
        public string GetSearchHref() => driver.FindElement(SearchButton).GetAttribute("href");
        public void ClickSearchButton() => driver.FindElement(SearchButton).Click();
        public bool IsSearchInputDisplayed()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(SearchInput));
            return driver.FindElement(SearchInput).Displayed;
        }
        public string GetSearchPlaceholder() => driver.FindElement(SearchInput).GetAttribute("placeholder");
    }
}
 