using Keys_Onboarding.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Diagnostics;
using System.Threading;
using static Keys_Onboarding.Global.CommonMethods;

namespace Keys_Onboarding.Pages
{
    class EditProperty
    {
        public EditProperty()
        {
            PageFactory.InitElements(Driver.driver, this);
        }

        #region WebElements Definition
        //Define propertyName textbox
        [FindsBy(How = How.XPath, Using = "//*[@id='main-content']/section/div[3]/div[2]/form/div[1]/div[1]/div/input")]
        private IWebElement PropertyName { set; get; }

        //Define Search Address textbox
        [FindsBy(How = How.Id, Using = "autocomplete")]
        private IWebElement SearchAddress { set; get; }

        //Define Description textbox
        [FindsBy(How = How.XPath, Using = "//*[@id='main-content']/section/div[3]/div[2]/form/div[2]/div[2]/div/textarea")]
        private IWebElement Description { set; get; }

        //Define Number  textbox        
        [FindsBy(How = How.Id, Using = "street_number")]
        private IWebElement StreetNumber { set; get; }

        //Define Street  textbox
        [FindsBy(How = How.Id, Using = "route")]
        private IWebElement Street { set; get; }

        //Define Suburb  textbox
        [FindsBy(How = How.XPath, Using = "//div[@class='three fields']/div/div/input")]
        private IWebElement Suburb { set; get; }

        //Define City  textbox        
        [FindsBy(How = How.XPath, Using = "//div[@class='three fields']/div[2]/div/input")]
        private IWebElement City { set; get; }

        //Define Postcode  textbox        
        [FindsBy(How = How.XPath, Using = "//div[@class='three fields']/div[3]/div/input")]
        private IWebElement Postcode { set; get; }

        //Define Region textbox        
        [FindsBy(How = How.Id, Using = "region")]
        private IWebElement Region { set; get; }

        //Define Year built datepicker        
        [FindsBy(How = How.XPath, Using = "//*[@id='main-content']/section/div[3]/div[2]/form/div[3]/div[1]/div/select")]
        private IWebElement YearBuilt { set; get; }

        //Define Target Rent textbox        
        [FindsBy(How = How.XPath, Using = "//*[@id='main-content']/section/div[3]/div[2]/form/div[3]/div[2]/div/input")]
        private IWebElement TargetRent { set; get; }


        //Define Bedrooms  textbox        
        [FindsBy(How = How.XPath, Using = "//*[@id='main-content']/section/div[3]/div[2]/form/div[5]/div[1]/div/input")]
        private IWebElement Bedrooms { set; get; }

        //Define Bathrooms  textbox        
        [FindsBy(How = How.XPath, Using = "//*[@id='main-content']/section/div[3]/div[2]/form/div[5]/div[2]/div/input")]
        private IWebElement Bathrooms { set; get; }

        //Define Carparks textbox        
        [FindsBy(How = How.XPath, Using = "//*[@id='main-content']/section/div[3]/div[2]/form/div[6]/div[1]/div/input")]
        private IWebElement Carparks { set; get; }

        //Define Save  button        
        [FindsBy(How = How.XPath, Using = "//button[@class='ui positive button']")]
        private IWebElement SaveButton { set; get; }


        #endregion
        // Edit a property by searching address
        internal void EditAPropertyBySearchAddress()
        {
            try
            {
                //Edit name textbox
                PropertyName.Clear();
                Thread.Sleep(1000);
                PropertyName.SendKeys("BHouse");

                //SearchAddress
                SearchAddress.SendKeys("77");
                Thread.Sleep(1000);
                SearchAddress.SendKeys(Keys.ArrowDown);
                SearchAddress.SendKeys(Keys.Enter);
                Thread.Sleep(1000);

                //Edit description textbox
                Description.Clear();
                Thread.Sleep(1000);
                Description.SendKeys("Beautiful House");
                
                //Click on the "Save" button
                SaveButton.Click();
                Thread.Sleep(2000);


            }
            catch (Exception e)
            {
                Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Test Failed, Edit Unsuccessfull", e.Message);
            }
        }

        //Edit a property by uploading a picture
        internal void EditAPropertyByUploadPicture()
        {
            try
            {
                //Edit name textbox
                PropertyName.Clear();
                Thread.Sleep(1000);
                PropertyName.SendKeys("Lovely house for you");

                //upload a picture
                IWebElement upload = Driver.driver.FindElement(By.XPath("//*[@id='fileUpload']"));
                upload.SendKeys(@Base.PicturePath);
                Thread.Sleep(1000);

                //Click on the "Save" button
                SaveButton.Click();
                Thread.Sleep(2000);


            }
            catch (Exception e)
            {
                Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Test Failed, Edit Unsuccessfull", e.Message);
            }
        }

        //Edit a property from Excel data
        internal void EditAPropertyFromExcelData()
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
                Suburb.Clear();
                Thread.Sleep(1000);
                Suburb.SendKeys(ExcelLib.ReadData(2, "Suburb"));

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
                YearBuilt.Click();
                Thread.Sleep(1000);
                var selectElement = new SelectElement(YearBuilt);

                //select by text                
                string sYear = ExcelLib.ReadData(2, "YearBuilt");
                //Debug.Assert(sYear == "1977");
                selectElement.SelectByText(sYear);
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


                //Click on the "Save" button
                SaveButton.Click();
                Thread.Sleep(2000);


            }
            catch (Exception e)
            {
                Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Test Failed, Edit Unsuccessfull", e.Message);
            }
        }


    }
}
