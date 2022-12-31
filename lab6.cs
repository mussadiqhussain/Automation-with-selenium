using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using static System.Collections.Specialized.BitVector32;

namespace labday6
{
    [TestClass]
    public class UnitTest1
    {
        public void scrollToView(IWebDriver driver, IWebElement elements)
        {
            IJavaScriptExecutor je = (IJavaScriptExecutor)driver;
            je.ExecuteScript("arguments[0].scrollIntoView(true);", elements);
        }

        public IWebDriver SeleniumInit(string browser)
        {
            browser = browser.ToLower();
            IWebDriver driver = null;
            if (browser == "chrome")
            {
                ChromeOptions option = new ChromeOptions();
                option.AddArguments("no-sandbox");
                option.AddArguments("-start-maximized");
                option.AddArguments("incognito");
                return driver = new ChromeDriver(option);
            }
            else if (browser == "firefox")
            {
                FirefoxOptions option = new FirefoxOptions();
                option.AddArgument("-private");

                driver = new FirefoxDriver(option);
                driver.Manage().Window.Maximize();

                return driver;
            }
            else if (browser == "internetexplorer")
            {
                InternetExplorerOptions option = new InternetExplorerOptions();
                return driver = new InternetExplorerDriver(option);
            }
            else if (browser == "edge")
            {
                EdgeOptions option = new EdgeOptions();
                option.AddArgument("incognito");
                return driver = new EdgeDriver(option);
            }
            return driver;
        }
        
        [TestMethod]
        public void TestMethod1()
        {
            IWebDriver driver = SeleniumInit("chrome");
            driver.Url = "https://demoqa.com/";

            IWebElement element = driver.FindElement(By.XPath(".//div[@class='card mt-4 top-card'][2]"));
            scrollToView(driver, element);
            element.Click();
            driver.FindElement(By.XPath(".//span[text()='Practice Form']")).Click();
            driver.FindElement(By.Id("firstName")).SendKeys("mussadiq");
            driver.FindElement(By.Id("lastName")).SendKeys("hussain");
            driver.FindElement(By.Id("userEmail")).SendKeys("mussadiqhussain337@gmail.com");
            driver.FindElement(By.XPath(".//label[@for='gender-radio-1']")).Click();
            driver.FindElement(By.Id("userNumber")).SendKeys("0321123456");
            IJavaScriptExecutor je1 = (IJavaScriptExecutor)driver;
            je1.ExecuteScript("document.querySelector('#dateOfBirthInput').value='4/11/2000'");
            IWebElement subject = driver.FindElement(By.XPath(".//input[@id='subjectsInput']"));
            scrollToView(driver, subject);
            subject.SendKeys("Maths");
            Thread.Sleep(1000);
            subject.SendKeys(Keys.Enter);
            IWebElement checkbox = driver.FindElement(By.XPath("//div[@class='custom-control custom-checkbox custom-control-inline'][1]//label"));
            scrollToView(driver, checkbox);
            checkbox.Click();
            driver.FindElement(By.XPath(".//input[@id='uploadPicture']")).SendKeys("E:\\upload.png");
            ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile("E:\\seleniumss.png", ScreenshotImageFormat.Png);
            driver.FindElement(By.Id("currentAddress")).SendKeys("umt cohot");
        }
        
        [TestMethod]
        public void TestMethod2()
        {
            IWebDriver driver = SeleniumInit("FireFox");
            driver.Url = "https://fs2.formsite.com/meherpavan/form2/index.html?1537702596407";
            driver.FindElement(By.Id("RESULT_TextField-1")).SendKeys("mussadiq");
            driver.FindElement(By.Id("RESULT_TextField-2")).SendKeys("hussain");
            driver.FindElement(By.Id("RESULT_TextField-3")).SendKeys("03211234567");
            driver.FindElement(By.Id("RESULT_TextField-4")).SendKeys("Pakistan");
            driver.FindElement(By.Id("RESULT_TextField-5")).SendKeys("Lahore");
            driver.FindElement(By.Id("RESULT_TextField-6")).SendKeys("mussadiqhussain337@gmail.com");
            IWebElement gender = driver.FindElement(By.XPath(".//label[@for='RESULT_RadioButton-7_0']"));
            scrollToView(driver, gender);
            gender.Click();
            IWebElement day = driver.FindElement(By.XPath(".//label[@for='RESULT_CheckBox-8_0']"));
            scrollToView(driver, day);
            day.Click();
            var dropdownlocation = driver.FindElement(By.Id("RESULT_RadioButton-9"));
            var selectdropdown = new SelectElement(dropdownlocation);
            //selectdropdown.SelectByText("Morning");
            selectdropdown.SelectByIndex(2);
            driver.FindElement(By.Id("RESULT_FileUpload-10")).SendKeys("E:\\upload.PNG");
            ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile("E:\\seleniumss.png", ScreenshotImageFormat.Png);
        }

        
        [TestMethod]
        public void TestMethod3()
        {
            IWebDriver driver = SeleniumInit("Edge");
            driver.Url = "https://www.tutorialspoint.com/selenium/selenium_automation_practice.htm";
            IWebElement element1 = driver.FindElement(By.XPath(".//input[@name='firstname']"));
            scrollToView(driver, element1);
            element1.SendKeys("mussadiq");
            Thread.Sleep(2000);
            IWebElement element2 = driver.FindElement(By.XPath(".//input[@name='lastname']"));
            scrollToView(driver, element2);
            element2.SendKeys("hussain");
            IWebElement sex = driver.FindElement(By.XPath(".//input[@value='Male']"));
            scrollToView(driver, sex);
            sex.Click();
            driver.FindElement(By.XPath(".//input[@value='2']")).Click();
            driver.FindElement(By.XPath(".//tr[5]/td/input[@type='text']")).SendKeys("20-12-12");
            IWebElement manual = driver.FindElement(By.XPath(".//input[@value='Manual Tester']"));
            scrollToView(driver, manual);
            manual.Click();
            driver.FindElement(By.XPath(".//input[@type='file]")).SendKeys("E:\\upload.PNG");
            driver.FindElement(By.XPath(".//input[@value='Selenium IDE']")).Click();
            var element = driver.FindElement(By.XPath(".//select[@name='continents']"));
            var selectdropdown = new SelectElement(element);
            selectdropdown.SelectByIndex(3);
            ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile("E:\\seleniumss.png", ScreenshotImageFormat.Png);
            IWebElement element11 = driver.FindElement(By.XPath(".//button[@name=\"submit\"]"));
            scrollToView(driver, element11);
            element11.Click();
        }
        [TestMethod]
        public void Method4()
        {
            IWebDriver driver = SeleniumInit("chrome");
            driver.Url = "https://www.techlistic.com/p/selenium-practice-form.html";
            ChromeOptions option = new ChromeOptions();
            driver.FindElement(By.XPath(".//input[@name='firstname']")).SendKeys("mussadiq");
            driver.FindElement(By.XPath(".//input[@name='lastname']")).SendKeys("hussain");
            driver.FindElement(By.XPath(".//input[@value='Male']")).Click();
            driver.FindElement(By.XPath(".//input[@id='exp-1']")).Click();
            driver.FindElement(By.XPath(".//input[@id='datepicker']")).SendKeys("12-12-12");
            driver.FindElement(By.XPath(".//input[@id='profession-0']")).Click();
            driver.FindElement(By.XPath(".//input[@id='tool-0']")).Click();
            driver.FindElement(By.XPath(".//select[@id='continents']")).Click();
            driver.FindElement(By.XPath(".//input[@id='photo']")).SendKeys("E:\\upload.PNG");
            ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile("E:\\seleniumss.png", ScreenshotImageFormat.Png);
            driver.FindElement(By.XPath(".//button[@id='submit']")).Click();
        }

    }
}


