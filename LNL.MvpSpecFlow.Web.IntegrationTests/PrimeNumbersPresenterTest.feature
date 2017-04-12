Feature: PrimeNumbersPresenterTest
	In order to make sure the model is saved and an id returned.

Scenario: Save model to the DB Test
	Given I have entered 50 into the Number field
	And I have entered 'Blah' into the Name field
	When I press save
	Then the id should be greater then 0 on the screen
	And the name should be 'Blah'

Scenario: When save model check if prime number is found prime test
	Given I have entered 7 into the Number field
	When I press save
	Then number should be found prime

Scenario: When save model check if non prime number is found non prime test
	Given I have entered 8 into the Number field
	When I press save
	Then number should be found non prime

Scenario: Calculating all prime numbers test
	Given I have entered 13 into the Number field
	When I press calculate
	Then output numbers should be:
	| Number | IsPrime |
	| 1      | False   |
	| 2      | True    |
	| 3      | True    |
	| 4      | False   |
	| 5      | True    |
	| 6      | False   |
	| 7      | True    |
	| 8      | False   |
	| 9      | False   |
	| 10     | False   |
	| 11     | True    |
	| 12     | False   |
	| 13     | True    |
