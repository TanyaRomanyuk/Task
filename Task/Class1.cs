using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;

namespace Nunit
{
    [TestFixture]
    public class Class1
    {
        public IWebDriver driver;
        [SetUp]
        public void SetUp()
        {
            var options = new ChromeOptions();
            options.AddArguments
                (
                    "--start-maximized",
                    "--disable-extensions",
                    "--disable-notifications",
                    "--disable-application-cache"
                );


            driver = new ChromeDriver(options);
            driver.Navigate().GoToUrl("http://automationpractice.com");

            IWebElement LoginButton = driver.FindElement(By.ClassName("login"));
            LoginButton.Click();

            IWebElement login = driver.FindElement(By.Id("email"));
            login.SendKeys("forphotos@gmail.com");

            IWebElement pass = driver.FindElement(By.Id("passwd"));
            pass.SendKeys("fylhsq1");

            var ContactLink = driver.FindElement(By.Id("SubmitLogin"));
            ContactLink.Click();
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }


        [Test]
        public void CheckContact()
        {

            var ContactLink = driver.FindElement(By.Id("contact-link"));
            ContactLink.Click();

            Assert.AreEqual("Contact us - My Store", driver.Title);
        }

        [Test]
        
        public void UpdateData()
        {
            var InformationLink = driver.FindElement(By.ClassName("icon-user"));
            InformationLink.Click();

            var NameLink = driver.FindElement(By.Id("firstname"));
            NameLink.Clear();

            NameLink.SendKeys("Tanya");

            var LastNameLink = driver.FindElement(By.Id("lastname"));
            LastNameLink.Clear();

            LastNameLink.SendKeys("Romanyuk");

            var PassLink = driver.FindElement(By.Id("old_passwd"));
            PassLink.SendKeys("fylhsq1");

            var SaveLink = driver.FindElement(By.Name("submitIdentity"));
            SaveLink.Click();

            var CheckString = driver.FindElement(By.LinkText("Tanya Romanyuk"));
            Assert.AreEqual("Tanya Romanyuk", CheckString.Text);
        }

        

    }
}
