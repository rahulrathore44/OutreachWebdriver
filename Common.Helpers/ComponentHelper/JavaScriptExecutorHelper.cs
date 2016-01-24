using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Common.Helpers.Settings;
using OpenQA.Selenium;


namespace Common.Helpers.ComponentHelper
{
    public class JavaScriptExecutorHelper
    {
        private static IJavaScriptExecutor exeScript;

        public static object ExecuteScript(string script)
        {
            exeScript = ((IJavaScriptExecutor)ObjectRepository.Driver);
            return exeScript.ExecuteScript(script);
        }


        public static void ScrollElementAndClick(IWebElement element)
        {
            Thread.Sleep(500);
            ExecuteScript("window.scrollTo(0," + element.Location.Y + ");");
            element.Click();
        }

        public static void ScrollToElement(IWebElement element)
        {
            Thread.Sleep(500);
            ExecuteScript("window.scrollTo(0," + element.Location.Y + ");");
        }

        public static void ScrollElementAndClick(By locator)
        {
            IWebElement element = ObjectRepository.Driver.FindElement(locator);
            GenericHelper.WaitForElement(element);
            ExecuteScript("window.scrollTo(0," + element.Location.Y + ");");
            element.Click();
        }
    }
}
