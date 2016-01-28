using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace Common.Helpers.ComponentHelper
{
    public class TextBoxHelper
    {
        #region Fields

        private static IWebElement _element;

        #endregion

        #region Static

        public static void TypeInTextBox(By locator, string text)
        {
            _element = GenericHelper.GetElement(locator);
            _element.SendKeys(text);
        }

        public static void TypeInTextBox(IWebElement element, string text)
        {
            element.SendKeys(text);
        }

        public static void ClearTextBox(By locator)
        {
            _element = GenericHelper.GetElement(locator);
            _element.Clear();
        }

        public static void ClearTextBox(IWebElement element)
        {
            element.Clear();
        }

        #endregion



    }
}
