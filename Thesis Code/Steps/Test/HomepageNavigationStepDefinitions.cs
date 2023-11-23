using NUnit.Framework;
using OpenQA.Selenium;
using System.Threading;
using TechTalk.SpecFlow;
using Thesis_Code.Hooks;

namespace Thesis_Code.Steps.Test
{
    [Binding]
    public class HomepageNavigationStepDefinitions
    {
        IWebDriver WebDriver { get; }

        HomepageNavigationStepDefinitions(Hooks1 hooks) => WebDriver = hooks.webDriver;

        [Given(@"I am on the eShop-onWeb website")]
        public void GivenIAmOnTheEShopOnWebWebsite()
        {
            WebDriver.Navigate().GoToUrl("https://www.google.com");
            Thread.Sleep(3000);
        }

        [When(@"I navigate to the homepage")]
        public void WhenINavigateToTheHomepage()
        {
            WebDriver.Navigate().GoToUrl("https://eshop-onweb-webinar-demo2.azurewebsites.net/");
        }

        [Then(@"I should see the homepage content")]
        public void ThenIShouldSeeTheHomepageContent()
        {
            string pageTitle = WebDriver.Title;

            Assert.That(pageTitle, Is.EqualTo("Catalog - Microsoft.eShopOnWeb"), "The homepage title is not 'Catalog - Microsoft.eShopOnWeb'");
        }
    }
}
