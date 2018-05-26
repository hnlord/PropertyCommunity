using System;
using TechTalk.SpecFlow;
using Keys_Onboarding.Global;

namespace Keys_Onboarding.Specflow
{
    [Binding]
    public class PO_EditByUploadSteps:Base
    {
        [Given(@"User have logged into the My properties page")]
        public void GivenUserHaveLoggedIntoTheMyPropertiesPage()
        {
            Inititalize();
        }
        
        [Then(@"User edit a property by uploading a picture should be successfully")]
        public void ThenUserEditAPropertyByUploadingAPictureShouldBeSuccessfully()
        {
            // Creates a toggle for the given test, adds all log events under it    
            test = extent.StartTest("Edit a Property by uploading a picture");

            // Create an class and object to call the method
            OwnerProperty obj = new OwnerProperty();
            obj.EditAProperty("TC_027_02");

            TearDown();
        }
    }
}
