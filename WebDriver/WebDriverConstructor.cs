using SeleniumProjectTemplate.WebDriver.Builders.Base;

namespace SeleniumProjectTemplate.WebDriver
{
    public class WebDriverConstructor
    {
        private readonly string binariesDirectory;

        public WebDriverConstructor(string binariesDirectory)
        {
            this.binariesDirectory = binariesDirectory;
        }

        public void Construct(IWebDriverBuilder builder)
        {
            builder.Build(this.binariesDirectory);
        }
    }
}
