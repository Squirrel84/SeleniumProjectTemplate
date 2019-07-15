using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using SeleniumProjectTemplate.WebDriver.Creators.Base;
using SeleniumProjectTemplate.WebDriver;
using SeleniumProjectTemplate.WebDriver.Creators;
using Microsoft.Extensions.Configuration;
using SeleniumProjectTemplate.Extensions.Configuration;

namespace SeleniumProjectTemplate.Tests.Base
{
    /// <summary>
    /// Base class for all UI tests.
    /// </summary>
    public abstract class UITestBase : IDisposable
    {
        protected IConfiguration Configuration { get; }

        protected IWebDriver WebDriver
        {
            get;
            private set;
        }

        public UITestBase()
        {
            this.Configuration = new ConfigurationBuilder()
                    .SetBasePath(Environment.CurrentDirectory)
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                    .AddJsonFile("appsettings.local.json", optional: true, reloadOnChange: true)
                    .AddEnvironmentVariables()
                    .Build();

            Setup();
        }

        public void Dispose()
        {
            if (this.WebDriver != null)
            {
                this.WebDriver.Quit();
                this.WebDriver = null;
            }
        }

        public void Setup()
        {
            string binariesDir = Environment.CurrentDirectory;

#if IE
            IWebDriverCreator creator = new IEDriverCreator();
#endif

#if FIREFOX
            IWebDriverCreator creator = new FirefoxDriverCreator();
#endif

#if CHROME
            IWebDriverCreator creator = new ChromeDriverCreator();
#endif

            WebDriverConstructor webDriverConstructor = new WebDriverConstructor(binariesDir);
            this.WebDriver = creator.Create(webDriverConstructor);

            if (this.WebDriver == null)
            {
                throw new NullReferenceException(
                    "Please run the tests using one of the valid build " +
                    "configurations geared towards a particular browser. " +
                    "See above for details");
            }

            // Set any common/global settings against the WebDriver instance.
            this.WebDriver.Manage().Timeouts().ImplicitWait = this.Configuration.GetImplicitWait();

            this.WebDriver.Manage().Window.Maximize();
        }

        protected IWebElement CheckIfElementIsOnPage(IWebDriver driver, By byExpression)
        {
            // We return an element if we find it else we return null.
            IWebElement webElement = null;

            try
            {
                WebDriverWait waitForElement = new WebDriverWait(
                    driver,
                    this.Configuration.GetImplicitWait());

                waitForElement.Until((x) =>
                {
                    try
                    {
                        webElement = driver.FindElement(
                            byExpression);
                    }
                    catch (NoSuchElementException)
                    {
                        webElement = null;
                    }

                    return waitForElement != null;
                });
            }
            catch (TimeoutException)
            {
                webElement = null;
            }

            return webElement;
        }

        protected void SignInUser(string originalDestinationUri)
        {
            bool loggedIn = false;
            int noTimesAttemptToSignIn =
                this.Configuration.GetNoTimesAttemptToSignIn();
            int currentAttempts = 0;

            WebDriverException thrownException = null;
            while ((currentAttempts < noTimesAttemptToSignIn) && (!loggedIn))
            {
                try
                {
                    thrownException = null;

                    this.AttemptToSignInUser(originalDestinationUri);

                    loggedIn = true;
                }
                catch (NoSuchElementException noSuchElementException)
                {
                    thrownException = noSuchElementException;
                }
                catch (StaleElementReferenceException staleElementReferenceException)
                {
                    thrownException = staleElementReferenceException;
                }

                if (thrownException != null)
                {
                    currentAttempts++;
                }
            }

            if (!loggedIn)
            {
                throw new NotFoundException(
                    $"Attempted to sign into the application using " +
                    $"credentials in secrets file {noTimesAttemptToSignIn} " +
                    $"time(s), however the required elements were missing.",
                    thrownException);
            }
        }

        private void AttemptToSignInUser(string originalDestinationUri)
        {
            string username = this.Configuration.GetUsername();
            string password = this.Configuration.GetPassword();

            // Attempt to go to the URI. We should be redirect to SSO.
            this.WebDriver.Navigate().GoToUrl(originalDestinationUri);

            // Enter username
            IWebElement usernameBox =
                this.WebDriver.FindElement(By.XPath("//input[@type=\"email\"]"));

            usernameBox.SendKeys(username);

            // Click on next
            IWebElement nextButton =
                 this.WebDriver.FindElement(By.XPath("//input[@value=\"Next\"]"));

            nextButton.SendKeys(Keys.Enter);

            // Enter the password, but synchonise first.
            // double time for sign in page to appear
            WebDriverWait waitForPasswordPage = new WebDriverWait(
                this.WebDriver,
                this.Configuration.GetImplicitWait() * 2);

            IWebElement passwordBox = null;

            // wait for the password input
            waitForPasswordPage.Until((x) =>
            {
                passwordBox =
                    this.WebDriver.FindElement(By.Id("passwordInput"));

                return passwordBox != null;
            });

            passwordBox.SendKeys(password);

            // Press the Sign in button
            var signInButton =
               this.WebDriver.FindElement(By.Id("submitButton"));

            signInButton.SendKeys(Keys.Enter);

            // Hit the "No" button
            IWebElement noButton =
                this.WebDriver.FindElement(By.XPath("//input[@id=\"idBtn_Back\"]"));

            noButton.SendKeys(Keys.Enter);
        }
    }
}