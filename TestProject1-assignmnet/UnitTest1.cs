using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace TestProject1_assignment
{
    public class Tests
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        [SetUp]
        public void Setup()
        {
            // Initialize ChromeDriver
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://app.cloudqa.io/home/AutomationPracticeForm");

            // Set up an explicit wait to make the script more robust
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        [Test]
        public void TestFormFields()
        {
            // Test Field 1: First Name 
            var firstNameField = wait.Until(driver => driver.FindElement(By.Name("First Name")));
            firstNameField.Clear();
            firstNameField.SendKeys("Harsh");

            // Test Field 2: Last Name -
            var lastNameField = driver.FindElement(By.Name("Last Name"));
            lastNameField.Clear();
            lastNameField.SendKeys("Kumar");

            // Test Field 3: Gender - using input's value with CSS selector
            var maleRadio = driver.FindElement(By.CssSelector("input[value='Male']"));
            if (!maleRadio.Selected)
                maleRadio.Click();

            // Assertions to verify entered values
            Assert.AreEqual("Harsh", firstNameField.GetAttribute("value"));
            Assert.AreEqual("Kumar", lastNameField.GetAttribute("value"));
            Assert.IsTrue(maleRadio.Selected);

            Console.WriteLine("All form fields were successfully filled and verified.");
        }

        [TearDown]
        public void TearDown()
        {
            // Close the browser after test
            driver.Quit();
        }
    }
}
