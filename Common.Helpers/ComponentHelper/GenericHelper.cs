using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Helpers.Settings;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;


namespace Common.Helpers.ComponentHelper
{
    public class GenericHelper
    {
        #region Field

        private static string maskXpath = "//span[text()='Loading...']";
        private static string ajaxLoader = "//img[@id='ajaxLoader' and contains(@style,'inline')]";

        #endregion

        #region Private

        private static Func<IWebDriver, bool> MaskPresence(string path)
        {
            return ((x) =>
            {
                if (x.FindElements((By.XPath(path))).Any())
                    return false;
                return true;
            });
        }

        private static Func<IWebDriver, bool> CheckForElement(By locator)
        {
            return ((x) =>
            {
                if (x.FindElements(locator).Any())
                    return true;
                return false;
            });
        }

        #endregion


        #region Public

        public static void WaitForLoadingMask()
        {
            ObjectRepository.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(1));
            var wait = GetWebDriverWait(60);
            wait.Until(MaskPresence(maskXpath));
            ObjectRepository.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(ObjectRepository.Config.GetElementLoadTimeOut()));
        }

        public static void WaitForAjaxLoader()
        {
            ObjectRepository.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(1));
            var wait = GetWebDriverWait(60);
            wait.Until(MaskPresence(ajaxLoader));
            ObjectRepository.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(ObjectRepository.Config.GetElementLoadTimeOut()));
        }


        public static WebDriverWait GetWebDriverWait(int timeOutInSeconds)
        {
            var wait = new WebDriverWait(ObjectRepository.Driver, TimeSpan.FromSeconds(timeOutInSeconds))
            {
                PollingInterval = TimeSpan.FromMilliseconds(250)
            };
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException));
            return wait;

        }
        public static bool IsElementPresent(By locator)
        {
            try
            {
                var wait = GetWebDriverWait(60);
                return wait.Until((CheckForElement(locator)));
            }
            catch (TimeoutException )
            {
                return false;
            }

        }

        public static bool IsElementPresentQuick(By locator)
        {
            try
            {
                if (ObjectRepository.Driver.FindElements(locator).Count() == 1)
                    return true;
                return false;
            }
            catch (Exception )
            {
                return false;
            }
        }

        public static IWebElement GetElement(By locator)
        {
            if (IsElementPresent(locator))
                return ObjectRepository.Driver.FindElement(locator);
            throw new NoSuchElementException("Element Not Found : " + locator.ToString());
        }

        public static IReadOnlyCollection<IWebElement> GetElements(By locator)
        {
            return ObjectRepository.Driver.FindElements(locator);
        }

        public static IWebElement GetVisiblityOfElement(By locator)
        {
            var wait = GetWebDriverWait(60);
            return wait.Until(ExpectedConditions.ElementIsVisible(locator));
        }

        public static void WindowMaximize()
        {
            ObjectRepository.Driver.Manage().Window.Maximize();
        }

        public static void SetPageLoadTimeOut(int timeout)
        {
            ObjectRepository.Driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(timeout));
        }

        public static void SetElementLoadTimeOut(int timeout)
        {
            ObjectRepository.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(timeout));
        }

        public static IWebElement WaitForElement(By locator)
        {
            var wait = GetWebDriverWait(60);
            return wait.Until(ExpectedConditions.ElementExists(locator));
        }

        public static IWebElement WaitForElement(By locator,int timeout)
        {
            var wait = GetWebDriverWait(timeout);
            return wait.Until(ExpectedConditions.ElementExists(locator));
        }

        public static IWebElement WaitForElementClickAble(By locator)
        {
            var wait = GetWebDriverWait(60);
            return wait.Until(ExpectedConditions.ElementToBeClickable(locator));
        }

        public static IWebElement WaitForElementClickAble(IWebElement element)
        {
            var wait = GetWebDriverWait(60);
            return wait.Until(ExpectedConditions.ElementToBeClickable(element));
        }

        public static IWebElement WaitForElement(IWebElement element)
        {
            var wait = GetWebDriverWait(60);
            return wait.Until(ExpectedConditions.ElementToBeClickable(element));
        }

        

        public static void WaitForAlert()
        {
            ObjectRepository.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(1));
            var wait = GetWebDriverWait(60);
            wait.Until(ExpectedConditions.AlertIsPresent());
            ObjectRepository.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(ObjectRepository.Config.GetElementLoadTimeOut()));
        }

        public static string GetText(By locator)
        {
            if (IsElementPresent(locator))
                return ObjectRepository.Driver.FindElement(locator).Text;
            return null;
        }

        public static bool IsAlertPresent()
        {
            try
            {
                ObjectRepository.Driver.SwitchTo().Alert();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static void TakeSceenShot(string name = null)
        {
            if (name == null)
            {
                name = "Screenshot" + DateTime.UtcNow.ToString("yy-MMM-dd-mm") + ".jpeg";
            }
            else
            {
                name = name + ".jpeg";
            }
            var src = ObjectRepository.Driver.TakeScreenshot();
            src.SaveAsFile(name, ImageFormat.Jpeg);
        }

        #endregion
    }
}
