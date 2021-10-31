using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumCoreDemo.Test
{
    class TransferPaymentsPage
    {
        //SetUp Selenium WebDriver
        IWebDriver driver = new ChromeDriver(@"C:\");
        [Test]
        public void TransferPaymentsValidationTest()
        {

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl("https://www.demo.bnz.co.nz/client/");

            driver.FindElement(By.XPath("//h3[contains(.,'Everyday')]")).Click(); // click on Everyday card
            string everydayOriginalValue = driver.FindElement(By.CssSelector(".js-account-current")).Text.ToString();
            Console.WriteLine("everyday previous valus is " + everydayOriginalValue);
            driver.FindElement(By.CssSelector(".js-close-modal-button")).Click();

            System.Threading.Thread.Sleep(5000);// no need
            driver.FindElement(By.XPath("//h3[contains(.,'Bill')]")).Click(); // click on Everyday card
            string billOriginalValue = driver.FindElement(By.CssSelector(".js-account-current")).Text.ToString();
            Console.WriteLine("bill previous valus is " + billOriginalValue);
            driver.FindElement(By.CssSelector(".js-close-modal-button")).Click();

            driver.FindElement(By.CssSelector(".js-main-menu-button-text .Language__container")).Click(); //click on Menu button
            driver.FindElement(By.CssSelector(".js-main-menu-paytransfer .Language__container")).Click();  // click on Pay or transfer
            driver.FindElement(By.XPath("//span[contains(.,'Choose account')]")).Click(); // transfer from
            driver.FindElement(By.CssSelector("input[placeholder='Search']")).Clear(); // clear textbox
            driver.FindElement(By.CssSelector("input[placeholder='Search']")).SendKeys("Every"); // enter value
            System.Threading.Thread.Sleep(3000);
            driver.FindElement(By.XPath("//p[text()='Everyday']")).Click(); // select the first item
            System.Threading.Thread.Sleep(3000);
            driver.FindElement(By.XPath("//span[contains(.,'Choose account, payee, or someone new')]")).Click(); // transfer to

            driver.FindElement(By.CssSelector("input[placeholder = 'Search']")).Clear(); // clear textbox
            driver.FindElement(By.CssSelector("input[placeholder = 'Search']")).SendKeys("Bill"); // enter value
            System.Threading.Thread.Sleep(3000);
            driver.FindElement(By.XPath("//p[text()='Bills ']")).Click(); // select the first item
            System.Threading.Thread.Sleep(3000);

            driver.FindElement(By.XPath("//input[@name='amount']")).Clear(); // clear textbox
            driver.FindElement(By.XPath("//input[@name='amount']")).SendKeys("500"); // enter value

            driver.FindElement(By.XPath("//span[contains(@class,'Language__container')][normalize-space()='Transfer']")).Click();   // click on Transfer button

            System.Threading.Thread.Sleep(3000);
            //Assert.AreEqual("Payee added", driver.SwitchTo().Alert().Text.ToString());
            Assert.AreEqual("Transfer successful", driver.FindElement(By.CssSelector("span[role='alert']")).Text.ToString());

            driver.FindElement(By.XPath("//h3[contains(.,'Everyday')]")).Click(); // click on Everyday card
            string everydayNewValue = driver.FindElement(By.CssSelector(".js-account-current")).Text.ToString();
            Console.WriteLine("bill new balance is " + everydayNewValue);
            driver.FindElement(By.CssSelector(".js-close-modal-button")).Click();

            driver.FindElement(By.XPath("//h3[contains(.,'Bill')]")).Click(); // click on Everyday card
            string billNewValue = driver.FindElement(By.CssSelector(".js-account-current")).Text.ToString();
            Console.WriteLine("bill new balance is " + billNewValue);
            driver.FindElement(By.CssSelector(".js-close-modal-button")).Click();

            Assert.IsFalse(everydayOriginalValue == everydayNewValue);
            Assert.IsFalse(billOriginalValue == billNewValue);
        }
        [TearDown]
        public void Teardown() => driver.Quit(); //Close all browser session 
    }
}
