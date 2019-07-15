using OpenQA.Selenium;

namespace SeleniumProjectTemplate.WebDriver.Creators.Base
{
    public abstract class WebDriverCreator : IWebDriverCreator
    {
        public abstract IWebDriver Create(WebDriverConstructor constructor);
    }
}
