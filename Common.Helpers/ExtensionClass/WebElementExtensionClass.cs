using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace Common.Helpers.ExtensionClass
{
    public static class WebElementExtensionClass
    {
        public static void SendKeyIfEmpty(this IWebElement element,string text)
        {
            if(string.Empty.Equals(element.Text))
                element.SendKeys(text);
        }
    }
}
