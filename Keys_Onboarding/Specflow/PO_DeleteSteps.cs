using Keys_Onboarding.Global;
using RelevantCodes.ExtentReports;
using System;
using TechTalk.SpecFlow;
using static Keys_Onboarding.Global.CommonMethods;

namespace Keys_Onboarding
{
    [Binding]
    public class PO_DeleteSteps :Base
    {
        [Given(@"One User have logged into the application")]
        public void GivenOneUserHaveLoggedIntoTheApplication()
        {
            Inititalize();
        }
        
        [Then(@"User delete a property should be successfully")]
        public void ThenUserDeleteAPropertyShouldBeSuccessfully()
        {
            // Creates a toggle for the given test, adds all log events under it    
            test = extent.StartTest("Delete a Property");

            // Create an class and object to call the method
            OwnerProperty obj = new OwnerProperty();
            obj.DeleteAProperty();

            TearDown();
        }
    }
}
