Feature: ShoppingTest
	Feature to verify the shopping use case

Background: 
	Given the user open the Jupiter Toys App
	And navigates to the Shops Page
	When the user buys item(s) '2-Stuffed Frog, 5-Fluffy Bunny, 3-Valentine Bear'
	And goes to the shopping cart

@shopping
Scenario: Buy items
	Then see the total number of item as '3'
	And verify the count of 'Stuffed Frog' as '2'
	And verify the count of 'Fluffy Bunny' as '5'
	And verify the count of 'Valentine Bear' as '3'

@shopping
Scenario: Verify the Price of Each Item
	Then the user verifies the price of 'Stuffed Frog' as '$10.99'
	And the user verifies the price of 'Fluffy Bunny' as '$9.99'
	And the user verifies the price of 'Valentine Bear' as '$14.99'

@shopping
Scenario: Verify the SubTotals of Each Item
	Then the user verifies the subtotal of 'Stuffed Frog' as '$21.98'
	And the user verifies the subtotal of 'Fluffy Bunny' as '$49.95'
	And the user verifies the subtotal of 'Valentine Bear' as '$44.97'

@shopping
Scenario: Verify the Sum Total is displayed correctly
	Then the user verifies the sumtotal of all items is calculated correctly
	And the value of total displayed is '116.9'