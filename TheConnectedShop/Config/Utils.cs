using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace Theconnectedshop.Config.Utils
{
    public static class UniversalMethods
    {
        public static void ClickElement(IWebDriver driver, By locator, int timeoutInSeconds = 10)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            wait.Until(ExpectedConditions.ElementToBeClickable(locator)).Click();
        }
        public static void EnterText(IWebDriver driver, By locator, string text, int timeoutInSeconds = 10)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            var element = wait.Until(ExpectedConditions.ElementIsVisible(locator));
            element.Clear();
            element.SendKeys(text);
        }
        public static void ClickElement(IWebDriver driver, Func<IWebElement> getElement, int timeoutInSeconds = 10)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            IWebElement element = wait.Until(driver =>
            {
                try
                {
                    var el = getElement();
                    return (el.Displayed && el.Enabled) ? el : null;
                    }
                    catch
                    {
                        return null;
                    }
            });
                        element.Click();
            }
       
        public static bool IsElementDisplayed(IWebDriver driver, By locator, int timeoutInSeconds = 10)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                return wait.Until(ExpectedConditions.ElementIsVisible(locator)).Displayed;
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }
        public static bool IsElementDisplayed(IWebDriver driver, Func<IWebElement> getElement, int timeoutInSeconds = 10)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                var element = wait.Until(driver =>
                {
                    try
                    {
                        var el = getElement();
                        return (el.Displayed) ? el : null;
                    }
                        catch
                        {
                            return null;
                        }
                });
                            return element != null && element.Displayed;
            }
                            catch (WebDriverTimeoutException)
                            {
                                return false;
                            }
            }

        public static string GetInputValue(IWebDriver driver, By locator, int timeoutInSeconds = 10)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            var element = wait.Until(ExpectedConditions.ElementIsVisible(locator));
            return element.GetAttribute("value");
        }
        public static string GetElementHref(IWebDriver driver, By locator, int timeoutInSeconds = 10)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            var element = wait.Until(ExpectedConditions.ElementIsVisible(locator));
            return element.GetAttribute("href");
        }
    }
}
 

 