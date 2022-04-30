Feature: Contact Page Error Message Handling & Submission
	Feature to verify the Error Messages on Contact Page and Handle them

Background: 
	Given the user open the Jupiter Toys App
	And navigates to the Contacts Page

@errorMessages
Scenario: SC-01_Verify the Mandatory field error messages
	When the user clicks on Submit button
	Then the user should see the error message for ForeName
	And the user should see the error message for Email
	And the user should see the error message for Message

@errorMessages
Scenario: SC-02_Verify Error Messages are gone when the mandatory fields are populated
	Given the mandatory field validation errors are present
	When the user enters any value for the mandatory fields
	Then the user should not see the error message for ForeName
	And the user should not see the error message for Email
	And the user should not see the error message for Message

@submission
Scenario: SC-03_Verify successful submission of feedback when only mandatory fields are populated
	When the user enters any value for the mandatory fields
	And clicks on Submit button
	Then the user should see the feedback submission in progress 
	And the feedback should be successfully submitted