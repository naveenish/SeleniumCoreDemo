using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumCoreDemo.Test
{
    class LoginTest
    {
        //Hooks in Nunit
        [Test]
        public void Setup()
        {
            //open browser
            IWebDriver webDriver = new ChromeDriver(@"C:\");
            webDriver.Manage().Window.Maximize();
            //Navigate to site
            webDriver.Navigate().GoToUrl("http://eaapp.somee.com/");

            //Login Identifier
            IWebElement InkLogin = webDriver.FindElement(By.LinkText("Login"));

            //Operation
            InkLogin.Click();

            //define elements
            var textusername = webDriver.FindElement(By.Name("UserName"));
            var textpassword = webDriver.FindElement(By.Name("Password"));
            var loginbutton = webDriver.FindElement(By.XPath("//input[@value='Log in']"));
           // var InkManageUsers = webDriver.FindElement(By.XPath("//input[@value='Manage Users']"));
            //var InkEmployeeList = webDriver.FindElement(By.XPath("//input[@value='Employee List']"));

            //operations
            textusername.SendKeys("admin");
            textpassword.SendKeys("password");
            loginbutton.Click();
            //var InkManageUsers = webDriver.FindElement(By.LinkText("//input[@value='About']"));
            //var visitnow = webDriver.FindElement(By.LinkText("//input[@value='Visit now »']"));
            //var InkEmployeeList = webDriver.FindElement(By.LinkText("//input[@value='Employee List']"));
            var InkEmployeeList = webDriver.FindElement(By.XPath("/html/body/div[1]/div/div[2]/ul/li[3]/a"));
            
            //var InkEmployeeList = webDriver.FindElement(By.LinkText("//input[@value='About']"));
            //About

            //assertion
            // Assert.That(InkManageUsers.Displayed, Is.True);
            Assert.That(InkEmployeeList.Displayed, Is.True);
            //Assert.That(visitnow.Displayed, Is.True);
            System.Threading.Thread.Sleep(3000);

            //webDriver.Close();
            webDriver.Quit();
            
        }
    }
}
