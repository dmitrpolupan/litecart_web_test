using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.IE;
using NUnit.Framework;

namespace litecart_web_test
{
    [TestClass]
    public class UnitTest1
    {
        private IWebDriver driver;
        private WebDriverWait wait;


        [SetUp]
        public void start()
        {

            ChromeOptions options = new ChromeOptions();
            //options.AddArguments("start-fullscreen");
            driver = new ChromeDriver(options);
            //driver = new FirefoxDriver();
            Console.WriteLine(((IHasCapabilities)driver).Capabilities);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            driver.Manage().Cookies.DeleteAllCookies();


        }

        [Test]
        public void TestGoogle()
        {
            driver.Url = "https://www.google.com.ua";
            IWebElement a = driver.FindElement(By.Name("q"));
            a.SendKeys("webdrivers");
            driver.FindElement(By.Id("gs_ok0")).Click();
            driver.FindElement(By.Name("btnK")).Click();
            wait.Until(ExpectedConditions.TitleIs("webdrivers - Поиск в Google"));

        }

        [Test]
        public void EnterToAdminLitecart()
        {
            driver.Url = "http://localhost/litecart/admin/login.php";
            driver.FindElement(By.Name("username")).SendKeys("admin");
            driver.FindElement(By.Name("password")).SendKeys("admin");
            driver.FindElement(By.ClassName("btn-default")).Click();
            wait.Until(ExpectedConditions.TitleIs("My Store"));

        }

       

        [TearDown]
        public void stop()
        {
            driver.Quit();
            driver = null;
        }
    }
}
