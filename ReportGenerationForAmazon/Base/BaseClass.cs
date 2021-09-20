using log4net;
using log4net.Config;
using log4net.Repository;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using System.Reflection;

namespace ReportGenerationForAmazon.Base
{
    public class BaseClass
    {
        public static IWebDriver driver;
        //Get Logger for fully qualified name for type of 'AlertTests' class
        private static readonly ILog log = LogManager.GetLogger(typeof(AmazonTests));

        //Get the default ILoggingRepository
        private static readonly ILoggerRepository repository = LogManager.GetRepository(Assembly.GetCallingAssembly());

        [SetUp]
        public void SetUp()
        {
            //BasicConfigurator.Configure();
            // Valid XML file with Log4Net Configurations
            var fileInfo = new FileInfo(@"log4net.config");

            // Configure default logging repository with Log4Net configurations
            XmlConfigurator.Configure(repository, fileInfo);
            try
            {
                log.Info("Configured");
                driver = new ChromeDriver();
                driver.Url = "https://www.amazon.in/";
                log.Debug("navigating to url");
                //Used to maximize the window
                driver.Manage().Window.Maximize();
                log.Info("Window is maximized");
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }

        }
        [TearDown]
        public void TearDown()
        {
            //Used to close the opened session
            driver.Quit();
        }
    }
}
