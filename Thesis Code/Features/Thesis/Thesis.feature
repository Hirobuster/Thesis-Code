Feature: EShop

A short summary of the feature

Background: 
	Given The user access the following URL:
	| WebsiteURL                                           |
	| https://eshop-onweb-webinar-demo2.azurewebsites.net/ |
	Then The access page title is:
	| PageTitle                      |
	| Catalog - Microsoft.eShopOnWeb |
	And The WebPage shall contain the following sources:
	| PageSources                      |
	| eShop On Web                     |
	| e-ShopOnWeb. All rights reserved |
					

@tag1
Scenario: Login functionality
    Given the user is on the specific webpage
	| PageSources                            |
	| e-ShopOnWeb. All rights reserved       |
	| Showing 10 of 12 products - Page 1 - 2 |
    When the user clicks on the login button
	| ExpectedLoginButtonText | ExpectedLoginPageTitle        |
	| Login                   | Log in - Microsoft.eShopOnWeb |
    Then the user should be redirected to the login page
	| PageTitle                     | PageSources                                                                                  |
	| Log in - Microsoft.eShopOnWeb | Log in                                                                                       |
	|                               | Password                                                                                     |
	|                               | Remember me?                                                                                 |
	|                               | Register as a new user                                                                       |
	|                               | Note that for demo purposes you don't need to register and can login with these credentials: |
	And The user logs in using his email and password
	| Email                  | Password   |
	| demouser@microsoft.com | Pass@word1 |