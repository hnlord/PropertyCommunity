using Keys_Onboarding.Global;
using Keys_Onboarding.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Threading;
using static Keys_Onboarding.Global.CommonMethods;

namespace Keys_Onboarding
{
    public class OwnerProperty
    {
        public OwnerProperty()
        {
            PageFactory.InitElements(Driver.driver, this);
        }

        #region WebElements Definition
        //Define Owners tab
        [FindsBy(How =How.XPath,Using = "/html/body/div[1]/div/div[2]/div[1]")]
        private IWebElement Ownertab { set; get; }

        //Define Properties page
        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div/div[2]/div[1]/div/a[1]")]
        private IWebElement PropertiesPage { set; get; }

        //Define search bar        
        [FindsBy(How = How.Name, Using = "SearchString")]
        private IWebElement SearchBar { set; get; }

        //Define search button
        [FindsBy(How = How.Id, Using = "icon-submitt")]
        private IWebElement SearchButton { set; get; }

        //Define skip button
        [FindsBy(How = How.XPath, Using = "/html/body/div[5]/div/div[5]/a[1]")]
        private IWebElement SkipButton { set; get; }

        //Define right side menu of the first property
        [FindsBy(How = How.XPath, Using = "//*[@id='main-content']/section/div[1]/div/div[3]/div/div[1]/div[2]/div[1]/div[3]/div/i")]
        private IWebElement RightSideMenu { set; get; }

        //Define delete option under the menu
        [FindsBy(How = How.XPath, Using = "//*[@id='main-content']/section/div[1]/div/div[3]/div/div[1]/div[2]/div[1]/div[3]/div/div/div[5]")]
        private IWebElement DeleteOption { set; get; }

        //Define Edit Property option under the menu
        [FindsBy(How = How.XPath, Using = "//*[@id='main-content']/section/div[1]/div/div[3]/div/div[1]/div[2]/div[1]/div[3]/div/div/div[4]")]
        private IWebElement EditOption { set; get; }

        //Define Add New Property Button
        [FindsBy(How = How.XPath, Using = "//*[@id='main-content']/section/div[1]/div/div[2]/div/div[2]/a[2]")]
        private IWebElement AddNewProperty { set; get; }


  
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
            PropertiesPage.Click();
            Thread.Sleep(1000);
        }

        //Search a property
        internal void SearchAProperty()
        {
            try
            {
              
                //Calling the common methods
                Common_methods();
                Thread.Sleep(1000);
                
                //Enter the value in the search bar
                SearchBar.SendKeys("TestingProperty");
                Thread.Sleep(1000);

                //Click on the search button
                SearchButton.Click();
                Thread.Sleep(2000);

                //Verification
                string ExpectedValue = "TestingProperty";
                Assert.IsTrue(Driver.driver.PageSource.Contains(ExpectedValue));

                SaveScreenShotClass.SaveScreenshot(Driver.driver, "Search");

                string ActualValue = Driver.driver.FindElement(By.XPath("//*[@id='main-content']/section/div[1]/div/div[3]/div/div[1]/div[2]/div[1]/div[1]/a/h3")).Text;
                

                //Assert.AreEqual(ExpectedValue, ActualValue);
               

                if (ActualValue == ExpectedValue)
                                    
                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Test Passed, Search successfull");
                
                else
                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Test Failed, Search Unsuccessfull");

            }

            catch(Exception e)
            {
                Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Test Failed, Search Unsuccessfull",e.Message);
            }
         }
        
        //Delete a property
        internal void DeleteAProperty()
        {
            try
            {
                //Calling the common methods
                Common_methods();
                
                //property name before delete
                string PropertyName_BeforeDelete = Driver.driver.FindElement(By.XPath("//*[@id='main-content']/section/div[1]/div/div[3]/div/div[1]/div[2]/div[1]/div[1]/a/h3")).Text;
                
                //Click on the right side menu of the first property
                RightSideMenu.Click();
                Thread.Sleep(1000);

                //Click on the "Delete" option
                DeleteOption.Click();
                Thread.Sleep(1000);

                //Click on the "Confirm" button on RemoveProperty page
                // Create an class and object to call the method
                RemoveProperty obj = new RemoveProperty();
                obj.ConfirmDelete();
                Thread.Sleep(2000);

                //Verification
                
                bool isPropertyDeleted = Driver.driver.PageSource.Contains(PropertyName_BeforeDelete);
                Assert.IsTrue(!isPropertyDeleted);

                SaveScreenShotClass.SaveScreenshot(Driver.driver, "Delete");

                //property name after delete
                string PropertyName_AfterDelete = Driver.driver.FindElement(By.XPath("//*[@id='main-content']/section/div[1]/div/div[3]/div/div[1]/div[2]/div[1]/div[1]/a/h3")).Text;
                if (PropertyName_AfterDelete != PropertyName_BeforeDelete)

                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Test Passed, Delete successfull");

                else
                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Test Failed, Delete Unsuccessfull");

            }
            catch (Exception e)
            {
                Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Test Failed, Delete Unsuccessfull", e.Message);
            }
        }

        //Edit a property
        internal void EditAProperty(string TestCaseCode)
        {
            try
            {
                //Calling the common methods
                Common_methods();

                //property name before edit
                string PropertyName_BeforeEdit = Driver.driver.FindElement(By.XPath("//*[@id='main-content']/section/div[1]/div/div[3]/div/div[1]/div[2]/div[1]/div[1]/a/h3")).Text;

                //Click on the right side menu of the first property
                RightSideMenu.Click();
                Thread.Sleep(1000);


                //Click on the "Edit Property" option
                EditOption.Click();
                Thread.Sleep(1000);

                //Click on the "Save" button on Edit Property page
                // Create an class and object to call the method
                EditProperty obj = new EditProperty();
                if(TestCaseCode == "TC_027_01")
                    obj.EditAPropertyFromExcelData();
                else if (TestCaseCode == "TC_027_02")
                    obj.EditAPropertyByUploadPicture();
                else if(TestCaseCode == "TC_027_03")
                    obj.EditAPropertyBySearchAddress();

                Thread.Sleep(2000);

                //Verification
                //property name after edit
                string PropertyName_AfterEdit = Driver.driver.FindElement(By.XPath("//*[@id='main-content']/section/div[1]/div/div[3]/div/div[1]/div[2]/div[1]/div[1]/a/h3")).Text;
                bool isPropertyModified = Driver.driver.PageSource.Contains(PropertyName_AfterEdit);
                Assert.IsTrue(isPropertyModified);

                SaveScreenShotClass.SaveScreenshot(Driver.driver, "Edit");

                

                string logSuccess = "";
                string logUnsuccess = "";

                if (TestCaseCode == "TC_027_01")
                {
                    logSuccess = "Test Passed, Edit a property from excel data successfull";
                    logUnsuccess = "Test Failed, Edit a property from excel data Unsuccessfull";
                }
                else if (TestCaseCode == "TC_027_03")
                {
                    logSuccess = "Test Passed, Edit a property by searching address successfull";
                    logUnsuccess = "Test Failed, Edit a property by searching address Unsuccessfull";
                }
                else if (TestCaseCode == "TC_027_02")
                {
                    logSuccess = "Test Passed, Edit a property by uploading a picture successfull";
                    logUnsuccess = "Test Passed, Edit a property by uploading a picture Unsuccessfull";
                }


                if (PropertyName_AfterEdit != PropertyName_BeforeEdit)

                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, logSuccess);

                else
                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, logUnsuccess);

            }
            catch (Exception e)
            {
                Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Test Failed, Edit Unsuccessfull", e.Message);
            }
        }

        //Add a property
        internal void AddAProperty()
        {
            try
            {

                //Calling the common methods
                Common_methods();
                Thread.Sleep(1000);                

                //Click on the Add button
                AddNewProperty.Click();
                Thread.Sleep(1000);

                //Call PropertyDetails page
                PropertyDetails obj = new PropertyDetails();
                obj.GetDataFromExcel();

                //Verification
                string ExpectedValue = "Mortgage";
                bool isFinancePage = Driver.driver.PageSource.Contains(ExpectedValue);
                Assert.IsTrue(isFinancePage);

                SaveScreenShotClass.SaveScreenshot(Driver.driver, "Add Property Details");

                if (isFinancePage)

                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Test Passed, Add property successfull");

                else
                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Test Failed, Add property Unsuccessfull");

                /*===================================================*/

                //Call Finance Details page
                FinanceDetails f_obj = new FinanceDetails();
                f_obj.GetDataFromExcel();

                //Verification
                string ExpectedValue1 = "Tenant Details";
                bool isTenantPage = Driver.driver.PageSource.Contains(ExpectedValue1);
                Assert.IsTrue(isTenantPage);

                SaveScreenShotClass.SaveScreenshot(Driver.driver, "Add finance Details");

                if (isTenantPage)

                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Test Passed, Add finance successfull");

                else
                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Test Failed, Add finance Unsuccessfull");

                /*===================================================*/

                //Call Tenant Details page
                TenantDetails t_obj = new TenantDetails();
                t_obj.GetDataFromExcel();
                Thread.Sleep(2000);

                //Verification
                string ExpectedValue2 = "BHouse";
                bool isPropertyAdded = Driver.driver.PageSource.Contains(ExpectedValue2);
                Assert.IsTrue(isPropertyAdded);

                SaveScreenShotClass.SaveScreenshot(Driver.driver, "Add a property successfully");

                if (isPropertyAdded)

                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Test Passed, Add Property successfull");

                else
                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Test Failed, Add Property Unsuccessfull");

            }

            catch (Exception e)
            {
                Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Test Failed, Add property Unsuccessfull", e.Message);
            }
        }

    }
}