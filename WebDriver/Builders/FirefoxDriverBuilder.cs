using OpenQA.Selenium.Firefox;
using SeleniumProjectTemplate.WebDriver.Builders.Base;

namespace SeleniumProjectTemplate.WebDriver.Builders
{
    public class FirefoxDriverBuilder : WebDriverBuilder<FirefoxDriver>
    {
        public override void Build(string binariesDirectory)
        {
            FirefoxOptions firefoxOptions = new FirefoxOptions()
            {
                AcceptInsecureCertificates = true,
            };

            this.WebDriver = new FirefoxDriver(binariesDirectory, firefoxOptions);
        }

        public override FirefoxDriver GetResult()
        {
            return this.WebDriver;
        }
    }
}