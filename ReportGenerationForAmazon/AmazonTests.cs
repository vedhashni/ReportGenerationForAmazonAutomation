/*summary :Report Generation For Amazon Automation 
  Author: Vedhashni V
  Date  : 15-09-21
*/

using AventStack.ExtentReports;
using NUnit.Framework;

namespace ReportGenerationForAmazon
{
    public class AmazonTests:Base.BaseClass
    {
        ExtentReports report = Report.report();
        ExtentTest test;

        //Used to test the tile after launcing the browser
        [Test, Order(0)]
        public void TestMethodTitleAfterLaunching()
        {
            WebPageAction.SignInAction.TitleAfterLaunching(driver);
        }

        //Used to read the data from excel
        //Used to login into Amazon with credentials given in the excel
        [Test, Order(1)]
        public void TestMethodForLoginIntoAmazon()
        {
            test = report.CreateTest("AmazonTests");
            test.Log(Status.Info, "Amazon Automation");
            WebPageAction.SignInAction.ReadDataFromExcel(driver);
            WebPageAction.SignInAction.LoginIntoAmazon(driver);
            test.Log(Status.Pass, "TestCases Passed");
            report.Flush();
        }
    }
}
