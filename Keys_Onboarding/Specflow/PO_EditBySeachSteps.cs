using Keys_Onboarding.Global;
using System;
using TechTalk.SpecFlow;

namespace Keys_Onboarding
{
    [Binding]
    public class PO_EditBySeachSteps: Base
    {
        [Given(@"the User have logged into the My properties page")]
        public void GivenTheUserHaveLoggedIntoTheMyPropertiesPage()
        {
            Inititalize();
        }
        
        [Then(@"User edit a property by searching address should be successfully")]
        public void ThenUserEditAPropertyBySearchingAddressShouldBeSuccessfully()
        {
            // Creates a toggle for the given test, adds all log events under it    
            test = extent.StartTest("Edit a Property by searching address");

            // Create an class and object to call the method
            OwnerProperty obj = new OwnerProperty();
            obj.EditAProperty("TC_027_03");

            TearDown();
        }
    }
}
