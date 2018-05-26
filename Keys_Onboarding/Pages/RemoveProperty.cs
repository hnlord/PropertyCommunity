using Keys_Onboarding.Global;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Threading;

namespace Keys_Onboarding.Pages
{
    class RemoveProperty
    {
        public RemoveProperty()
        {
            PageFactory.InitElements(Driver.driver, this);
        }
        #region WebElements Definition
        

        //Define Confirm button
        [FindsBy(How = How.CssSelector, Using = "#main-content > section > div:nth-child(4) > div > div.panel-body > div.prop-actions > button.btn.btn-success")]
        private IWebElement ConfirmButton { set; get; }

        //Define Cancel button
        [FindsBy(How = How.XPath, Using = "//*[@id='main - content']/section/div[4]/div/div[2]/div[7]/button[2]")]
        private IWebElement CancelButton { set; get; }

        #endregion

        internal void ConfirmDelete()
        {
            try
            {
                //Click on the "Confirm" button
                ConfirmButton.Click();
                

            }
            catch (Exception e)
            {
                Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Test Failed, Delete Unsuccessfull", e.Message);
            }
        }

    }
}
