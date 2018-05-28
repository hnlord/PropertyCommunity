using Keys_Onboarding.Global;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Threading;
using static Keys_Onboarding.Global.CommonMethods;

namespace Keys_Onboarding.Pages
{
    class OwnerInspections
    {
        public OwnerInspections()
        {
            PageFactory.InitElements(Driver.driver, this);
        }

        #region WebElements Definition
        //Define skip button
        [FindsBy(How = How.XPath, Using = "/html/body/div[5]/div/div[5]/a[1]")]
        private IWebElement SkipButton { set; get; }

        //Define Owners tab
        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div/div[2]/div[1]")]
        private IWebElement Ownertab { set; get; }

        //Define Inspections tab
        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div/div[2]/div[1]/div/a[7]")]
        private IWebElement InspectionsPage { set; get; }

        //Define Add new inspection button        
        [FindsBy(How = How.XPath, Using = "//*[@id='mainPage']/div[2]/div/div[2]/a")]
        private IWebElement AddNewInspections { set; get; }

        #endregion

        public void Common_methods()
        {
            Driver.wait(5);
            //Click on skip button on popup window  
            SkipButton.Click();
            Thread.Sleep(1000);

            //Click on the Owners tab
            // Debug.Assert(Driver.driver.Title == "Login");

            Ownertab.Click();
            Thread.Sleep(1000);
            //Global.Driver.wait(5);
            //Select properties page
            InspectionsPage.Click();
            Thread.Sleep(1000);
        }

        //Add a new inspection
        internal void AddANewInspection()
        {
            try
            {

                //Calling the common methods
                Common_methods();
                Thread.Sleep(1000);
                
                //Click on the Add new inspecion button
                AddNewInspections.Click();
                Thread.Sleep(2000);

                //Verification
                string ExpectedValue = "Send Request";
                bool isOpenedNewInspectionPage = Driver.driver.PageSource.Contains(ExpectedValue);
                Assert.IsTrue(isOpenedNewInspectionPage);

                SaveScreenShotClass.SaveScreenshot(Driver.driver, "Owner Inspection Add New");

             //   string ActualValue = Driver.driver.FindElement(By.XPath("//*[@id='main-content']/section/div[1]/div/div[3]/div/div[1]/div[2]/div[1]/div[1]/a/h3")).Text;


                //Assert.AreEqual(ExpectedValue, ActualValue);


                if (isOpenedNewInspectionPage)

                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Test Passed, Open New Inspection successfull");

                else
                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Test Failed, Open New Inspection Unsuccessfull");

            }

            catch (Exception e)
            {
                Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Test Failed, Open New Inspection throw an exception", e.Message);
            }
        }
    }
}
