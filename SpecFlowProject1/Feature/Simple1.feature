Feature: Simple1
	Search functionality

@mytag
Scenario: Application search
	Given I am on Application
	When I search the keyword 'C#'
	And I press the search button
	Then search result should be displayed


	Scenario Outline: Combined scenario
	Given I am on Application
	When I search the keyword 'C#'
	And I press the search button
	Then search result should be displayed on "<Environment>"

Examples: 
| Environment |
| QA          |
| Dev          |
