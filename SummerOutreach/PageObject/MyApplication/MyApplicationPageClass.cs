using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SummerOutreach.BaseClasses;

namespace SummerOutreach.PageObject.MyApplication
{
    public class MyApplicationPageClass : PageBase
    {
        #region Constructor

        public MyApplicationPageClass(IWebDriver driver) : base(driver) { }

        #endregion

        #region WebElements

        [FindsBy(How = How.XPath, Using = "//button[contains(.,'Combined Summer Undergraduate Research Opportunity')]")]
        public IWebElement CombinedSummerProgram { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[contains(.,'High School Health Careers Program')]")]
        public IWebElement HighSchoolProgram { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[contains(.,'New application')]")]
        public IWebElement NewApplication { get; set; }

        #endregion
    }
}
