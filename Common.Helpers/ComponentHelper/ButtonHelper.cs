using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace Common.Helpers.ComponentHelper
{
    public class ButtonHelper
    {
        private static IWebElement _element;

        public static void ClickButton(By locator)
        {
            _element = GenericHelper.GetElement(locator);
            _element.Click();
        }

        public static void ClickButton(IWebElement element)
        {
            element.Click();
        }

    }
}
