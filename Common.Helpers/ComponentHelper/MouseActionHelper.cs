using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Helpers.Settings;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;

namespace Common.Helpers.ComponentHelper
{
    public class MouseActionHelper
    {
        #region Public

        public static void PerformClick(By @locator)
        {
            var element = ObjectRepository.Driver.FindElement(locator);
            var action = new Actions(ObjectRepository.Driver);

            var perform = action.DoubleClick(element)
                .Build();

            perform.Perform();
        }

        #endregion
    }
}
