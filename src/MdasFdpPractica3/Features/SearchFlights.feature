Feature: Search Flights
	In order to find available flights
	As a client of https://vueling.com/es
	I want to be able to search flights
	
@SearchSingleFlight
Scenario: Initial Search
	Given I'm in main page
	When I try to find a flight
        | Origin    | Destination | Outbound  | Return | Passengers |
        | Barcelona | Madrid      | NextWeek  | None       | 2          |
	Then I get available flight