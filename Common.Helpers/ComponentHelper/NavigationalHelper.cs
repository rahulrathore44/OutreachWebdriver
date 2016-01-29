using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Helpers.Settings;

namespace Common.Helpers.ComponentHelper
{
    public class NavigationalHelper
    {
        #region Public

        public static void NavigateToUrl(string url)
        {
            ObjectRepository.Driver.Navigate().GoToUrl(url);
        }

        #endregion
    }
}
