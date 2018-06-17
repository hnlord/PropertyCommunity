using Keys_Onboarding.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
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
        [FindsBy(How = How.CssSelector, Using = "#main-content > section > div > div.ui.grid > div:nth-child(2) > div:nth-child(1) > div")]
        private IWebElement Property { set; get; }

        //Define Property drop down select list
        [FindsBy(How = How.XPath, Using = "//*[@id='main-content']/section/div/div[1]/div[1]/div[1]/div/select")]
        private IWebElement PropertySelect { set; get; }

        
        //Define Tenant  drop down list
        [FindsBy(How = How.XPath, Using = "//*[@id='main-content']/section/div/div[1]/div[1]/div[2]/div/div/i")]
        private IWebElement Tenant { set; get; }

        //Define Tenant  drop down select list
        [FindsBy(How = How.XPath, Using = "//*[@id='tenant-select']")]
        private IWebElement TenantSelect { set; get; }
        

        //Define Type drop down list
        [FindsBy(How = How.XPath, Using = "//*[@id='main-content']/section/div/div[1]/div[1]/div[3]/select")]
        private IWebElement Type { set; get; }

        //Define due date
        [FindsBy(How = How.XPath, Using = "//*[@id='main-content']/section/div/div[1]/div[1]/div[4]/input")]
        private IWebElement DueDate { set; get; }
        

        //Define Description  textbox        
        [FindsBy(How = How.XPath, Using = "//*[@id='main-content']/section/div/div[1]/div[2]/form/div/textarea")]
        private IWebElement Description { set; get; }

        //Define save button       
        [FindsBy(How = How.XPath, Using = "//*[@id='main-content']/section/div/div[2]/button")]
        private IWebElement SaveBtn { set; get; }
        #endregion

        internal void SendRequest()
        {
            try
            {

                //select property
                Property.Click();
                Thread.Sleep(1000);
                Property.SendKeys(Keys.PageDown);
                Property.SendKeys(Keys.ArrowDown);
                Property.SendKeys(Keys.Enter);

                //  SelectElement selectProperty = new SelectElement(PropertySelect);
                //  selectProperty.SelectByIndex(1);
                //   selectProperty.SelectByText("250 Great South Road Drury Drury");

                Thread.Sleep(3000);

                //select tenent
                /*
               Tenant.Click();
               Thread.Sleep(3000);
               Tenant.SendKeys(Keys.ArrowDown);
                Tenant.SendKeys(Keys.ArrowDown);
                Tenant.SendKeys(Keys.Enter);
                Thread.Sleep(1000);

                SelectElement selectTenent = new SelectElement(TenantSelect);
                selectTenent.SelectByIndex(1);


               Thread.Sleep(1000);
                 */
                //select type
                var selectType = new SelectElement(Type);
                selectType.SelectByIndex(1);
                /*   Type.Click();
                   Thread.Sleep(1000);
                   Type.SendKeys(Keys.ArrowDown);
                   Type.SendKeys(Keys.Enter);
                       
               */
                Thread.Sleep(1000);

                //send due date value
                DueDate.SendKeys("07/07/2018");
                DueDate.SendKeys(Keys.ArrowDown);
                DueDate.SendKeys(Keys.Enter);
                Thread.Sleep(1000);


                Description.SendKeys("Inspection regularly");

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
