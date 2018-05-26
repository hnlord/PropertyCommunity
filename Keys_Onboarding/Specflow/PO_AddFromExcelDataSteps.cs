using Keys_Onboarding.Global;
using System;
using TechTalk.SpecFlow;

namespace Keys_Onboarding.Specflow
{
    [Binding]
    public class PO_AddFromExcelDataSteps: Base
    {
        [Given(@"user have logged into the My properties page successfully")]
        public void GivenUserHaveLoggedIntoTheMyPropertiesPageSuccessfully()
        {
            Inititalize();
        }
        
        [Then(@"User add a property from Excel data should be successfully")]
        public void ThenUserAddAPropertyFromExcelDataShouldBeSuccessfully()
        {
            // Creates a toggle for the given test, adds all log events under it    
            test = extent.StartTest("Add a Property from Excel Data");

            // Create an class and object to call the method
            OwnerProperty obj = new OwnerProperty();
            obj.AddAProperty();

            TearDown();
        }
    }
}
