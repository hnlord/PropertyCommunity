using Keys_Onboarding.Global;
using System;
using TechTalk.SpecFlow;

namespace Keys_Onboarding.Specflow
{
    [Binding]
    public class PO_EditFromExcelDataSteps : Base
    {
        [Given(@"A user have logged into the My properties page")]
        public void GivenAUserHaveLoggedIntoTheMyPropertiesPage()
        {
            Inititalize();
        }
        
        [Then(@"User edit a property from Excel data should be successfully")]
        public void ThenUserEditAPropertyFromExcelDataShouldBeSuccessfully()
        {
            // Creates a toggle for the given test, adds all log events under it    
            test = extent.StartTest("Edit a Property from Excel Data");

            // Create an class and object to call the method
            OwnerProperty obj = new OwnerProperty();
            obj.EditAProperty("TC_027_01");

            TearDown();
        }
    }
}
