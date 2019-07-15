using OpenQA.Selenium;
using SeleniumProjectTemplate.WebDriver.Builders;
using SeleniumProjectTemplate.WebDriver.Creators.Base;

namespace SeleniumProjectTemplate.WebDriver.Creators
{
    public class ChromeDriverCreator : WebDriverCreator
    {
        public override IWebDriver Create(WebDriverConstructor constructor)
        {
            var chromeBuilder = new ChromeDriverBuilder();
            constructor.Construct(chromeBuilder);
            return chromeBuilder.GetResult();
        }
    }
}
