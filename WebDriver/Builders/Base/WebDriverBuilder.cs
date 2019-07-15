using OpenQA.Selenium;

namespace SeleniumProjectTemplate.WebDriver.Builders.Base
{
    public abstract class WebDriverBuilder<T> : IWebDriverBuilder where T : IWebDriver
    {
        public T WebDriver { get; protected set; }

        public abstract void Build(string binariesDirectory);

        public abstract T GetResult();
    }
}
