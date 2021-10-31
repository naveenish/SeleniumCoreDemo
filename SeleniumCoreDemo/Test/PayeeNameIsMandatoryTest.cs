using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Interactions;

namespace SeleniumCoreDemo.Test
{
    class PayeeNameIsMandatoryTest
    {
        public String name = "abc23452";

        //SetUp Selenium WebDriver
        IWebDriver driver = new ChromeDriver(@"C:\");

        //Hooks in Nunit
        [SetUp]
        public void Setuptest()
        {
            //Navigate to Website
            driver.Navigate().GoToUrl("https://www.demo.bnz.co.nz/client/");
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
        }

        [Test]
        public void PayeeNameIsMandatoryValidationTest()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl("https://www.demo.bnz.co.nz/client/");
            driver.FindElement(By.CssSelector(".js-main-menu-button-text .Language__container")).Click();  // click on Menu button
            driver.FindElement(By.CssSelector(".js-main-menu-payees .Language__container")).Click();  // click on Payees                                                                                                 
            driver.FindElement(By.CssSelector(".Button > .Language__container")).Click();   // click on Add button
            driver.FindElement(By.CssSelector(".js-submit")).Click();
            Assert.AreEqual("A problem was found. Please correct the field highlighted below.", driver.FindElement(By.CssSelector(".error-header")).Text.ToString());

            driver.FindElement(By.CssSelector("#ComboboxInput-apm-name")).Clear();  // clear the name textbox
            driver.FindElement(By.CssSelector("#ComboboxInput-apm-name")).SendKeys(name);
            driver.FindElement(By.XPath("//span[@title='Someone new: " + name + "']")).Click();
            List<IWebElement> e = new List<IWebElement>();
            e.AddRange(driver.FindElements(By.CssSelector(".error-header"))); // add all the elements to the list
            Assert.IsTrue(e.Count == 0);

        }

        [TearDown]
        public void Teardown() => driver.Quit(); //Close all browser session
    }
}
