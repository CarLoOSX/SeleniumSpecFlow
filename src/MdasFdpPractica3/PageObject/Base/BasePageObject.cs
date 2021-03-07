using MdasFdpPractica3.Services.Contracts;

namespace MdasFdpPractica3.PageObject.Base
{
    public class BasePageObject
    {
        public readonly IWebDriverService WebDriverService;

        public BasePageObject(IWebDriverService webDriverService)
        {
            WebDriverService = webDriverService;
        }

        public string GotoPage(string url)
        {
            return WebDriverService.GoToPage(url);
        }
    }
}