using OpenQA.Selenium;
using SeleniumProjectTemplate.WebDriver.Builders;
using SeleniumProjectTemplate.WebDriver.Creators.Base;

namespace SeleniumProjectTemplate.WebDriver.Creators
{
    public class IEDriverCreator : WebDriverCreator
    {
        public override IWebDriver Create(WebDriverConstructor constructor)
        {
            var builder = new InternetExplorerDriverBuilder();
            constructor.Construct(builder);
            return builder.GetResult();
        }
    }
}