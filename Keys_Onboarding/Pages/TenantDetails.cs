using Keys_Onboarding.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Threading;
using static Keys_Onboarding.Global.CommonMethods;

namespace Keys_Onboarding.Pages
{
    class TenantDetails
    {
        public TenantDetails()
        {
            PageFactory.InitElements(Driver.driver, this);
        }

        #region WebElements Definition
        //Define Tenant Email  textbox
        [FindsBy(How = How.Id, Using = "email")]
        private IWebElement TenantEmail { set; get; }

        //Define First Name  textbox
        [FindsBy(How = How.XPath, Using = "//*[@id='fname']")]
        private IWebElement FirstName { set; get; }

        //DefineLast Name textbox
        [FindsBy(How = How.XPath, Using = "//*[@id='lname']")]
        private IWebElement LastName { set; get; }
        
        //Define Start Date date picker        
        [FindsBy(How = How.Id, Using = "sdate")]
        private IWebElement StratDate { set; get; }

        //Define End Date date picker        
        [FindsBy(How = How.Id, Using = "edate")]
        private IWebElement EndDate { set; get; }

        //Define Rent Amount textbox        
        [FindsBy(How = How.Id, Using = "ramount")]
        private IWebElement RentAmount { set; get; }

        //Define Payment Start Date date picker        
        [FindsBy(How = How.Id, Using = "psdate")]
        private IWebElement PayStratDate { set; get; }


        //Define Save  button        
        [FindsBy(How = How.XPath, Using = "//*[@id='saveProperty']")]
        private IWebElement SaveButton { set; get; }

        

        #endregion

        internal void GetDataFromExcel()
        {
            try
            {
                // Populating the data from Excel
                ExcelLib.PopulateInCollection(Base.ExcelPath, "TenantDetails");

                //Edit Email textbox
                TenantEmail.Clear();
                Thread.Sleep(1000);
                TenantEmail.SendKeys(ExcelLib.ReadData(2, "Tenant Email"));

                //Edit First Name textbox
                FirstName.Clear();
                Thread.Sleep(1000);
                FirstName.SendKeys(ExcelLib.ReadData(2, "First Name"));

                //Edit Last Name textbox
                LastName.Clear();
                Thread.Sleep(1000);
                LastName.SendKeys(ExcelLib.ReadData(2, "Last Name"));

                //Edit Start Date picker
                StratDate.Clear();
                Thread.Sleep(1000);
                StratDate.SendKeys(ExcelLib.ReadData(2, "Start Date"));

                //Edit End Date picker
                EndDate.Clear();
                Thread.Sleep(1000);
                EndDate.SendKeys(ExcelLib.ReadData(2, "End Date"));

                //Edit Rent Amount textbox
                RentAmount.Clear();
                Thread.Sleep(1000);
                RentAmount.SendKeys(ExcelLib.ReadData(2, "Rent Amount"));

                //Edit Payment Start Date picker
                PayStratDate.Clear();
                Thread.Sleep(1000);
                PayStratDate.SendKeys(ExcelLib.ReadData(2, "Payment Start Date"));
                PayStratDate.SendKeys(Keys.Enter);
                Thread.Sleep(1000);

                //Click on the "Save" button
                SaveButton.Click();
                Thread.Sleep(2000);


            }
            catch (Exception e)
            {
                Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Test Failed, Add Tenant Details Unsuccessfull", e.Message);
            }
        }
    }
}
