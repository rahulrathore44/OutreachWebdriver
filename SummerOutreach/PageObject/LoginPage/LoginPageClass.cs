using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Helpers.ComponentHelper;
using Common.Helpers.Settings;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SummerOutreach.BaseClasses;
using SummerOutreach.PageObject.DetailPages;
using SummerOutreach.PageObject.MyApplication;


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

        [FindsBy(How = How.Id, Using = "ConfirmPassword")]
        public IWebElement ConfirmPassword { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[contains(.,'Submit')]")]
        public IWebElement LoginBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[contains(.,'Create an account')]")]
        public IWebElement CreatAccLink { get; set; }

        public MyApplicationPageClass LoginInApplication(string username = null, string password = null)
        {
            LogoutFromApplication();
            if (username == null)
                UserName.SendKeys(ObjectRepository.Config.GetUsername());
            else
                UserName.SendKeys(username);

            if (password == null)
                Password.SendKeys(ObjectRepository.Config.GetPassword());
            else
                Password.SendKeys(password);
            
            LoginBtn.Click();
            return new  MyApplicationPageClass(Driver);
        }

        public PersonalPageClass CreateNewAccount(string username = null, string password = null)
        {
            LogoutFromApplication();
            CreatAccLink.Click();

            if (username == null)
                UserName.SendKeys(ObjectRepository.Config.GetUsername());
            else
                UserName.SendKeys(username);

            if (password == null)
            {
                Password.SendKeys(ObjectRepository.Config.GetPassword());
                ConfirmPassword.SendKeys(ObjectRepository.Config.GetPassword());
            }
            else
            {
                Password.SendKeys(password);
                ConfirmPassword.SendKeys(password);
            }

            LoginBtn.Click();
            return new PersonalPageClass(Driver);
        }


    }
}
