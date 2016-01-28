using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Helpers.ComponentHelper;
using OpenQA.Selenium;

namespace Common.Helpers.ComponentHelper
{
    public class ValidationHelper
    {
        public static bool IsErrorMsgPresent(string message)
        {
            return GenericHelper.GetElements(By.XPath("//li[contains(.,'" + message + "')]")).Count > 0;
        }

        //legend[text()='Demographic Information']

        public static bool IsPageTitlePresent(string title)
        {
            return GenericHelper.GetElements(By.XPath("//legend[contains(.,'" + title + "')]")).Count > 0;
        }
    }
}
