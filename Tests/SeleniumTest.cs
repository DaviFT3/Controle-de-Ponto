//using System;
//using System.Text;
//using System.Text.RegularExpressions;
//using System.Threading;
//using NUnit.Framework;
//using OpenQA.Selenium;
//using OpenQA.Selenium.Chrome;
//using OpenQA.Selenium.Support.UI;

//namespace Tests
//{
//    [TestFixture]
//    public class UntitledTestCase
//    {
//        private IWebDriver driver;
//        private StringBuilder verificationErrors;
//        private string baseURL;
//        private bool acceptNextAlert = true;

//        [SetUp]
//        public void SetupTest()
//        {
//            driver = new ChromeDriver();
//            baseURL = "https://www.google.com/";
//            verificationErrors = new StringBuilder();
//        }

//        [TearDown]
//        public void TeardownTest()
//        {
//            try
//            {
//                driver.Quit();
//            }
//            catch (Exception)
//            {
//                // Ignore errors if unable to close the browser
//            }
//            Assert.AreEqual("", verificationErrors.ToString());
//        }

//        [Test]
//        public void TheUntitledTestCaseTest()
//        {
//            driver.Navigate().GoToUrl("http://localhost:4200/#/login");
//            driver.FindElement(By.XPath("//input[@type='email']")).Click();
//            driver.FindElement(By.XPath("//input[@type='email']")).Clear();
//            driver.FindElement(By.XPath("//input[@type='email']")).SendKeys("davi@gmail.com");
//            driver.FindElement(By.XPath("//input[@type='password']")).Clear();
//            driver.FindElement(By.XPath("//input[@type='password']")).SendKeys("12345");
//            driver.FindElement(By.CssSelector(".ng-valid")).Submit();
//            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Matenha-me conectado'])[1]/following::button[1]")).Click();
//        }
//        private bool IsElementPresent(By by)
//        {
//            try
//            {
//                driver.FindElement(by);
//                return true;
//            }
//            catch (NoSuchElementException)
//            {
//                return false;
//            }
//        }

//        private bool IsAlertPresent()
//        {
//            try
//            {
//                driver.SwitchTo().Alert();
//                return true;
//            }
//            catch (NoAlertPresentException)
//            {
//                return false;
//            }
//        }

//        private string CloseAlertAndGetItsText()
//        {
//            try
//            {
//                IAlert alert = driver.SwitchTo().Alert();
//                string alertText = alert.Text;
//                if (acceptNextAlert)
//                {
//                    alert.Accept();
//                }
//                else
//                {
//                    alert.Dismiss();
//                }
//                return alertText;
//            }
//            finally
//            {
//                acceptNextAlert = true;
//            }
//        }
//    }
//}

