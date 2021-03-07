using System;
using System.Collections.Generic;
using System.Linq;
using MdasFdpPractica3.PageObject;
using MdasFdpPractica3.Services.Contracts;
using OpenQA.Selenium;

namespace MdasFdpPractica3.TestObjects
{
    public class SearchFlight
    {
        private readonly SearchPageObjectObject _searchPageObjectObject;
        private readonly FlightsResultPageObjectObject _flightsResultPageObjectObject;

        public SearchFlight(IWebDriverService webDriverService)
        {
            _flightsResultPageObjectObject = new FlightsResultPageObjectObject(webDriverService);
            _searchPageObjectObject = new SearchPageObjectObject(webDriverService);
        }

        public void GoToSearchMainPage()
        {
            _searchPageObjectObject.GotoPage("https://www.vueling.com/es");
            _searchPageObjectObject.ButtonCookies?.Click();
        }

        public void AddOrigin(string origin)
        {
            _searchPageObjectObject.Origin.Click();
            SearchInCountriesList(origin);
        }

        private void SearchInCountriesList(string origin)
        {
            var found = false;

            var countriesList = _searchPageObjectObject.List.FindElements(By.TagName("li"));

            foreach (var country in countriesList)
            {
                //to avoid get something that does not exist after country selection
                //list will not be available
                if (found) break;

                var abreviations = country.FindElements(By.TagName("p"));

                if (abreviations.All(abreviation => abreviation.Text != origin)) continue;

                country.Click();
                //to avoid get something that does not exist after country selection
                //list will not be available
                found = true;
            }
        }

        public void AddDestination(string destination)
        {
            _searchPageObjectObject.Destination.Click();

            SearchInCountriesList(destination);
        }

        public void AddOutbound(string time)
        {
            var options = _searchPageObjectObject.FlightSelector.FindElements(By.TagName("li"));

            //solo ida
            options[1].Click();

            _searchPageObjectObject.WebDriverService.ExecuteScript(
                $"document.querySelector(\"#tab-search > div > div.form-group.form-group--flight-search > vy-datepicker-selector > div:nth-child(1) > div > input\").value = \"{time}\"");
        }

        public void AddReturn(string time)
        {
            throw new NotImplementedException();
        }

        public void AddPassengers(int passengers)
        {
            AddPassengersRecursively(passengers.ToString());
        }

        private void AddPassengersRecursively(string passengers)
        {
            _searchPageObjectObject.PassengersSelector.Click();

            if (_searchPageObjectObject.PassengersValue.Text == passengers) return;

            _searchPageObjectObject.AddMorePassengersButton.Click();

            AddPassengersRecursively(passengers);
        }

        public void Search()
        {
            _searchPageObjectObject.SearchButton.Click();
        }

        public List<string> FlightResults()
        {
            var result = new List<string>();

            var originDestination = _flightsResultPageObjectObject.OriginDestinationField.Text.Trim().Split("-");
            var type = _flightsResultPageObjectObject.FlightTypeField.Text.Trim().Split("|");

            result.Add(originDestination[0].Trim());
            result.Add(originDestination[1].Trim());

            result.Add(type[0].Trim());
            result.Add(type[1].Replace("Pasajero", string.Empty).Replace("s", string.Empty).Trim());
            result.Add(type[2].Trim());

            return result;
        }
    }
}