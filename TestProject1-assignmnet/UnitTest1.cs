//using OpenQA.Selenium;
//using OpenQA.Selenium.Chrome;
//using NUnit.Framework;
//using System;
//using System.Threading;

//namespace TestProject1_assignmnet
//{
//    public class Tests
//    {


//        [SetUp]
//        public void Setup()
//        {

//        }

//        [Test]
//        public void TestCloudQAFormFields()
//        {
//            IWebDriver driver = new ChromeDriver();
//            driver.Manage().Window.Maximize();
//            driver.Navigate().GoToUrl("https://app.cloudqa.io/home/AutomationPracticeForm");

//            // Wait for form to load
//            Thread.Sleep(2000);

//            // Test Field 1: First Name
//            var firstName = driver.FindElement(By.Name("First Name"));
//            firstName.Clear();
//            firstName.SendKeys("Harsh");

//            // Test Field 2: Last Name
//            var lastName = driver.FindElement(By.Name("Last Name"));
//            lastName.Clear();
//            lastName.SendKeys("Kumar");

//            // Test Field 3: Gender Radio Button
//            var maleRadio = driver.FindElement(By.CssSelector("input[value='Male']"));
//            if (!maleRadio.Selected)
//                maleRadio.Click();

//            // Optional: Add wait to visually verify
//            Thread.Sleep(2000);

//            // If no exceptions, test passes
//            Assert.Pass("Form fields were successfully filled.");

//        }

//        //[TearDown]
//        //public void Teardown()
//        //{
//        //    driver.Quit();
//        //}
//    }
//}


//using NUnit.Framework;
//using OpenQA.Selenium;
//using OpenQA.Selenium.Chrome;
//using OpenQA.Selenium.Support.UI;
//using System;

//namespace TestProject1_assignment
//{
//    public class Tests
//    {
//        private IWebDriver driver;

//        [SetUp]
//        public void Setup()
//        {
//            driver = new ChromeDriver();  // ✅ No 'var' here
//            driver.Manage().Window.Maximize();
//            driver.Navigate().GoToUrl("https://app.cloudqa.io/home/AutomationPracticeForm");
//        }


//        [Test]
//        public void TestFormFields()
//        {
//            // 1. Enter text in First Name field
//            var firstNameField = driver.FindElement(By.XPath("//label[text()='First Name']"));
//            firstNameField.Clear();
//            firstNameField.SendKeys("Harsh");

//            // 2. Select 'Male' radio button by associated label text
//            var genderMaleLabel = driver.FindElement(By.CssSelector("input[value='Male']"));
//            genderMaleLabel.Click();

//            // 3. Check the 'Reading' checkbox
//            var lirstNameField = driver.FindElement(By.XPath("//label[text()='Last Name']"));
//            lirstNameField.Clear();
//            lirstNameField.SendKeys("Kumar");

//            // Add assertions (basic check if the values are set correctly)
//            Assert.AreEqual("Harsh", firstNameField.GetAttribute("value"));
//            //Assert.IsTrue(driver.FindElement(By.Id("sex-0")).Selected);
//            //Assert.IsTrue(driver.FindElement(By.Id("hobby-2")).Selected);
//        }

//        [TearDown]
//        public void TearDown()
//        {
//            //driver.Quit(); // ✅ Properly dispose the driver
//        }

//    }
//}

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
