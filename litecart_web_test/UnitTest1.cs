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

        [Test]
        public void TestSquare()
        {
            Square s1 = new Square(10);
            Square s2 = new Square(15);
            Square s3 = s1;

            NUnit.Framework.Assert.AreEqual(s1.Area, 10);
            NUnit.Framework.Assert.AreEqual(s2.Area, 15);
            NUnit.Framework.Assert.AreEqual(s3.Area, 10);

            s3.Area = 20;

            NUnit.Framework.Assert.AreEqual(s1.Area, 20);

        }

        [Test]
        public void TestCircle()
        {
            Circle s1 = new Circle(1);
            Circle s2 = new Circle(5);
            Circle s3 = s1;

            NUnit.Framework.Assert.AreEqual(s1.Radius, 1);
            NUnit.Framework.Assert.AreEqual(s2.Radius, 5);
            NUnit.Framework.Assert.AreEqual(s3.Radius, 1);

            s3.Radius = 7;

            NUnit.Framework.Assert.AreEqual(s1.Radius, 7);

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
