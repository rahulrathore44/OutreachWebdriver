using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SummerOutreach.BaseClasses;
using SummerOutreach.ComponentHelper;
using SummerOutreach.ExtensionClass;
using SummerOutreach.PageObject.LoginPage.DetailPages;
using SummerOutreach.Settings;

namespace SummerOutreach.PageObject.LoginPage
{
    public class LoginPageClass : PageBase
    {
        public LoginPageClass(IWebDriver driver) : base(driver)
        {
            
        }

       [FindsBy(How = How.Id,Using = "UserName")]
       public IWebElement UserName { get; set; }

       [FindsBy(How = How.Id, Using = "Password")]
       public IWebElement Password { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[contains(.,'Submit')]")]
        public IWebElement LoginBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[contains(.,'Create an account')]")]
        public IWebElement CreatAccLink { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[contains(.,'New application')]")]
        public IWebElement NewApplication { get; set; }

        public PersonalPageClass LoginInApplication()
        {
            UserName.SendKeys(ObjectRepository.Config.GetUsername());
            Password.SendKeys(ObjectRepository.Config.GetPassword());
            LoginBtn.Click();
            if (GenericHelper.IsElementPresentQuick(By.XPath("//a[contains(.,'New application')]")))
            {
                NewApplication.Click();
            }
            return new PersonalPageClass(Driver);
        }
    }
}
