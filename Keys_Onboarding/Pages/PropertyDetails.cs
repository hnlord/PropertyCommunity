using Keys_Onboarding.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static Keys_Onboarding.Global.CommonMethods;

namespace Keys_Onboarding.Pages
{
    class PropertyDetails
    {
        public PropertyDetails()
        {
            PageFactory.InitElements(Driver.driver, this);
        }

        #region WebElements Definition
        //Define propertyName textbox
        [FindsBy(How = How.XPath, Using = "//*[@id='property-details']/div[1]/div[1]/div[1]/input")]        
        private IWebElement PropertyName { set; get; }

        //Define Search Address textbox
        [FindsBy(How = How.Id, Using = "autocomplete")]
        private IWebElement SearchAddress { set; get; }

        //Define Description textbox
        [FindsBy(How = How.XPath, Using = "//*[@id='property-details']/div[2]/div[2]/div/div/div[1]/textarea")]
        private IWebElement Description { set; get; }
        
        //Define Number  textbox        
        [FindsBy(How = How.Id, Using = "street_number")]
        private IWebElement StreetNumber { set; get; }

        //Define Street  textbox
        [FindsBy(How = How.Id, Using = "route")]
        private IWebElement Street { set; get; }

        //Define Suburb  textbox
        [FindsBy(How = How.XPath, Using = "//div[@class='ui two column grid']/div[1]/div[3]/div/div[1]/div/input")]
        private IWebElement Suburb { set; get; }
        //*[@id="route"]

        //Define City  textbox        
        [FindsBy(How = How.XPath, Using = "//div[@class='ui two column grid']/div[1]/div[3]/div/div[2]/div/input")]
        private IWebElement City { set; get; }

        //Define Postcode  textbox        
        [FindsBy(How = How.XPath, Using = "//div[@class='ui two column grid']/div[1]/div[3]/div/div[3]/div/input")]
        private IWebElement Postcode { set; get; }

        //Define Region textbox        
        [FindsBy(How = How.Id, Using = "region")]
        private IWebElement Region { set; get; }

        //Define Year built datepicker        
        [FindsBy(How = How.XPath, Using = "//*[@id='property-details']/div[3]/div[1]/div[1]/input")]
        private IWebElement YearBuilt { set; get; }
        
        //Define Target Rent textbox        
        [FindsBy(How = How.XPath, Using = "//*[@id='property-details']/div[3]/div[2]/div/div[1]/div[1]/input")]
        private IWebElement TargetRent { set; get; }
        

        //Define Bedrooms  textbox        
        [FindsBy(How = How.XPath, Using = "//*[@id='property-details']/div[4]/div[3]/div[1]/input")]
        private IWebElement Bedrooms { set; get; }
        
        //Define Bathrooms  textbox        
        [FindsBy(How = How.XPath, Using = "//*[@id='property-details']/div[4]/div[4]/div[1]/input")]
        private IWebElement Bathrooms { set; get; }
        
        //Define Carparks textbox        
        [FindsBy(How = How.XPath, Using = "//*[@id='property-details']/div[4]/div[5]/div[1]/input")]
        private IWebElement Carparks { set; get; }
        
        //Define Next  button        
        [FindsBy(How = How.XPath, Using = "//*[@id='property-details']/div[7]/button[1]")]
        private IWebElement NextButton { set; get; }
        #endregion

        internal void GetDataFromExcel()
        {
            try
            {
                // Populating the data from Excel
                ExcelLib.PopulateInCollection(Base.ExcelPath, "PropertyDetails");
               
                //Edit name textbox
                PropertyName.Clear();
                Thread.Sleep(1000);
                PropertyName.SendKeys(ExcelLib.ReadData(2, "Property Name"));

                //Edit description textbox
                Description.Clear();
                Thread.Sleep(1000);
                Description.SendKeys(ExcelLib.ReadData(2, "Description"));

                //Edit Number textbox
                StreetNumber.Clear();
                Thread.Sleep(1000);
                StreetNumber.SendKeys(ExcelLib.ReadData(2, "Number"));

                //Edit Street textbox
                Street.Clear();
                Thread.Sleep(1000);
                Street.SendKeys(ExcelLib.ReadData(2, "Street"));

                //Edit Suburb  textbox
               // Suburb.Clear();
               // Thread.Sleep(1000);
               // Suburb.SendKeys(ExcelLib.ReadData(2, "Suburb"));

                //Edit City textbox
                City.Clear();
                Thread.Sleep(1000);
                City.SendKeys(ExcelLib.ReadData(2, "City"));

                //Edit Postcode  textbox
                Postcode.Clear();
                Thread.Sleep(1000);
                Postcode.SendKeys(ExcelLib.ReadData(2, "Postcode"));

                //Edit Region   textbox
                Region.Clear();
                Thread.Sleep(1000);
                Region.SendKeys(ExcelLib.ReadData(2, "Region"));


                //Select Year in Year Built 
                YearBuilt.SendKeys(ExcelLib.ReadData(2, "YearBuilt"));
                Thread.Sleep(1000);


                //Edit Target Rent  textbox
                TargetRent.Clear();
                Thread.Sleep(1000);
                TargetRent.SendKeys(ExcelLib.ReadData(2, "Target Rent"));

                //Edit Bed rooms textbox
                Bedrooms.Clear();
                Thread.Sleep(1000);
                Bedrooms.SendKeys(ExcelLib.ReadData(2, "Bedrooms"));

                //Edit Bath rooms textbox
                Bathrooms.Clear();
                Thread.Sleep(1000);
                Bathrooms.SendKeys(ExcelLib.ReadData(2, "Bathrooms"));


                //Edit Carparks textbox
                Carparks.Clear();
                Thread.Sleep(1000);
                Carparks.SendKeys(ExcelLib.ReadData(2, "Carparks"));
                Carparks.SendKeys(Keys.Enter);
                Thread.Sleep(1000);

                //Click on the "Next" button
                NextButton.Click();
                Thread.Sleep(2000);


            }
            catch (Exception e)
            {
                Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Test Failed, Add Property Details Unsuccessfull", e.Message);
            }
        }

    }
}
