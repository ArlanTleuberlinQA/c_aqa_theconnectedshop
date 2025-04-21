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
        private By SearchInput => By.CssSelector("[name='q']");
        private By ProductItem => By.ClassName("ProductItem__ImageWrapper");
        private IWebElement GetFirstSearchButton() 
        {
            var elements = driver.FindElements(SearchButton);
            if (!elements.Any())
            throw new NoSuchElementException("Не найден элемент с data-action='toggle-search'");
            return elements.First();
        }
        private IWebElement GetFirstSearchItem() 
        {
            var elements = driver.FindElements(ProductItem);
            if (!elements.Any())
            throw new NoSuchElementException("Не найден элемент с классом ProductItem__ImageWrapper'");
            return elements.First();
        }
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
        public string GetItemhHref() => GetFirstSearchItem().GetAttribute("href");
        public bool IsItemDisplayed() => GetFirstSearchItem().Displayed;

    }
}
 