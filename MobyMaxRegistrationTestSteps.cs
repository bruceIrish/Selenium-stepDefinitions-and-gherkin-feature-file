using System;
using System.Configuration;
using System.Diagnostics;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Safari;
using TechTalk.SpecFlow;

namespace MobyRegistrationDemo
{
    [Binding]
    public class MobyMaxRegistrationSteps
    {
        IWebDriver driver;
        private string OutputBrowserName;
        
      
        [Given(@"I have navigated to URL (.*) in browser (.*)")]
        public void GivenIHaveNavigatedToTheMobyMaxRegistrationPageInBrowser(string url, string browser)
        {
            if (browser == "Chrome")
            {
                driver = new ChromeDriver(@"C:\Users\310177086\Documents\Visual Studio 2013\Projects\MobyRegistrationDemo");
            }
            else if (browser == "Safari")
            {
                driver = new SafariDriver();
            }
            else if (browser == "Firefox")
            {
                driver = new FirefoxDriver();
            }
            else if (browser == "IE")
            {
                driver = new InternetExplorerDriver(@"C:\Users\310177086\Documents\Visual Studio 2013\Projects\MobyRegistrationDemo");

            }

            OutputBrowserName = browser;
            driver.Manage().Timeouts().SetScriptTimeout(TimeSpan.FromSeconds(10));
            driver.Navigate().GoToUrl(url);

        }


        [When(@"I have entered firstname (.*) into (.*) and lastname (.*) into (.*)")]
        public void WhenIHaveEnteredFirstAndLastName(string firstNameText, string firstNameField, string lastNameText, string lastNameField)
        {
            EnterTextIntoTextBox(firstNameText, firstNameField);
            EnterTextIntoTextBox(lastNameText, lastNameField);
        }

        [When(@"I have entered educator (.*) into (.*) of attribute (.*)")]
        public void WhenIHaveEnteredEducator(string educatorType, string educatorCheckBoxLocation, string stateAttribute)
        {
          
            if (!driver.FindElement(By.XPath(educatorCheckBoxLocation)).Displayed)
            {
                IWebElement eduCheckImg = driver.FindElement(By.XPath(educatorCheckBoxLocation));
                eduCheckImg.Click();
            }
            
        }

        [When(@"I have entered zipcode (.*) into (.*) and school (.*) into (.*)")]
        public void WhenIHaveEnteredZipCodeAndSchool(string zipCode, string zipCodeField, string schoolId, string schoolField)
        {
            EnterTextIntoTextBox(zipCode, zipCodeField);

            //click school dropdown
            driver.FindElement(By.XPath(schoolField)).Click();

            Thread.Sleep(1000);
            //Search
            driver.FindElement(By.Id(schoolId)).Click();

        }

        [When(@"I have entered zipcode (.*) into (.*) and click the school (.*) containing (.*)")]
        public void WhenIHaveEnteredZipCodeAndCheckedSchool(string zipCode, string zipCodeField, string schoolField, string listOfSchools)
        {
            EnterTextIntoTextBox(zipCode, zipCodeField);

            //click school dropdown
            driver.FindElement(By.XPath(schoolField)).Click();

            Thread.Sleep(1000);
            
            //Search In progress

            SearchSchoolList(schoolField, listOfSchools);

        }

        [When(@"I have entered email address (.*) into (.*) and password (.*) into (.*)")]
        public void WhenIHaveEnteredEmailAdress(string email, string emailField, string password, string passwordField)
        {
            EnterTextIntoTextBox(email, emailField);
            EnterTextIntoTextBox(password, passwordField);
        }

        [When(@"I press the Register button identified by (.*)")]
        public void WhenIPressAdd(string registerButtonLocation)
        {
            driver.FindElement(By.XPath(registerButtonLocation)).Click();
        }

        [Then(@"the result welcome page identified by dismissing the modal (.*) contains title (.*) matching (.*)(.*) and URL is (.*)")]
        public void TheResultWelcomePageIdentifiedBy(string xButtonOnModal, string welcomeBanner, string firstName, string lastName, string expectedURL)
        {

            Thread.Sleep(2000);
            
            //wait for page to load after clicking register
            int counter = 0;
            bool continueLoop = true;

            while (continueLoop && counter < 10)
            {
                try
                {
                    IWebElement xModal = driver.FindElement(By.XPath(xButtonOnModal));

                    if (xModal.Displayed)
                    {
                        xModal.Click();
                        continueLoop = false;
                    }

                    
                }
                catch (OpenQA.Selenium.NoSuchElementException)
                {
                    driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(2));
                    counter++;
                    if (counter == 9)
                    {
                        TakeScreenshot("Fail");
                        Assert.Fail();
                    }
                }
            }

           
            string actualURL = driver.Url;
            string welcomeStringActual = driver.FindElement(By.XPath(welcomeBanner)).Text;
            string welcomeStringExpected = "Welcome: " + firstName + " " + lastName;
            welcomeStringExpected = welcomeStringExpected.Trim();
            
           
            if (actualURL.Contains(expectedURL) && welcomeStringActual.Equals(welcomeStringExpected))
            {
                TakeScreenshot("Passed");
                driver.Quit();
                Assert.Pass();
                
            }
            else
            {
               Debug.Print("ActualURL: " + actualURL + " Actual Welcome mssg: " + welcomeStringActual);
               Debug.Print("ExpectedURL: " + expectedURL + " Expec Welcome mssg: " + welcomeStringExpected);
               TakeScreenshot("Failed");
                driver.Quit();
                Assert.Fail();
            }
        }

        
        //Helper methods

        //Find Textbox by xpath, clear it, write text into it.
        public void EnterTextIntoTextBox(string fieldText, string xpath)
        {
            IWebElement textField = driver.FindElement(By.XPath(xpath));
            textField.Clear();
            textField.SendKeys(fieldText);
            
        }

        public void TakeScreenshot(string PassOrFail)
        {
            try
            {
                
                Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
                string scenarioTagData = ScenarioContext.Current.ScenarioInfo.Title;
                ss.SaveAsFile(ConfigurationSettings.AppSettings["ScreenShotFilePath"]+"_"+scenarioTagData+PassOrFail+"_in"+"_" +OutputBrowserName+".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public void SearchSchoolList(string actualControl, string expectedList)
        {
            //todo
        }
    }
}
