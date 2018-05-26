using Keys_Onboarding.Global;
using RelevantCodes.ExtentReports;
using System;
using TechTalk.SpecFlow;
using static Keys_Onboarding.Global.CommonMethods;

namespace Keys_Onboarding.Specflow
{
    [Binding]
    public class PO_SearchSteps : Base
    {
        [Given(@"User have logged into the application")]
        public void GivenUserHaveLoggedIntoTheApplication()
        {
            Inititalize();
        }
        
        [Then(@"User search results for property are successfully")]
        public void ThenUserSearchResultsForPropertyAreSuccessfully()
        {
            // Creates a toggle for the given test, adds all log events under it    
            test = extent.StartTest("Search for a Property");

            // Create an class and object to call the method
            OwnerProperty obj = new OwnerProperty();
            obj.SearchAProperty();

            TearDown();
        }
    }
}
