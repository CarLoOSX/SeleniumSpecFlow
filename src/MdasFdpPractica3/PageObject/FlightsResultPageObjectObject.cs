using MdasFdpPractica3.PageObject.Base;
using MdasFdpPractica3.Services.Contracts;
using OpenQA.Selenium;

namespace MdasFdpPractica3.PageObject
{
    public class FlightsResultPageObjectObject : BasePageObject
    {
        public IWebElement OriginDestinationField => WebDriverService.FindElementByXPath("//*[@id=\"newSearchContainer\"]/div/p[1]/strong");
        public IWebElement FlightTypeField => WebDriverService.FindElementByXPath("//*[@id=\"newSearchContainer\"]/div/p[2]");

        public FlightsResultPageObjectObject(IWebDriverService webDriverService) : base(webDriverService)
        {
        }
    }
}