using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Helpers.ComponentHelper;
using Common.Helpers.Configuration;
using Common.Helpers.CustomException;
using Common.Helpers.Settings;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.PhantomJS;


namespace Common.Helpers.BaseClasses
{
    [TestClass]
    public class InitializeWebDriver : DeployResources
    {

        private static FirefoxProfile GetFirefoxptions()
        {
            var profile = new FirefoxProfile();
            profile.AddExtension(@"C:\downloads\FirefoxGoogleAnalytics.xpi");
            return profile;
        }
        private static ChromeOptions GetChromeOptions()
        {
            var option = new ChromeOptions();
            option.AddArgument("start-maximized");
            option.AddExtension(@"C:\downloads\GoogleAnalytics.crx");
            option.Proxy = null;
            return option;
        }

        private static InternetExplorerOptions GetIeOptions()
        {
            var options = new InternetExplorerOptions
            {
                IntroduceInstabilityByIgnoringProtectedModeSettings = true,
                EnsureCleanSession = true,
                ElementScrollBehavior = InternetExplorerElementScrollBehavior.Bottom
            };
            return options;
        }


        private static FirefoxDriver GetFirefoxDriver()
        {
            var driver = new FirefoxDriver(GetFirefoxptions());
            return driver;
        }

        private static ChromeDriver GetChromeDriver()
        {
            var driver = new ChromeDriver(GetChromeOptions());
            return driver;
        }

        private static InternetExplorerDriver GetIeDriver()
        {
            var driver = new InternetExplorerDriver(GetIeOptions());
            return driver;
        }

        private static PhantomJSDriver GetPhantomJsDriver()
        {
            var driver = new PhantomJSDriver(GetPhantomJsptions());

            return driver;
        }

        private static PhantomJSOptions GetPhantomJsptions()
        {
            var option = new PhantomJSOptions();
            option.AddAdditionalCapability("handlesAlerts", true);
            return option;
        }

        private static PhantomJSDriverService GetPhantomJsDrvierService()
        {
            var service = PhantomJSDriverService.CreateDefaultService();
            service.LogFile = "TestPhantomJS.log";
            service.HideCommandPromptWindow = false;
            service.LoadImages = true;
            return service;
        }


        [TestInitialize]
        public void InitWebdriver()
        {
            ObjectRepository.Config = new AppConfigReader();

            switch (ObjectRepository.Config.GetBrowser())
            {
                case BrowserType.Firefox:
                    ObjectRepository.Driver = GetFirefoxDriver();
                    break;

                case BrowserType.Chrome:
                    ObjectRepository.Driver = GetChromeDriver();
                    break;

                case BrowserType.InternetExplorer:
                    ObjectRepository.Driver = GetIeDriver();
                    break;

                case BrowserType.PhantomJs:
                    ObjectRepository.Driver = GetPhantomJsDriver();
                    break;

                default:
                    throw new NoSutiableDriverFound("Driver Not Found : " + ObjectRepository.Config.GetBrowser().ToString());
            }
            ObjectRepository.Driver.Manage()
                .Timeouts()
                .SetPageLoadTimeout(TimeSpan.FromSeconds(ObjectRepository.Config.GetPageLoadTimeOut()));
            ObjectRepository.Driver.Manage().
                Timeouts().
                ImplicitlyWait(TimeSpan.FromSeconds(ObjectRepository.Config.GetElementLoadTimeOut()));
            GenericHelper.WindowMaximize();
            ObjectRepository.Driver.Navigate().GoToUrl(ObjectRepository.Config.GetWebsite());
            if (GenericHelper.IsElementPresentQuick(By.Id("overridelink")))
            {
                ObjectRepository.Driver.FindElement(By.Id("overridelink")).Click();
            }

        }


        [TestCleanup]
        public void TearDown()
        {

            if (ObjectRepository.Driver != null)
            {
                ObjectRepository.Driver.Quit();
            }
        }
    }
}
