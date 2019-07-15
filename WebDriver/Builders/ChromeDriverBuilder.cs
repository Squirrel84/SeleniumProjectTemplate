using OpenQA.Selenium.Chrome;
using SeleniumProjectTemplate.WebDriver.Builders.Base;

namespace SeleniumProjectTemplate.WebDriver.Builders
{
    public class ChromeDriverBuilder : WebDriverBuilder<ChromeDriver>
    {
        public override void Build(string binariesDirectory)
        {
            this.WebDriver = new ChromeDriver(binariesDirectory);
        }

        public override ChromeDriver GetResult()
        {
            return this.WebDriver;
        }
    }
}