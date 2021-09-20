using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;


namespace ReportGenerationForAmazon
{
    public class Report
    {
        public static ExtentHtmlReporter htmlReporter;
        public static ExtentReports extent;
        public static ExtentTest test;

        public static ExtentReports report()
        {

            if (extent == null)
            {

                string reportPath = @"C:\Users\vedhashni.v\source\repos\ReportGenerationForAmazon\ReportGenerationForAmazon\Report\AmazonReport.html";
                htmlReporter = new ExtentHtmlReporter(reportPath);
                extent = new ExtentReports();
                extent.AttachReporter(htmlReporter);
                extent.AddSystemInfo("OS", "Windows");
                extent.AddSystemInfo("UserName", "vedhashni");
                extent.AddSystemInfo("ProviderName", "vedhashni");
                extent.AddSystemInfo("Domain", "QA");
                extent.AddSystemInfo("ProjectName", "Amazon Automation");

                string conifgPath = @"C:\Users\vedhashni.v\source\repos\ReportGenerationForAmazon\ReportGenerationForAmazon\Report\extent-config.xml";
                htmlReporter.LoadConfig(conifgPath);
            }
            return extent;
        }

    }
}
