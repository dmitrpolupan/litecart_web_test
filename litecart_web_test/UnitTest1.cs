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
        public void TestOnLitecart()
        {
            driver.Url = "http://localhost/litecart/en/";
            driver.FindElement(By.ClassName("active")).Click();
            //driver.FindElement(By.XPath(".//*[@data-name='Red Duck']")).Click();
            driver.FindElement(By.LinkText("Regional Settings")).Click();
            wait.Until(ExpectedConditions.TitleIs("Regional Settings | My Store"));
        }

        [Test]
        public void TestGoogle()
        {
           
            OpenPage("https://www.google.com.ua");
            IWebElement a = driver.FindElement(By.Name("q"));
            a.SendKeys("webdrivers");
            driver.FindElement(By.Id("gs_ok0")).Click();
            driver.FindElement(By.Name("btnK")).Click();
            wait.Until(ExpectedConditions.TitleIs("webdrivers - Поиск в Google"));

        }

        [Test]
        public void EnterToAdminLitecart()
        {
            OpenPage("http://localhost/litecart/admin/login.php");
            LoginToPage("admin", "admin");
            wait.Until(ExpectedConditions.TitleIs("My Store"));

        }

        private void LoginToPage(string user, string password)
        {
            driver.FindElement(By.Name("username")).SendKeys(user);
            driver.FindElement(By.Name("password")).SendKeys(password);
            driver.FindElement(By.ClassName("btn-default")).Click();
        }

        private void OpenPage(string siteaddress)
        {
            driver.Url = siteaddress;
            //siteaddress = "";
        }


        [TearDown]
        public void stop()
        {
            driver.Quit();
            driver = null;
        }
    }
}
