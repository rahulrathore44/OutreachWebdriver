using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CFM.Registration.BaseClasses;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace CFM.Registration.PageObject.HomePage
{
    public class HomePageClass : PageBase
    {
        #region Constructor

         public HomePageClass(IWebDriver driver) : base(driver) { }

        #endregion

        #region WebElements

        [FindsBy(How = How.Id,Using = "ddProgram")]
        public IWebElement Program { get; set; }

        [FindsBy(How = How.Id, Using = "ddSessionType")]
        public IWebElement SessionType { get; set; }

        [FindsBy(How = How.Id, Using = "ddSession")]
        public IWebElement Session { get; set; }

        #endregion
    }
}
