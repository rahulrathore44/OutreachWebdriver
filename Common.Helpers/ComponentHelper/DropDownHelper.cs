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

        public static void SelectByVisibleText(By locator, string text)
        {
            _select = new SelectElement(GenericHelper.GetElement(locator));
            _select.SelectByText(text);
        }

        public static void SelectByVisibleText(IWebElement element, string text)
        {
            _select = new SelectElement(element);
            _select.SelectByText(text);
        }
        
    }
}
