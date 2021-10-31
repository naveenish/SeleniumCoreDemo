using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;

namespace SeleniumCoreDemo.Test
{
    class PayeesPageTest
    {
        public String name = "abc23452";

        //SetUp Selenium WebDriver
        IWebDriver webDriver = new ChromeDriver(@"C:\");

        //public RemoteWebDriver webDriver;
        //static RemoteWebDriver webDriver = null;
        //driver = new ChromeDriver();

        //Hooks in Nunit
        [SetUp]
        public void Setuptest()
        {

            //Navigate to Website
            webDriver.Navigate().GoToUrl("https://www.demo.bnz.co.nz/client/");
            webDriver.Manage().Window.Maximize();
            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
        }

        [Test]
        public void NavigateToPayeesPageTest()
        {
            //TC1: Verify you can navigate to Payees page using the navigation menu
            //1.Click ‘Menu’
            IWebElement Menu = webDriver.FindElement(By.CssSelector(".js-main-menu-button-text .Language__container"));
            Menu.Click();
            System.Threading.Thread.Sleep(1000);

            //2.Click ‘Payees’
            {
                var element = webDriver.FindElement(By.CssSelector(".js-main-menu-international > .Button"));
                Actions builder = new Actions(webDriver);
                builder.MoveToElement(element).Perform();
            }

            System.Threading.Thread.Sleep(1000);
            IWebElement Payees = webDriver.FindElement(By.CssSelector(".js-main-menu-payees .Language__container"));
            Payees.Click();
            System.Threading.Thread.Sleep(1000);

            //3.Verify Payees page is loaded
            IWebElement AddBtn = webDriver.FindElement(By.CssSelector(".Button > .Language__container"));
            Assert.That(AddBtn.Displayed, Is.True);

        }

        


        [TearDown]
        public void Teardown() => webDriver.Quit(); //Close all browser session
    }
}
