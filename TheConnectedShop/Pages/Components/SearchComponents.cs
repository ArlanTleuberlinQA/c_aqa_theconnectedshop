using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using TheConnectedShop.Config;
using OpenQA.Selenium.Chrome;

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
        private By SearchInput => By.CssSelector("[name='q']");
        private By ProductItem => By.CssSelector(".Segment__Content > div > div:nth-child(1) > div > div > a");
        private By ItemNotFound => By.CssSelector(".Segment__Content > p");
        public string? GetNoResultsText()
{
    try
    {
        return driver.FindElement(ItemNotFound).Text;
    }
    catch (NoSuchElementException)
    {
        return null;
    }
}

        private IWebElement GetFirstSearchButton() 
        {
            var elements = driver.FindElements(SearchButton);
            if (!elements.Any())
            throw new NoSuchElementException("Не найден элемент с data-action='toggle-search'");
            return elements.First();
        }
        // private IWebElement GetFirstSearchItem() 
        // {
        //     var elements = driver.FindElements(ProductItem);
        //     if (!elements.Any())
        //     throw new NoSuchElementException("Не найден элемент с классом ProductItem__ImageWrapper'");
        //     return elements.First();
        // }
        public bool IsSearchButtonDisplayed() => GetFirstSearchButton().Displayed;
        public string GetSearchHref() => GetFirstSearchButton().GetAttribute("href");
        public void ClickSearchButton() => GetFirstSearchButton().Click();
        public bool IsSearchInputDisplayed()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(SearchInput));
            return GetFirstSearchButton().Displayed;
        }
        
        public string GetSearchPlaceholder() => driver.FindElement(SearchInput).GetAttribute("placeholder");
        public void EnterSearchQuery(string query)
        {
            wait.Until(ExpectedConditions.ElementIsVisible(SearchInput));
            var input = driver.FindElement(SearchInput);
            input.Clear(); 
            input.SendKeys(query);
        }
        public string GetSearchInputValue()
        {
            return driver.FindElement(SearchInput).GetAttribute("value");
        }
        public string GetItemhHref() => driver.FindElement(ProductItem).GetAttribute("href");
        public bool IsItemDisplayed() {
    try
    {
        var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(Settings.DefaultTimeout));
        var element = wait.Until(driver => driver.FindElement(ProductItem));
        return element.Displayed;
    }
    catch (WebDriverTimeoutException)
    {
        return false;
    }
}
        public bool IsItemNotFoundDisplayed()
{
    try
    {
        var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(Settings.DefaultTimeout));
        var element = wait.Until(driver => driver.FindElement(ItemNotFound));
        return element.Displayed;
    }
    catch (WebDriverTimeoutException)
    {
        return false;
    }
}
    }
}
 