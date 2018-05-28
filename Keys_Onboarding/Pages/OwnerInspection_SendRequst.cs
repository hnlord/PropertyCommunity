using Keys_Onboarding.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Threading;

namespace Keys_Onboarding.Pages
{
    class OwnerInspection_SendRequst
    {
        public OwnerInspection_SendRequst()
        {
            PageFactory.InitElements(Driver.driver, this);
        }

        #region WebElements Definition
        //Define Property drop down list
        [FindsBy(How = How.XPath, Using = "//*[@id='main-content']/section/div/div[1]/div[1]/div/div")]
        private IWebElement Property { set; get; }

        //Define Tenant  drop down list
        [FindsBy(How = How.XPath, Using = "//*[@id='main-content']/section/div/div[1]/div[2]/div")]
        private IWebElement Tenant { set; get; }

        //Define Type drop down list
        [FindsBy(How = How.XPath, Using = "//*[@id='main-content']/section/div/div[1]/div[3]/div[1]/select")]
        private IWebElement Type { set; get; }

        //Define Description  textbox        
        [FindsBy(How = How.XPath, Using = "//*[@id='main-content']/section/div/div[1]/div[4]/form/div/textarea")]
        private IWebElement Description { set; get; }

        //Define save button       
        [FindsBy(How = How.XPath, Using = "//*[@id='main-content']/section/div/div[2]/button")]
        private IWebElement SaveBtn { set; get; }
        #endregion

        internal void SendRequest()
        {
            try
            {
               

                //Edit Mortgage textbox
                Mortgage.Clear();
                Thread.Sleep(1000);
                Mortgage.SendKeys(ExcelLib.ReadData(2, "Mortgage"));

                //Edit HomeValue textbox
                HomeValue.Clear();
                Thread.Sleep(1000);
                HomeValue.SendKeys(ExcelLib.ReadData(2, "Home Value"));
                HomeValue.SendKeys(Keys.Enter);


                //Click on the "Save" button
                SaveBtn.Click();
                Thread.Sleep(2000);


            }
            catch (Exception e)
            {
                Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Test Failed, Add New Inspections throw an exception", e.Message);
            }
        }
    }
}
