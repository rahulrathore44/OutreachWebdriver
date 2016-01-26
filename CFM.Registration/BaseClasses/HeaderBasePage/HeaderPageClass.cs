using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Common.Helpers.ComponentHelper;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace CFM.Registration.BaseClasses.HeaderBasePage
{
    public class HeaderPageClass : PageBase
    {
        #region Consturctor

        public HeaderPageClass(IWebDriver driver) : base(driver)
        {
            
        }

        #endregion

        #region WebElement
        
        [FindsBy(How = How.XPath, Using = "//li[contains(.,'Admin')]")]
        public IWebElement Admin { get; set; }

        [FindsBy(How = How.XPath, Using = "//li[contains(.,'Manage Users')]")]
        public IWebElement ManageUsers { get; set; }

        [FindsBy(How = How.XPath, Using = "//li[contains(.,'Manage Program-Dates')]")]
        public IWebElement ManageProgrmaDate { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[contains(.,'Log Off')]")]
        public IWebElement LogOff { get; set; }

        #endregion

        #region Public

        public virtual void Logout()
        {
            if (GenericHelper.IsElementPresentQuick(GetLocatorOfWebElement("LogOff")))
            {
                LogOff.Click();
                GenericHelper.WaitForElement(By.XPath("//a[contains(.,'Login')]"));
                Thread.Sleep(1000);
            }
        }

        #endregion
    }
}
