using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Threading;
using TechTalk.SpecFlow;
using Thesis_Code.Hooks;

namespace Thesis_Code.Steps.Thesis.Background
{
    [Binding]
    public class EShopStepDefinitions
    {
        IWebDriver WebDriver { get; }

        EShopStepDefinitions(Hooks1 hooks) => WebDriver = hooks.webDriver;

        [Given(@"The user access the following URL:")]
        public void GivenTheUserAccessTheFollowingURL(Table table)
        {
            foreach (var row in table.Rows)
            {
                WebDriver.Navigate().GoToUrl("https://www.google.com");
                Thread.Sleep(1000);
                string url = row["WebsiteURL"];
                WebDriver.Navigate().GoToUrl(url);
                // Add additional setup logic if needed
            }
        }

        [Then(@"The access page title is:")]
        public void GivenTheAccessPageTitleIs(Table table)
        {
            foreach (var row in table.Rows)
            {
                string expectedTitle = row["PageTitle"];
                string pageTitle = WebDriver.Title;

                Assert.That(pageTitle, Is.EqualTo(expectedTitle), $"The title is not '{expectedTitle}'");
            }
        }

        [Then(@"The WebPage shall contain the following sources:")]
        public void ThenTheWebPageShallContainTheFollowingSources(Table table)
        {
            foreach (var row in table.Rows)
            {
                string expectedSources = row["PageSources"];
                string pageSources = WebDriver.PageSource;

                Assert.IsTrue(pageSources.Contains(expectedSources), $"The website does not contain the text '{expectedSources}'");

            }
        }



    }
}
