Feature: globalsqa
	Simple tests to automate global SQA 

@UX
Scenario: Drag and drop images
	Given I successfully navigate to Global SQA
	When I drag the first picture into the trash area
	And I drag the second picture into the trash area
	

@UX
Scenario Outline: Navigate to Dropdown Menu and choose a country
	Given I successfully navigate to Global SQA
	When I click on the DropDown Menu link
	Then I should be able to select a <country>

	Examples: 
	| country |
	| Macao   |
	| Mali    |
	| Zambia  |

@UX 
Scenario Outline: Navigate to the sample page test and fill in information
	Given I successfully navigate to Global SQA
	And I click on the Sample Page Test link
	Then I should be able to fill in the <name> <email> and <website> info

	@source:TestData.xlsx	
	Examples: 
	| name | email | website |



	