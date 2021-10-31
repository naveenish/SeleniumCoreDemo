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
    class PayeesSortingTest
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
        public void PayeesSortedbyNameTest()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl("https://www.demo.bnz.co.nz/client/");
            driver.FindElement(By.CssSelector(".js-main-menu-button-text .Language__container")).Click();  // click on Menu button
            driver.FindElement(By.CssSelector(".js-main-menu-payees .Language__container")).Click();  // click on Payees                                                                                                 
            

            IList<IWebElement> elements = driver.FindElements(By.XPath("//*[@class='js-payee-name']"));
            var actualList = new List<string>();
            foreach (IWebElement e in elements)
            {
                System.Console.WriteLine(string.Join(", ", e.Text));
                actualList.Add(e.Text);
            }

            var newList = new List<string>(actualList); ;
            actualList.Sort();
            Console.WriteLine(string.Join(", ", actualList));
            if (actualList.SequenceEqual(newList))
            {
                Console.WriteLine("the list is sorted");
            }
            else Console.WriteLine("the list is not sorted");

            driver.FindElement(By.XPath("//span[normalize-space()='Name']")).Click(); // click on Name element
            IList<IWebElement> elementsList = driver.FindElements(By.XPath("//*[@class='js-payee-name']"));
            var actualList2 = new List<string>();
            foreach (IWebElement e in elementsList)
            {
                System.Console.WriteLine(string.Join(", ", e.Text));
                actualList2.Add(e.Text);
            }

            var newList2 = new List<string>(actualList2); ;
            actualList2.Sort();
            Console.WriteLine(string.Join(", ", actualList2));
            if (newList2.SequenceEqual(actualList2))
            {
                Console.WriteLine("the list is sorted");
            }
            else Console.WriteLine("the list is not sorted");

        }


        [TearDown]
        public void Teardown() => driver.Quit(); //Close all browser session
    }
}
