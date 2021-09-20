using OpenQA.Selenium;
using NUnit.Framework;
using ReportGenerationForAmazon.Data;
using System;

namespace ReportGenerationForAmazon.WebPageAction
{
    public class SignInAction
    {
        public static SignIn sign;
        public static ExcelOperation excel;

        //Used to check title given and retived are same
        public static void TitleAfterLaunching(IWebDriver driver)
        {
            string title1 = "Online Shopping site in India: Shop Online for Mobiles, Books, Watches, Shoes and More - Amazon.in";
            string title = driver.Title;
            //AreEqual is used to compare expected and actual result
            Assert.AreEqual(title1, title);
        }

        //Here we are reading the data from excel
        public static void ReadDataFromExcel(IWebDriver driver)
        {
            excel = new ExcelOperation();
            excel.PopulateFromExcel(@"C:\Users\vedhashni.v\source\repos\ReportGenerationForAmazon\ReportGenerationForAmazon\Data\SignInData.xlsx");
        }

        //Used for implementing login operations
        public static void LoginIntoAmazon(IWebDriver driver)
        {
            excel = new ExcelOperation();
            sign = new SignIn(driver);
            TakeScreenShot(driver);
            sign.login.Click();
            System.Threading.Thread.Sleep(1000);
            TakeScreenShot(driver);
            //By invoking the readdate method values in table is retrived
            sign.email.SendKeys(excel.ReadData(1, "Email"));
            TakeScreenShot(driver);
            //is used to wait in a particular page before taking another action
            System.Threading.Thread.Sleep(1000);
            //Here we click continue button for further process
            sign.continuebtn.Click();
            //is used to wait in a particular page before taking another action
            System.Threading.Thread.Sleep(1000);
            //By invoking the readdate method values in table is retrived
            sign.password.SendKeys(excel.ReadData(1, "Password"));
            TakeScreenShot(driver);
            System.Threading.Thread.Sleep(1000);
            sign.signin.Click();
            TakeScreenShot(driver);
            System.Threading.Thread.Sleep(10000);
            //Here we call Searchproductsinamazonafterlogin method for searching the product
            SearchProductsInAmazonAfterLogin(driver);
        }

        //Here we use Searchproductsinamazonafterlogin method for searching the product
        public static void SearchProductsInAmazonAfterLogin(IWebDriver driver)
        {
            TakeScreenShot(driver);
            //Here search bar element is finded
            IWebElement element = driver.FindElement(By.Id("twotabsearchtextbox"));
            //By using this search bar is clicked
            element.SendKeys(Keys.Control + "a");
            TakeScreenShot(driver);
            System.Threading.Thread.Sleep(500);
            //Value is sent to find specific product
            element.SendKeys("wa");
            TakeScreenShot(driver);
            System.Threading.Thread.Sleep(500);
            //By keys class arrowup used to select the value listed down the search bar
            element.SendKeys(Keys.ArrowUp);
            System.Threading.Thread.Sleep(500);
            //By keys class arrowdown used to select the value listed down the search bar
            element.SendKeys(Keys.ArrowDown);
            System.Threading.Thread.Sleep(500);
            element.SendKeys(Keys.ArrowDown);
            System.Threading.Thread.Sleep(500);
            TakeScreenShot(driver);
            //By using this particular product is searched by clicking the enter key instead search icon
            element.SendKeys(Keys.Enter);
            TakeScreenShot(driver);
            System.Threading.Thread.Sleep(10000);
        }

        //Used to takescreenshot of the webactions done
        public static void TakeScreenShot(IWebDriver driver)
        {
            ITakesScreenshot screenshot = driver as ITakesScreenshot;
            Screenshot screenshot1 = screenshot.GetScreenshot();
            screenshot1.SaveAsFile(@"C:\Users\vedhashni.v\source\repos\ReportGenerationForAmazon\ReportGenerationForAmazon\TestScreenShots\AmazonTest" + DateTime.Now.ToString("HHmmss") + ".png");
        }
    }
}
