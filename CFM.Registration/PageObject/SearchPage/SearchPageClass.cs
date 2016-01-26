using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CFM.Registration.BaseClasses;
using CFM.Registration.BaseClasses.HeaderBasePage;
using CFM.Registration.PageObject.ManageProgramDates;
using Common.Helpers.ComponentHelper;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace CFM.Registration.PageObject.SearchPage
{
    public class SearchPageClass : HeaderPageClass
    {
        #region Constructor

        public SearchPageClass(IWebDriver driver) : base(driver)
        {
            
        }

        #endregion

        #region WebElements

        [FindsBy(How = How.XPath,Using = "//label[contains(.,'Programs:')]")]
        public IWebElement Programs { get; set; }

        #endregion

        #region Public

        public ManagePrgDatesClass ClickManagePrgDates()
        {
            ManageProgrmaDate.Click();
            GenericHelper.WaitForElement(GetLocatorOfWebElement("Programs"));
            GenericHelper.WaitForLoadingMask();
            return new ManagePrgDatesClass(Driver);
        }

        #endregion
    }
}
