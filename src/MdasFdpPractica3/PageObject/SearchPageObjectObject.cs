using MdasFdpPractica3.PageObject.Base;
using MdasFdpPractica3.Services.Contracts;
using OpenQA.Selenium;

namespace MdasFdpPractica3.PageObject
{
    public class SearchPageObjectObject : BasePageObject
    {
        public IWebElement Origin => WebDriverService.FindElementByXPath("//*[@id=\"tab-search\"]/div/div[1]/vy-airport-selector[1]/div/input");

        public IWebElement Destination => WebDriverService.FindElementByXPath("//*[@id=\"tab-search\"]/div/div[1]/vy-airport-selector[2]/div/input");

        public IWebElement StartDate => WebDriverService.FindElementByXPath("//*[@id=\"tab-search\"]/div/div[1]/vy-datepicker-selector/div[1]/div/input");

        public IWebElement EndDate => WebDriverService.FindElementByXPath("//*[@id=\"tab-search\"]/div/div[1]/vy-datepicker-selector/div[1]/div/input");
        
        public IWebElement ButtonCookies => WebDriverService.FindElementByXPath("//*[@id=\"ensCloseBanner\"]");

        public IWebElement List => WebDriverService.FindElementByXPath("//*[@id=\"popup-list\"]");

        public IWebElement FlightSelector => WebDriverService.FindElementByXPath("//*[@id=\"searchbar\"]/div/vy-datepicker-popup/vy-datepicker-header/ul");
        
        public IWebElement AddMorePassengersButton => WebDriverService.FindElementByXPath("//*[@id=\"tab-search\"]/div/div[1]/vy-pax-selector/vy-pax-popup/ul/li[1]/vy-type-pax/div[2]/span[2]");

        public IWebElement PassengersValue => WebDriverService.FindElementByXPath("//*[@id=\"tab-search\"]/div/div[1]/vy-pax-selector/vy-pax-popup/ul/li[1]/vy-type-pax/div[2]/div");

        public IWebElement PassengersSelector => WebDriverService.FindElementByXPath("//*[@id=\"tab-search\"]/div/div[1]/vy-pax-selector");

        public IWebElement SearchButton => WebDriverService.FindElementByXPath("//*[@id=\"btnSubmitHomeSearcher\"]");

        public SearchPageObjectObject(IWebDriverService webDriverService) : base(webDriverService)
        {
        }
    }
}