Feature: Owner properties
	

@search
Scenario: BDD_Search for a property under My Properties Page
	Given User have logged into the application
	Then User search results for property are successfully

@delete
Scenario: BDD_Delete a property under My Properties page
	Given One User have logged into the application
	Then User delete a property should be successfully

@edit by unloading a picture
Scenario: BDD_Edit a property by uploading a picture
	Given User have logged into the My properties page	
	Then User edit a property by uploading a picture should be successfully

@edit by searching address
Scenario: BDD_Edit a property by searching address
	Given the User have logged into the My properties page	
	Then User edit a property by searching address should be successfully

@edit from Excel Data
Scenario: BDD_Edit a property from Excel Data
	Given A user have logged into the My properties page	
	Then User edit a property from Excel data should be successfully

@Add from Excel Data
Scenario: BDD_Add a property from Excel Data
	Given user have logged into the My properties page successfully	
	Then User add a property from Excel data should be successfully