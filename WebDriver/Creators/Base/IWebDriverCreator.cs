using OpenQA.Selenium;

namespace SeleniumProjectTemplate.WebDriver.Creators.Base
{
    public interface IWebDriverCreator
    {
        IWebDriver Create(WebDriverConstructor webDriverConstructor);
    }
}