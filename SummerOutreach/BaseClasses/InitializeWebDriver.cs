using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.PhantomJS;
using SummerOutreach.ComponentHelper;
using SummerOutreach.Configuration;
using SummerOutreach.CustomException;
using SummerOutreach.Settings;

namespace SummerOutreach.BaseClasses
{
    [TestClass]
    public class InitializeWebDriver
    {

        private static FirefoxProfile GetFirefoxptions()
        {
            FirefoxProfile profile = new FirefoxProfile();
            FirefoxProfileManager manager = new FirefoxProfileManager();
            return profile;
        }
        private static ChromeOptions GetChromeOptions()
        {
            ChromeOptions option = new ChromeOptions();
            option.AddArgument("start-maximized");
            option.Proxy = null;
            return option;
        }

        private static InternetExplorerOptions GetIEOptions()
        {
            InternetExplorerOptions options = new InternetExplorerOptions();
            options.IntroduceInstabilityByIgnoringProtectedModeSettings = true;
            options.EnsureCleanSession = true;
            options.ElementScrollBehavior = InternetExplorerElementScrollBehavior.Bottom;
            return options;
        }


        private static FirefoxDriver GetFirefoxDriver()
        {
            FirefoxDriver driver = new FirefoxDriver(GetFirefoxptions());
            return driver;
        }

        private static ChromeDriver GetChromeDriver()
        {
            ChromeDriver driver = new ChromeDriver(GetChromeOptions());
            return driver;
        }

        private static InternetExplorerDriver GetIEDriver()
        {
            InternetExplorerDriver driver = new InternetExplorerDriver(GetIEOptions());
            return driver;
        }

        private static PhantomJSDriver GetPhantomJsDriver()
        {
            PhantomJSDriver driver = new PhantomJSDriver(GetPhantomJsptions());

            return driver;
        }

        private static PhantomJSOptions GetPhantomJsptions()
        {
            PhantomJSOptions option = new PhantomJSOptions();
            option.AddAdditionalCapability("handlesAlerts", true);
            return option;
        }

        private static PhantomJSDriverService GetPhantomJsDrvierService()
        {
            PhantomJSDriverService service = PhantomJSDriverService.CreateDefaultService();
            service.LogFile = "TestPhantomJS.log";
            service.HideCommandPromptWindow = false;
            service.LoadImages = true;
            return service;
        }


        [AssemblyInitialize]
        public static void InitWebdriver(TestContext tc)
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
                    ObjectRepository.Driver = GetIEDriver();
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


        [AssemblyCleanup]
        public static void TearDown()
        {

            if (ObjectRepository.Driver != null)
            {
                ObjectRepository.Driver.Quit();
            }
        }
    }
}
