using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace SeleniumCoreDemo
{
    public class Tests
    {
        public object GenericHelper { get; private set; }

        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void Test1()
        {

            

            //Open browser
            IWebDriver webDriver = new ChromeDriver(@"C:\");
            //navigate to url
            webDriver.Navigate().GoToUrl("http://eaapp.somee.com/");

            System.Threading.Thread.Sleep(2000);
            var element = webDriver.FindElement(By.Id("registerLink"));
            element.Click();


            var username = webDriver.FindElement(By.Id("UserName"));
            var password = webDriver.FindElement(By.Id("Password"));
            var confirmpassword = webDriver.FindElement(By.Id("ConfirmPassword"));
            var email = webDriver.FindElement(By.Id("Email"));
            //var register = webDriver.FindElement(By.XPath("/html/body/div[2]/form/div[6]/div/input"));
            var register = webDriver.FindElement(By.XPath("//input[@value='Register']"));

            //var errormessage = webDriver.FindElement(By.XPath("/html/body/div[2]/form/div[1]/ul/li"));
            //var logout = webDriver.FindElement(By.XPath("/html/body/div[1]/div/div[2]/form/ul/li[2]/a"));

            username.SendKeys("ABC123456");
            password.SendKeys("ABCd@9898");
            confirmpassword.SendKeys("ABCd@9898");
            email.SendKeys("email123@test.com");
            System.Threading.Thread.Sleep(1500);
            register.Click();
            System.Threading.Thread.Sleep(1500);
            //Assert.AreEqual();
           // Assert.That(register.Displayed, Is.True);
            //logout.Click();

            System.Threading.Thread.Sleep(1500);
            //errormessage.Text;
            Console.WriteLine("New username is" + username);
            //Assert.AreEqual(actual_msg, expect);

            //Assert.IsTrue(warning.Displayed);
            //Assert.AreEqual(warning, "The UserName must be at least 6 charecters long.", "Strings are not matching");
            // Assert.AreEqual(warning.Text.ToLower(), "The UserName must be at least 6 charecters long.".ToLower());

            System.Threading.Thread.Sleep(1500);

            //try
           // {                String actual_msg = errormessage.Text;
           //     String expect = "The UserName must be at least 6 charecters long";

                // Assert.AreEqual("33333", Ipage.Title);
            //    Assert.AreEqual(actual_msg, expect);
           // }
           // catch (StaleElementException e)
           // {
           // }

            //Console.WriteLine($"Info: {message}");
            //webDriver.FindElement(By.Id("registerLink")).Click;

            //-------------
            // This will capture error message
            // String actual_msg = webDriver.FindElement(By.XPath("/html/body/div[2]/form/div[1]/ul/li")).Text;


            //String actual_msg = errormessage.Text;
            //String expect = "The UserName must be at least 6 charecters long";

            // Assert.AreEqual("33333", Ipage.Title);
            //Assert.AreEqual(actual_msg, expect);


            //-----------
            //webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            //webDriver.Manage().Timeouts().implicitlyWait(30, TimeUnit.SECONDS);


           
            webDriver.Close();
        }

        
    }
}