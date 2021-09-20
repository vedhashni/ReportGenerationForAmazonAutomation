using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace ReportGenerationForAmazon.Data
{
    public class SignIn
    {
        //Used to intialize elements of a page class
        public SignIn(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        //Used to find the sigin button by specifying its locator
        [FindsBy(How = How.XPath, Using = "//a[@id='nav-link-accountList']")]
        [CacheLookup]
        public IWebElement login;

        //Used to find the element email by specifying its locator
        [FindsBy(How = How.Name, Using = "email")]
        [CacheLookup]
        public IWebElement email;

        //Used to find the continue button by specifying its locator
        [FindsBy(How = How.Id, Using = "continue")]
        [CacheLookup]
        public IWebElement continuebtn;

        //Used to find the element password by specifying its locator
        [FindsBy(How = How.Id, Using = "ap_password")]
        [CacheLookup]
        public IWebElement password;

        //Used to find the signin button by specifying its locator
        [FindsBy(How = How.Id, Using = "signInSubmit")]
        [CacheLookup]
        public IWebElement signin;
    }
}
