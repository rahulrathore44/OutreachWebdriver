using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;


namespace Common.Helpers.ComponentHelper
{
    public class DropDownHelper
    {
        private static SelectElement _select;

        #region Private

        private static string GetXpathUsingLabel(string labelText)
        {
            return
                "//label[contains(.,'" + labelText + "')]/following-sibling::span[position()=1]/descendant::span[contains(text(),'Select')]";
        }

        private static string GetListElement(string value)
        {
            return "//li[text()='" + value + "']";
        }

        #endregion

        #region Public

        public static IList<IWebElement> GetAllOptions(IWebElement element)
        {
            _select = new SelectElement(element);
            return _select.Options;
        }

      

        public static void SelectByVisibleText(By locator, string text)
        {
            _select = new SelectElement(GenericHelper.GetElement(locator));
            _select.SelectByText(text);
        }

        public static void SelectByIndex(By locator,int index)
        {
            _select = new SelectElement(GenericHelper.GetElement(locator));
            _select.SelectByIndex(index);
        }

        public static void SelectByVisibleText(IWebElement element, string text)
        {
            _select = new SelectElement(element);
            _select.SelectByText(text);
        }

        public static void SelectFromDropDownWithLabel(string label, string value)
        {
            var arrow = GenericHelper.GetElement(By.XPath(GetXpathUsingLabel(label)));
            JavaScriptExecutorHelper.ScrollElementAndClick(arrow);
            Thread.Sleep(1000);
            var list = GenericHelper.GetVisiblityOfElement(By.XPath(GetListElement(value)));
            list.Click();
            Thread.Sleep(1000);
        }

        public static bool VerifyInOptions(IWebElement element, string text)
        {
            var list = GetAllOptions(element);
            foreach (var ele in list)
            {
                Console.WriteLine(ele.Text);
            }
            var result = list.FirstOrDefault((x) => x.Text.Contains(text));
            return (result != null);
        }

        public static void WaitForToLoad(IWebElement element, TimeSpan? timeout = null)
        {
            var list = GetAllOptions(element);
        }

        #endregion
    }
}
