using Keys_Onboarding.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static Keys_Onboarding.Global.CommonMethods;

namespace Keys_Onboarding.Pages
{
    class FinanceDetails
    {
        public FinanceDetails()
        {
            PageFactory.InitElements(Driver.driver, this);
        }

        #region WebElements Definition
        //Define Purchase Price  textbox
        [FindsBy(How = How.XPath, Using = "//*[@id='financeSection']/div[1]/div[1]/div[1]/input")]
        private IWebElement PurchasePrice  { set; get; }

        //Define Mortgage  textbox
        [FindsBy(How = How.Name, Using = "mortgagePrice")]
        private IWebElement Mortgage { set; get; }

        //Define Home Value  textbox
        [FindsBy(How = How.XPath, Using = "//*[@id='financeSection']/div[1]/div[3]/div[1]/input")]
        private IWebElement HomeValue { set; get; }

        //Define Next  button        
        [FindsBy(How = How.XPath, Using = "//*[@id='financeSection']/div[8]/button[3]")]
        private IWebElement NextButton { set; get; }

        #endregion

        internal void GetDataFromExcel()
        {
            try
            {
                // Populating the data from Excel
                ExcelLib.PopulateInCollection(Base.ExcelPath, "FinanceDetails");

                //Edit PurchasePrice textbox
                PurchasePrice.Clear();
                Thread.Sleep(1000);
                PurchasePrice.SendKeys(ExcelLib.ReadData(2, "Purchase Price"));

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
                NextButton.Click();
                Thread.Sleep(2000);


            }
            catch (Exception e)
            {
                Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Test Failed, Add Finance Details Unsuccessfull", e.Message);
            }
        }
    }
}
