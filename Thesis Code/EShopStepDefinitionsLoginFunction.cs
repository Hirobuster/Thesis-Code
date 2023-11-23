using NUnit.Framework;
using OpenQA.Selenium;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using Thesis_Code.Hooks;
using System;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using System.Linq;
using OpenQA.Selenium.Chrome;
using SeleniumExtras.WaitHelpers;

namespace Thesis_Code
{
    [Binding]
    public class EShopStepDefinitionsLoginFunction
    {
        IWebDriver WebDriver { get; }

        EShopStepDefinitionsLoginFunction(Hooks1 hooks) => WebDriver = hooks.webDriver;


        [Given(@"the user is on the specific webpage")]
        public void GivenTheUserIsOnTheSpecificWebpage(Table table)
        {
            foreach (var row in table.Rows)
            {
                string expectedSources = row["PageSources"];
                string pageSources = WebDriver.PageSource;

                Assert.IsTrue(pageSources.Contains(expectedSources), $"The website does not contain the text '{expectedSources}'");

            }
        }




        [When(@"the user clicks on the login button")]
        public void WhenTheUserClicksOnTheLoginButton(Table table)
        {
            string expectedLoginButtonText = table.Rows[0]["ExpectedLoginButtonText"];

            IList<IWebElement> loginElements = WebDriver.FindElements(By.XPath($"//*[contains(translate(text(), 'ABCDEFGHIJKLMNOPQRSTUVWXYZ', 'abcdefghijklmnopqrstuvwxyz'), '{expectedLoginButtonText.ToLower()}')]"));

            TryEachLoginElement(loginElements, table);
        }

        private void TryEachLoginElement(IList<IWebElement> loginElements, Table table)
        {
            bool loginSuccessful = false;
            string expectedLoginPageTitle = table.Rows[0]["ExpectedLoginPageTitle"];

            foreach (var loginElement in loginElements)
            {
                string text = loginElement.Text;
                loginElement.Click();

                string loginPageTitle = WebDriver.Title;

                Assert.AreEqual(expectedLoginPageTitle, loginPageTitle, "Page title does not match the expected login page title");

                if (IsConditionMet(loginPageTitle, expectedLoginPageTitle))
                {
                    loginSuccessful = true;
                    break;
                }
                else
                {
                    WebDriver.Navigate().Back();
                }
            }

            if (!loginSuccessful)
            {
                Assert.Fail("Login was not successful");
            }
        }

        private bool IsConditionMet(string pageTitle, string expectedTitle)
        {
            return pageTitle == expectedTitle;
        }





        [Then(@"the user should be redirected to the login page")]
        public void ThenTheUserShouldBeRedirectedToTheLoginPage(Table table)
        {
            foreach (var row in table.Rows) 
            {
                string expectedTitle = row["PageTitle"];
                string pageTitle = WebDriver.Title;

                Assert.IsTrue(pageTitle.Contains(expectedTitle), $"The Website does not contain the text '{expectedTitle}'");
            }
    
            foreach (var row in table.Rows)
            {
                string expectedSources = row["PageSources"];
                string pageSources = WebDriver.PageSource;

                Assert.IsTrue(pageSources.Contains(expectedSources), $"The website does not contain the text '{expectedSources}'");
            }
        }

        [Then(@"The user logs in using his email and password")]
        public void WhenTheUserLogsInUsingHisEmailAndPassword(Table table)
        {
            string userEmail = table.Rows[0]["Email"];
            string userPassword = table.Rows[0]["Password"];

            // Find the input field associated with the 'email' label (case-insensitive)
            IWebElement emailInput = WebDriver.FindElement(By.XPath("//*[translate(text(), 'ABCDEFGHIJKLMNOPQRSTUVWXYZ', 'abcdefghijklmnopqrstuvwxyz') = 'email']/following-sibling::input"));
            emailInput.SendKeys(userEmail);

            // Find the input field associated with the 'password' label (case-insensitive)
            IWebElement passwordInput = WebDriver.FindElement(By.XPath("//*[translate(text(), 'ABCDEFGHIJKLMNOPQRSTUVWXYZ', 'abcdefghijklmnopqrstuvwxyz') = 'password']/following-sibling::input"));
            passwordInput.SendKeys(userPassword);

            // Locate and click the 'login' or 'log in' button (case-insensitive)
            IWebElement loginButton = WebDriver.FindElement(By.XPath("//button[contains(translate(text(), 'ABCDEFGHIJKLMNOPQRSTUVWXYZ', 'abcdefghijklmnopqrstuvwxyz'), 'login') or contains(translate(text(), 'ABCDEFGHIJKLMNOPQRSTUVWXYZ', 'abcdefghijklmnopqrstuvwxyz'), 'log in')]"));
            loginButton.Click();
        }

    }
}
