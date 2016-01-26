using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CFM.Registration.BaseClasses;
using CFM.Registration.PageObject.SearchPage;
using Common.Helpers.ComponentHelper;
using Common.Helpers.Settings;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace CFM.Registration.PageObject.LoginPage
{
    public class LoginPageClass : PageBase
    {
        #region Constructo

        public LoginPageClass(IWebDriver driver) : base(driver)
        {
            
        }

        #endregion

        #region WebElements

        [FindsBy(How = How.Id,Using = "username")]
        public IWebElement Username { get; set; }

        [FindsBy(How = How.Id, Using = "userpasswordtext")]
        public IWebElement Password { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@value='Log in']")]
        public IWebElement LogInBtn { get; set; }

        #endregion

        #region Public

        public SearchPageClass LogIntoApplication(string username = null, string password = null)
        {
            if(username == null)
                Username.SendKeys(ObjectRepository.Config.GetUsername());
            else
                Username.SendKeys(username);
            
            if(password == null)
                Password.SendKeys(ObjectRepository.Config.GetPassword());
            else 
                Password.SendKeys(password);

            LogInBtn.Click();
            GenericHelper.WaitForElement(By.XPath("//li[contains(.,'Manage Program-Dates')]"));
            return new SearchPageClass(Driver);
        }

        #endregion
    }
}
