using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SummerOutreach.ComponentHelper
{
    public class DropDownHelper
    {
        private static SelectElement select;

        public static void SelectByVisibleText(By locator, string text)
        {
            select = new SelectElement(GenericHelper.GetElement(locator));
            select.SelectByText(text);
        }

        public static void SelectByVisibleText(IWebElement element, string text)
        {
            select = new SelectElement(element);
            select.SelectByText(text);
        }
        
    }
}
