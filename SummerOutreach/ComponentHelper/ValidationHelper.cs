using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace SummerOutreach.ComponentHelper
{
    public class ValidationHelper
    {
        public static bool IsErrorMsgPresent(string message)
        {
            return GenericHelper.GetElements(By.XPath("//li[contains(.,'" + message + "')]")).Count > 0;
        }
    }
}
