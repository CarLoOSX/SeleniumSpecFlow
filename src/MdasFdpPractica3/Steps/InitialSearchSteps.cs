using System;
using System.Globalization;
using System.Linq;
using FluentAssertions;
using MdasFdpPractica3.Dto;
using MdasFdpPractica3.Enum;
using MdasFdpPractica3.TestObjects;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace MdasFdpPractica3.Steps
{
    [Binding]
    public class InitialSearchSteps
    {
        private readonly SearchFlight _searchFlight;
        private SearchFlightDto _request;
        private const string Ida = "Ida";
        private const string IdayVuelta = "Ida y vuelta";

        public InitialSearchSteps(SearchFlight searchFlight)
        {
            _searchFlight = searchFlight;
        }

        [Given(@"I'm in main page")]
        public void GivenImInMainPage()
        {
            _searchFlight.GoToSearchMainPage();
        }

        [When(@"I try to find a flight")]
        public void WhenITryToFindAFlight(Table table)
        {
            _request = table.CreateInstance<SearchFlightDto>();

            _searchFlight.AddOrigin(_request.Origin);

            _searchFlight.AddDestination(_request.Destination);

            _searchFlight.AddOutbound(GetFormattedDate(_request.Outbound));

            _searchFlight.AddPassengers(_request.Passengers);

            _searchFlight.Search();
        }

        [Then(@"I get available flight")]
        public void ThenIGetAvailableFlight()
        {
            _searchFlight.FlightResults().ElementAt(0).Should().BeEquivalentTo(_request.Origin);

            _searchFlight.FlightResults().ElementAt(1).Should().BeEquivalentTo(_request.Destination);

            _searchFlight.FlightResults().ElementAt(2).Should()
                .BeEquivalentTo(_request.Return == DatesEnum.None ? Ida : IdayVuelta);

            _searchFlight.FlightResults().ElementAt(3).Should().BeEquivalentTo(_request.Passengers.ToString());

            if (_request.Return == DatesEnum.None)
            {
                _searchFlight.FlightResults().ElementAt(4).ToLowerInvariant().Should()
                    .Contain(GetFormattedDate3Elements(GetFormattedDate(_request.Outbound)));
            }
            else
            {
                _searchFlight.FlightResults().ElementAt(4).ToLowerInvariant().Should()
                    .Contain(GetFormattedDate3Elements(GetFormattedDate(_request.Outbound)));
                _searchFlight.FlightResults().ElementAt(4).ToLowerInvariant().Should()
                    .Contain(GetFormattedDate3Elements(GetFormattedDate(_request.Return)));
            }
        }

        private string GetFormattedDate(DatesEnum requestOutbound)
        {
            DateTime date;
            switch (requestOutbound)
            {
                case DatesEnum.NextWeek:
                    date = DateTime.Today.AddDays(7);
                    break;
                case DatesEnum.Today:
                    date = DateTime.Today;
                    break;
                case DatesEnum.Tomorrow:
                    date = DateTime.Today.AddDays(1);
                    break;
                case DatesEnum.Yesterday:
                    date = DateTime.Today.AddDays(-1);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(requestOutbound), requestOutbound, null);
            }

            return date.ToString("dd/MM/yyyy");
        }

        private string GetFormattedDate3Elements(string date)
        {
            var splittedDate = date.Split("/");
            var dates = new DateTime(Convert.ToInt32(splittedDate[2]), Convert.ToInt32(splittedDate[1]),
                Convert.ToInt32(splittedDate[0]));

            return dates.ToString("dd MMM", new CultureInfo("es-Es"));
        }
    }
}