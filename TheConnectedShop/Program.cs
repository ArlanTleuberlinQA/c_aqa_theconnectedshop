// using NUnit.Framework;
// using OpenQA.Selenium;
// using OpenQA.Selenium.Chrome;
// using OpenQA.Selenium.Support.UI;
// using OpenQA.Selenium.Interactions;
// using SeleniumExtras.WaitHelpers;
// using System;
// using System.IO;

// class Program
// {
//     private IWebDriver? driver;
//     [SetUp]
//     public void SetUp(){
//         try
//             {
//                 System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
//                 {
//                     FileName = "taskkill",
//                     Arguments = "/IM chromedriver.exe /F",
//                     CreateNoWindow = true,
//                     UseShellExecute = false
//                 })?.WaitForExit();
//             }
//             catch (Exception ex)
//             {
//                 Console.WriteLine($"Failed to kill chromedriver processes: {ex.Message}");
//             } 
//              ChromeOptions options = new ChromeOptions();
//              options.AddArgument($"user-data-dir={Path.Combine(Directory.GetCurrentDirectory(), "ChromeTestProfile")}");
//              options.AddArgument("--disable-notifications");
//              options.AddArgument("--disable-popup-blocking");
//              options.AddArgument("--no-sandbox");
//              options.AddArgument("--disable-dev-shm-usage");
//              driver = new ChromeDriver(options);
//              driver.Manage().Window.Maximize();
//     }
//    [Test]
//    public void OpenTheConnectedShop(){
//     driver.Navigate().GoToUrl("https://theconnectedshop.com/");
//     WebDriverWait waitForPageLoad = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
//     waitForPageLoad.Until(drv => ((IJavaScriptExecutor)drv).ExecuteScript("return document.readyState").Equals("complete"));
//     string expectedTitle = "The Connected Shop - Smart Locks, Smart Sensors, Smart Home & Office";
//     Assert.That(driver.Title, Is.EqualTo(expectedTitle),"Title should be The Connected Shop - Smart Locks, Smart Sensors, Smart Home & Office");
//     string expectedUrl = "https://theconnectedshop.com/";
//     Assert.That(driver.Url, Is.EqualTo(expectedUrl));
//     IWebElement logo = driver.FindElement(By.ClassName("Header__LogoImage--transparent"));
//     Assert.That(logo.Displayed, "Logo should be visible");
//     string logoSrc = "https://theconnectedshop.com/cdn/shop/files/The_Connected_Shop_logo_250x.png?v=1705959163";
//     Assert.That(logo.GetAttribute("src"),Is.EqualTo(logoSrc), "Logo source is correct");
    
//     IWebElement header = driver.FindElement(By.Id("section-header"));
//     Actions actions = new Actions(driver);
//     actions.MoveToElement(header).Perform();
//     WebDriverWait waitHeaderChange = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
//     waitHeaderChange.Until(drv =>
// {
//     string cls = header.GetAttribute("class");
//     return !cls.Contains("Header--transparent");
// });

//     string classAttribute = header.GetAttribute("class");

//     Assert.That(classAttribute.Contains("Header--transparent"), Is.False,
//         "Header повинен бути в активному стані (без класу Header--transparent)");
           
//    }
   
 
//    [TearDown]
//    public void TearDown(){
// try
// {
// if (driver != null)
// {
// driver.Quit();
// driver.Dispose();
// }
// }
// catch (Exception ex)
// {
// Console.WriteLine($"Error during teardown: {ex.Message}");
// }
// finally
// {
// driver = null;
// }
// }

// }
