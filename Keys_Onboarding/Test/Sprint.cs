using Keys_Onboarding.Global;
using Keys_Onboarding.Pages;
using NUnit.Framework;

namespace Keys_Onboarding.Test
{
    class Sprint 
    {
      [TestFixture]
      [Category("Sprint1")]
       class Tenant : Base
       {
        
            [Test]
            //Implement test case for TC_003_01
            public void Sprint1_SearchAProperty()
            {
                // Creates a toggle for the given test, adds all log events under it    
                test = extent.StartTest("Search for a Property");

                // Create an class and object to call the method
                OwnerProperty obj = new OwnerProperty();
                obj.SearchAProperty();

            }


        }

        class Owner : Base
        {
            //Implement test case for TC_028_01
            [Test]
            public void Sprint1_DeleteAProperty()
            {
                // Creates a toggle for the given test, adds all log events under it    
                test = extent.StartTest("Delete a Property");

                // Create an class and object to call the method
                OwnerProperty obj = new OwnerProperty();
                obj.DeleteAProperty();

            }

            //Implement test case for TC_027_01
            //Edit A Property From ExcelData
            [Test]
            public void Sprint1_EditAPropertyFromExcelData()
            {
                // Creates a toggle for the given test, adds all log events under it    
                test = extent.StartTest("Edit a Property from Excel Data");

                // Create an class and object to call the method
                OwnerProperty obj = new OwnerProperty();
                obj.EditAProperty("TC_027_01");

            }

            //Implement test case for TC_027_02
            //Edit A Property by uploading a picture
            [Test]
            public void Sprint1_EditAPropertyByUploadPicture()
            {
                // Creates a toggle for the given test, adds all log events under it    
                test = extent.StartTest("Edit a Property by uploading a picture");

                // Create an class and object to call the method
                OwnerProperty obj = new OwnerProperty();
                obj.EditAProperty("TC_027_02");

            }

            //Implement test case for TC_027_03
            //Edit A Property by searching address
            [Test]
            public void Sprint1_EditAPropertyBySearchAddress()
            {
                // Creates a toggle for the given test, adds all log events under it    
                test = extent.StartTest("Edit a Property");

                // Create an class and object to call the method
                OwnerProperty obj = new OwnerProperty();
                obj.EditAProperty("TC_027_03");

            }

            //Implement test case for TC_023_01
            //Add A Property with valide data
            [Test]
            public void Sprint1_AddAPropertyFromExcel()
            {
                // Creates a toggle for the given test, adds all log events under it    
                test = extent.StartTest("Add a Property");

                // Create an class and object to call the method
                OwnerProperty obj = new OwnerProperty();
                obj.AddAProperty();

            }

            //Add A New Inspection Request
            [Test]
            public void Sprint1_AddAInspectionRequst()
            {
                // Creates a toggle for the given test, adds all log events under it    
                test = extent.StartTest("Add a inspection request");

                // Create an class and object to call the method
                OwnerInspections obj = new OwnerInspections();
                obj.AddANewInspection();

            }



        }
    }
}
