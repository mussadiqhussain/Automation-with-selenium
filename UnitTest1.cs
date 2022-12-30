using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using static System.Collections.Specialized.BitVector32;

namespace labday5
{
    [Ignore]
    [TestClass]
    public class Task1
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
                //option.AddArguments("no-sandbox");
                option.AddArgument("-start-maximized");
                option.AddArgument("incognito");
                return driver = new ChromeDriver(option);
            }
            else if (browser == "firefoxdriver")
            {

                return driver = new ChromeDriver();
            }
            else if (browser == "internetexplorerdriver")
            {
                return driver = new InternetExplorerDriver();
            }
            else if (browser == "edgedriver")
            {
                return driver = new EdgeDriver();
            }
            return driver;
        }

        [Ignore]
        [TestMethod]
        public void TextBox()
        {
            IWebDriver driver = SeleniumInit("Chrome");
            driver.Url = "https://demoqa.com/";
            IWebElement element1 = driver.FindElement(By.XPath(".//h5[text()='Elements']"));
            scrollToView(driver, element1);
            element1.Click();
            driver.FindElement(By.XPath("//*[@id='item-0']/span")).Click();
            driver.FindElement(By.Id("userName")).SendKeys("tester");
            driver.FindElement(By.Id("userEmail")).SendKeys("tester@gmail.com");
            driver.FindElement(By.Id("currentAddress")).SendKeys("umtcohort");
            driver.FindElement(By.Id("permanentAddress")).SendKeys("umtcohort123");
            IWebElement element2 = driver.FindElement(By.Id("submit"));
            scrollToView(driver, element2);
            element2.Click();
            driver.Close();
        }
        [Ignore]
        [TestMethod]
        public void CheckBox()
        {
            IWebDriver driver = SeleniumInit("Chrome");
            driver.Url = "https://demoqa.com/";
            IWebElement element1 = driver.FindElement(By.XPath(".//h5[text()='Elements']"));
            scrollToView(driver, element1);
            element1.Click();
            driver.FindElement(By.Id("item-1")).Click();
            IWebElement home = driver.FindElement(By.XPath(".//button[@title='Expand all']"));
            scrollToView(driver, home);
            home.Click();
            driver.FindElement(By.XPath(".//span[text()='Desktop']")).Click();
            driver.FindElement(By.XPath(".//span[text()='Documents']")).Click();
            driver.FindElement(By.XPath(".//span[text()='Downloads']")).Click();
            driver.Close();
        }
        [Ignore]
        [TestMethod]
        public void RadioButton()
        {
            IWebDriver driver = SeleniumInit("Chrome");
            driver.Url = "https://demoqa.com/";
            IWebElement element1 = driver.FindElement(By.XPath(".//h5[text()='Elements']"));
            scrollToView(driver, element1);
            element1.Click();
            driver.FindElement(By.Id("item-2")).Click();
            driver.FindElement(By.XPath(".//label[@for='yesRadio']")).Click();
            driver.FindElement(By.XPath(".//label[@for='impressiveRadio']")).Click();
            driver.Close();
        }
        [Ignore]
        [TestMethod]
        public void WebTables()
        {
            IWebDriver driver = SeleniumInit("Chrome");
            driver.Url = "https://demoqa.com/";
            IWebElement element1 = driver.FindElement(By.XPath(".//h5[text()='Elements']"));
            scrollToView(driver, element1);
            element1.Click();
            driver.FindElement(By.XPath("//*[@id='item-3']/span")).Click();
            driver.FindElement(By.Id("addNewRecordButton")).Click();
            driver.FindElement(By.Id("firstName")).SendKeys("umt");
            driver.FindElement(By.Id("lastName")).SendKeys("johartown");
            driver.FindElement(By.Id("userEmail")).SendKeys("umtcohort@gmail.com");
            driver.FindElement(By.Id("age")).SendKeys("55");
            driver.FindElement(By.Id("salary")).SendKeys("500000");
            driver.FindElement(By.Id("department")).SendKeys("IT");
            driver.FindElement(By.Id("submit")).Click();
        }

        [Ignore]
        [TestMethod]
        public void Button()
        {
            IWebDriver driver = SeleniumInit("Chrome");
            driver.Url = "https://demoqa.com/";
            IWebElement element1 = driver.FindElement(By.XPath(".//h5[text()='Elements']"));
            scrollToView(driver, element1);
            element1.Click();
            IWebElement element_button = driver.FindElement(By.Id("item-4"));
            scrollToView(driver, element_button);
            element_button.Click();
            Actions actions = new Actions(driver);
            actions.DoubleClick(driver.FindElement(By.Id("doubleClickBtn"))).Build().Perform();
            actions.ContextClick(driver.FindElement(By.Id("rightClickBtn"))).Build().Perform();
            IWebElement clickme = driver.FindElement(By.XPath("//div[@class='mt-4'][2]/button"));
            scrollToView(driver, clickme);
            clickme.Click();
            Thread.Sleep(1000);
        }
        [Ignore]
        [TestMethod]
        public void BrowseWindows()
        {
            IWebDriver driver = SeleniumInit("Chrome");
            driver.Url = "https://demoqa.com/";
            IWebElement AlertsFrameWindows = driver.FindElement(By.XPath("//*[@id='app']/div/div/div[2]/div/div[3]"));
            scrollToView(driver, AlertsFrameWindows);
            AlertsFrameWindows.Click();
            IWebElement BrowserWindow = driver.FindElement(By.XPath(".//span[text()='Browser Windows']"));
            scrollToView(driver, BrowserWindow);
            BrowserWindow.Click();
            driver.FindElement(By.XPath(".//button[@id='tabButton']")).Click();
            driver.SwitchTo().Window(driver.WindowHandles[1]);
            string text = driver.FindElement(By.Id("sampleHeading")).Text;
            Console.WriteLine(text);
            Thread.Sleep(5000);
            driver.Close();
            driver.SwitchTo().Window(driver.WindowHandles[0]);
            driver.FindElement(By.XPath(".//button[@id='windowButton']")).Click();
            driver.SwitchTo().Window(driver.WindowHandles[1]);
            string text1 = driver.FindElement(By.Id("sampleHeading")).Text;
            Console.WriteLine(text1);
            driver.Close();
            driver.SwitchTo().Window(driver.WindowHandles[0]);
            driver.FindElement(By.XPath(".//button[@id='messageWindowButton']")).Click();
            driver.SwitchTo().Window(driver.WindowHandles[1]);
            Thread.Sleep(5000);
            driver.Quit();
        }
        [Ignore]
        [TestMethod]
        public void Frames()
        {
            IWebDriver driver = SeleniumInit("Chrome");
            driver.Url = "https://demoqa.com/";
            IWebElement AlertsFrameWindows = driver.FindElement(By.XPath(".//div[@class='card mt-4 top-card'][3]"));
            scrollToView(driver, AlertsFrameWindows);
            AlertsFrameWindows.Click();
            IWebElement Frame = driver.FindElement(By.XPath(".//span[text()='Frames']"));
            scrollToView(driver, Frame);
            Frame.Click();
            IWebElement frame1 = driver.FindElement(By.Id("frame1"));
            driver.SwitchTo().Frame(frame1);
            Thread.Sleep(6000);
            string frame1text = driver.FindElement(By.XPath(".//h1[@id='sampleHeading']")).Text;
            Console.WriteLine("frame1 text is: " + frame1text);
            driver.SwitchTo().DefaultContent();
            IWebElement frame2 = driver.FindElement(By.Id("frame2"));
            scrollToView(driver, frame2);
            driver.SwitchTo().Frame(frame2);
            string frame2text = driver.FindElement(By.XPath(".//h1[@id='sampleHeading']")).Text;
            Console.WriteLine("frame1 text is: " + frame2text);
        }

        [Ignore]
        [TestMethod]
        public void NestedFrames()
        {
            IWebDriver driver = SeleniumInit("Chrome");
            driver.Url = "https://demoqa.com/";
            IWebElement AlertsFrameWindows = driver.FindElement(By.XPath("//*[@id='app']/div/div/div[2]/div/div[3]"));
            scrollToView(driver, AlertsFrameWindows);
            AlertsFrameWindows.Click();
            IWebElement NestedFrame = driver.FindElement(By.XPath(".//span[text()='Nested Frames']"));
            scrollToView(driver, NestedFrame);
            NestedFrame.Click();
            IWebElement frame1 = driver.FindElement(By.Id("frame1"));
            driver.SwitchTo().Frame(frame1);
            string parentframe = driver.FindElement(By.TagName("body")).Text;
            Console.WriteLine("frame1 text is: " + parentframe);
            driver.SwitchTo().Frame(0);
            string childframe = driver.FindElement(By.TagName("p")).Text;
            Console.WriteLine("frame1 text is: " + childframe);
        }
        [Ignore]
        [TestMethod]
        public void ModelDialogs()
        {
            IWebDriver driver = SeleniumInit("Chrome");
            driver.Url = "https://demoqa.com/";
            IWebElement AlertsFrameWindows = driver.FindElement(By.XPath("//*[@id='app']/div/div/div[2]/div/div[3]"));
            scrollToView(driver, AlertsFrameWindows);
            AlertsFrameWindows.Click();
            IWebElement ModelDialogs = driver.FindElement(By.XPath(".//span[text()='Modal Dialogs']"));
            scrollToView(driver, ModelDialogs);
            ModelDialogs.Click();
            driver.FindElement(By.Id("showSmallModal")).Click();
            Thread.Sleep(3000);

            string modal1text = driver.FindElement(By.XPath(".//div[@class='modal-body']")).Text;
            Console.WriteLine("modal1 text is: " + modal1text);
            driver.FindElement(By.Id("closeSmallModal")).Click();
            driver.FindElement(By.Id("showLargeModal")).Click();
            Thread.Sleep(3000);

            string modal2text = driver.FindElement(By.XPath(".//div[@class='modal-body']")).Text;
            Console.WriteLine("modal2 text is: " + modal2text);
            driver.FindElement(By.Id("closeLargeModal")).Click();
            driver.Quit();

        }
        [Ignore]
        [TestMethod]
        public void bookstoresignin()
        {
            IWebDriver driver = SeleniumInit("Chrome");
            driver.Url = "https://demoqa.com/";
            Thread.Sleep(9000);
            IWebElement bookstorebutton = driver.FindElement(By.XPath(".//div[@class='card mt-4 top-card'][6]"));
            scrollToView(driver, bookstorebutton);
            bookstorebutton.Click();
            Thread.Sleep(5000);
            driver.FindElement(By.Id("login")).Click();
            driver.FindElement(By.Id("newUser")).Click();
            driver.FindElement(By.Id("firstname")).SendKeys("mussadiq");
            driver.FindElement(By.Id("lastname")).SendKeys("hussain");
            driver.FindElement(By.Id("userName")).SendKeys("mussadiqhussain024");
            driver.FindElement(By.Id("password")).SendKeys("b00T@camP");
            Thread.Sleep(30000);
            driver.FindElement(By.Id("register")).Click();

        }
        [TestMethod]
        public void bookstorelogin()
        {
            IWebDriver driver = SeleniumInit("Chrome");
            driver.Url = "https://demoqa.com/";
            Thread.Sleep(9000);
            IWebElement bookstorebutton = driver.FindElement(By.XPath(".//div[@class='card mt-4 top-card'][6]"));
            scrollToView(driver, bookstorebutton);
            bookstorebutton.Click();
            Thread.Sleep(5000);
            driver.FindElement(By.Id("login")).Click();
            driver.FindElement(By.Id("userName")).SendKeys("mussadiqhussain024");
            driver.FindElement(By.Id("password")).SendKeys("b00T@camP");
            Thread.Sleep(30000);
            driver.FindElement(By.Id("login")).Click();
        }
    }
    [Ignore]
    [TestClass]
    public class Task2
    {
        public void ScrollToView(IWebDriver driver, IWebElement elements)
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
                option.AddArgument("-start-maximized");
                option.AddArgument("incognito");
                return driver = new ChromeDriver(option);
            }
            else if (browser == "firefoxdriver")
            {

                return driver = new ChromeDriver();
            }
            else if (browser == "internetexplorerdriver")
            {
                return driver = new InternetExplorerDriver();
            }
            else if (browser == "edgedriver")
            {
                return driver = new EdgeDriver();
            }
            return driver;
        }
        [TestMethod]
        public void formfilling()
        {
            IWebDriver driver = SeleniumInit("chrome");
            driver.Url = "https://fs2.formsite.com/meherpavan/form2/index.html?1537702596407";
            driver.FindElement(By.Id("RESULT_TextField-1")).SendKeys("mussadiq");
            driver.FindElement(By.Id("RESULT_TextField-2")).SendKeys("hussain");
            driver.FindElement(By.Id("RESULT_TextField-3")).SendKeys("03211234567");
            driver.FindElement(By.Id("RESULT_TextField-4")).SendKeys("Pakistan");
            driver.FindElement(By.Id("RESULT_TextField-5")).SendKeys("Lahore");
            driver.FindElement(By.Id("RESULT_TextField-6")).SendKeys("mussadiqhussain337@gmail.com");
            IWebElement gender = driver.FindElement(By.XPath(".//label[@for='RESULT_RadioButton-7_0']"));
            ScrollToView(driver, gender);
            gender.Click();
            IWebElement day = driver.FindElement(By.XPath(".//label[@for='RESULT_CheckBox-8_0']"));
            ScrollToView(driver, day);
            day.Click();
            var dropdownlocation = driver.FindElement(By.Id("RESULT_RadioButton-9"));
            var selectdropdown = new SelectElement(dropdownlocation);
            //selectdropdown.SelectByText("Morning");
            selectdropdown.SelectByIndex(2);
            driver.FindElement(By.Id("RESULT_FileUpload-10")).SendKeys("E:\\upload.PNG");
        }
    }
    [TestClass]
    public class Task3
    {
        public void ScrollToView(IWebDriver driver, IWebElement elements)
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
                option.AddArgument("-start-maximized");
                option.AddArgument("incognito");
                return driver = new ChromeDriver(option);
            }
            else if (browser == "firefoxdriver")
            {

                return driver = new ChromeDriver();
            }
            else if (browser == "internetexplorerdriver")
            {
                return driver = new InternetExplorerDriver();
            }
            else if (browser == "edgedriver")
            {
                return driver = new EdgeDriver();
            }
            return driver;
        }
        [TestMethod]
        public void formfilling()
        {
            IWebDriver driver = SeleniumInit("chrome");
            driver.Url = "https://www.tutorialspoint.com/selenium/selenium_automation_practice.htm";
            IWebElement element1 = driver.FindElement(By.XPath(".//input[@name='firstname']"));
            ScrollToView(driver, element1);
            element1.SendKeys("mussadiq");
            Thread.Sleep(2000);
            IWebElement element2 = driver.FindElement(By.XPath(".//input[@name='lastname']"));
            ScrollToView(driver, element2);
            element2.SendKeys("hussain");
            IWebElement sex = driver.FindElement(By.XPath(".//input[@value='Male']"));
            ScrollToView(driver, sex);
            sex.Click();
            driver.FindElement(By.XPath(".//input[@value='2']")).Click();
            driver.FindElement(By.XPath(".//tr[5]/td/input[@type='text']")).SendKeys("20-12-12");
            IWebElement manual = driver.FindElement(By.XPath(".//input[@value='Manual Tester']"));
            ScrollToView(driver, manual);
            manual.Click();
            driver.FindElement(By.XPath(".//input[@type='file]")).SendKeys("E:\\upload.PNG");
            driver.FindElement(By.XPath(".//input[@value='Selenium IDE']")).Click();
            var element = driver.FindElement(By.XPath(".//select[@name='continents']"));
            var selectdropdown = new SelectElement(element);
            selectdropdown.SelectByIndex(3);
            IWebElement element11 = driver.FindElement(By.XPath(".//button[@name=\"submit\"]"));
            ScrollToView(driver, element11);
            element11.Click();

        }
    }

    [TestClass]
    public class Task4
    {
        public void ScrollToView(IWebDriver driver, IWebElement elements)
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
                option.AddArgument("-start-maximized");
                option.AddArgument("incognito");
                return driver = new ChromeDriver(option);
            }
            else if (browser == "firefoxdriver")
            {

                return driver = new ChromeDriver();
            }
            else if (browser == "internetexplorerdriver")
            {
                return driver = new InternetExplorerDriver();
            }
            else if (browser == "edgedriver")
            {
                return driver = new EdgeDriver();
            }
            return driver;
        }
        
        [TestMethod]
        public void talha()
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
            driver.FindElement(By.XPath(".//button[@id='submit']")).Click();
        }
    }
}

