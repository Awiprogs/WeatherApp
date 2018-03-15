Feature: LocalWeatherInAGivenCity
	As a delegated employee
	I want to check what the weather is like in a city and country of my choosing
	So that I know how to dress for the business trip over there.

@mytag
Scenario: Get weather for Warsaw - Poland
	Given a webpage with a form
	And I type in 'Poland'
	And I also type in 'Warsaw'
	When I submit the form
	Then I receive the temperature and humidity conditions on the day for Warsaw, Poland according to the official weather reports

Scenario: Get weather for Gdansk - Poland
	Given a webpage with a form
	And I type in 'Poland'
	And I also type in 'Gdansk'
	When I submit the form
	Then I receive the temperature and humidity conditions on the day for Gdansk, Poland according to the official weather reports

Scenario: Get weather for Berlin - Germany
	Given a webpage with a form
	And I type in 'Germany'
	And I also type in 'Berlin'
	When I submit the form
	Then I receive the temperature and humidity conditions on the day for Berlin, Germany according to the official weather reports
