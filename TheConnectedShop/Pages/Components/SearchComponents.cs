using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using TheConnectedShop.Config;
using OpenQA.Selenium.Chrome;
using Theconnectedshop.Config.Utils;

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
        private By AddToCartButton => By.CssSelector("[data-action='add-to-cart']");
        private By RemoveFormCartButton => By.CssSelector("[data-action='remove-item']");
        private By CloseCartButton => By.CssSelector("#sidebar-cart > div > button");
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
        public bool IsSearchButtonDisplayed() => UniversalMethods.IsElementDisplayed(driver, GetFirstSearchButton);
        public string GetSearchHref() => GetFirstSearchButton().GetAttribute("href");
        public void ClickSearchButton() => UniversalMethods.ClickElement(driver, GetFirstSearchButton);
        public bool IsSearchInputDisplayed() => UniversalMethods.IsElementDisplayed(driver, SearchInput);
        
        public string GetSearchPlaceholder() => driver.FindElement(SearchInput).GetAttribute("placeholder");
        public void EnterSearchQuery(string query) => UniversalMethods.EnterText(driver, SearchInput, query);
        public string GetSearchInputValue() => UniversalMethods.GetInputValue(driver, SearchInput);
        public string GetItemhHref() => UniversalMethods.GetElementHref(driver, ProductItem);
        public bool IsItemDisplayed() => UniversalMethods.IsElementDisplayed(driver, ProductItem);
        public bool IsItemNotFoundDisplayed() => UniversalMethods.IsElementDisplayed(driver, ItemNotFound);
        public void ClickOnItem() => UniversalMethods.ClickElement(driver, ProductItem);
        public void ClickOnAddToCart() => UniversalMethods.ClickElement(driver, AddToCartButton);
        public bool IsRemoveButtomDisplayed() => UniversalMethods.IsElementDisplayed(driver, RemoveFormCartButton);
        public void ClickOnCloseCart() => UniversalMethods.ClickElement(driver, CloseCartButton);
        public void ClickOnRemove() => UniversalMethods.ClickElement(driver, RemoveFormCartButton);





        


    }
}
 