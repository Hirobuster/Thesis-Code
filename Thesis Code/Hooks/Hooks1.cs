using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace Thesis_Code.Hooks
{
    [Binding]
    public class Hooks1
    {
        // public static IWebDriver webDriver;
        public IWebDriver webDriver { get; set; }

        // [BeforeTestRun] hook is executed once before the entire test run.
        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            // Perform global setup before the entire test run
            // This method is suitable for initializing resources needed for the entire test run.
            // For instance, setting up a database connection, initializing global variables, etc.
        }

        // [BeforeFeature] hook is executed before each feature.
        [BeforeFeature]
        public static void BeforeFeature()
        {
            // Perform feature-specific setup
            // This method is useful for setting up resources specific to each feature.
            // For example, initializing feature-specific configurations, environment setup, etc.
        }

        // [BeforeScenario] hook is executed before each scenario.
        [BeforeScenario(Order = 1)]
        public void FirstBeforeScenario()
        {
            // Perform scenario-specific setup
            // This method can be used to set up the context necessary for individual scenarios.
            // For instance, preparing test data, setting initial conditions, etc.
            // This method is executed before each scenario.
            // It initializes the WebDriver instance with ChromeDriver.

            webDriver = new ChromeDriver();
            webDriver.Manage().Window.Maximize();

        }

        [BeforeScenario("@Task3")]
        public void BeforeScenarioAddToCart()
        {
            // This method is executed before scenarios tagged with @Task3.
            // You can add specific setup actions for scenarios with this tag.
        }

        // [AfterScenario] hook is executed after each scenario.
        [AfterScenario]
        public void AfterScenario()
        {
            // Perform scenario-specific teardown or cleanup tasks
            // This method is useful for cleaning up resources or performing actions after each scenario execution.
            // For example, closing browser sessions, releasing resources, capturing screenshots, etc.

            // It waits for 10 seconds, quits the WebDriver, and disposes of it.

            Thread.Sleep(10000);
            webDriver.Quit();
            webDriver.Dispose();
            
            
        }

        // [AfterTestRun] hook is executed once after the entire test run.
        [AfterTestRun]
        public static void AfterTestRun(IWebDriver webDriver)
        {
            // Perform global teardown after the entire test run
            // This method can be used for cleaning up resources used during the entire test run.
            // For example, closing database connections, releasing global resources, etc.
        }

    }
}
