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
    class PayeesPageTest
    {
        public String name = "abc23452";

        //SetUp Selenium WebDriver
        IWebDriver webDriver = new ChromeDriver(@"C:\");
        
        //Hooks in Nunit
        [SetUp]
        public void Setuptest() {
            
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

        [Test]
        public void AddNewPayeesTest()
        {
            //TC2: Verify you can add new payee in the Payees page
            //1. Navigate to Payees page
            IWebElement Menu = webDriver.FindElement(By.CssSelector(".js-main-menu-button-text .Language__container"));
            Menu.Click();
            System.Threading.Thread.Sleep(1000);

            //Click ‘Payees’
            {
                var element1 = webDriver.FindElement(By.CssSelector(".js-main-menu-international > .Button"));
                Actions builder = new Actions(webDriver);
                builder.MoveToElement(element1).Perform();
            }
            //2. Click ‘Add’ button
            System.Threading.Thread.Sleep(1000);
            IWebElement Payees = webDriver.FindElement(By.CssSelector(".js-main-menu-payees .Language__container"));
            Payees.Click();
            System.Threading.Thread.Sleep(1000);

            //Verify Payees page is loaded
            IWebElement AddBtn = webDriver.FindElement(By.CssSelector(".Button > .Language__container"));
            Assert.That(AddBtn.Displayed, Is.True);
            //--------------------------------------------------------------

            //3.Enter the payee details(name, account number)
            System.Threading.Thread.Sleep(1000);
            AddBtn.Click();
            System.Threading.Thread.Sleep(1000);
            //*[@id="ComboboxInput-apm-name"]
            IWebElement PAYEENAME = webDriver.FindElement(By.Id("ComboboxInput-apm-name"));
            IWebElement Bank = webDriver.FindElement(By.Id("apm-bank"));
            IWebElement Branch = webDriver.FindElement(By.Id("apm-branch"));
            IWebElement Account = webDriver.FindElement(By.Id("apm-account"));
            IWebElement suffix = webDriver.FindElement(By.Id("apm-suffix"));
            IWebElement AddAccountBtn = webDriver.FindElement(By.CssSelector(".js-submit"));
            IWebElement PayeeAddedAlert = webDriver.FindElement(By.XPath("//span[@role='alert']"));

            IWebElement PayeeSearchBox = webDriver.FindElement(By.XPath("//input[@placeholder='Search payees']"));
            string ActualPayee = webDriver.FindElement(By.XPath("//div[@class='Avatar Avatar--dark Avatar--avatarLeft']//p[@class='Avatar-title']")).Text;


            System.Threading.Thread.Sleep(1000);
            PAYEENAME.SendKeys(name);
            PAYEENAME.SendKeys(Keys.Enter);
            System.Threading.Thread.Sleep(1000);
            Bank.SendKeys("02");
            Branch.SendKeys("1234");
            Account.SendKeys("1234567");
            suffix.SendKeys("021");
            System.Threading.Thread.Sleep(1000);

            //4. Click ‘Add’ button
            AddAccountBtn.Click();
            System.Threading.Thread.Sleep(2000);
            //Assert.IsTrue(GenericHelper.IsElementPresend(By.XPath("//*[@id="notification"]/div/span")));
            Assert.That(PayeeAddedAlert.Displayed, Is.True);
            /*string text = webDriver.SwitchTo().Alert().Text;
            Assert.IsTrue(text.Contains("Payee added"));*/

            /* var alert_win = webDriver.SwitchTo().Alert();
            Assert.AreEqual("Payee added", alert_win.Text);*/
            Assert.That(AddBtn.Displayed, Is.True);

            //5. ‘Payee added’ message is displayed,

            Console.WriteLine("text output is " + webDriver.FindElement(By.CssSelector(".inner.js-notification")).Text);
            System.Threading.Thread.Sleep(3000);
            //Assert.AreEqual("Payee added", driver.SwitchTo().Alert().Text.ToString());
            Assert.AreEqual("Payee added", webDriver.FindElement(By.CssSelector(".inner.js-notification")).Text.ToString());

            //payee is added in the list of payees
            var element = webDriver.FindElements(By.CssSelector(".List.List--border"));
            Assert.True(webDriver.PageSource.Contains(name));

            //next part
           /* System.Threading.Thread.Sleep(2000);
            PayeeSearchBox.Click();
            PayeeSearchBox.SendKeys(name);
            System.Threading.Thread.Sleep(2000);*/


            
            
           // Assert.AreEqual(ActualPayee, name, "Strings are not matching");
           // System.Threading.Thread.Sleep(2000);


        }
            

            [TearDown]
        public void Teardown() => webDriver.Quit(); //Close all browser session
    }
}
