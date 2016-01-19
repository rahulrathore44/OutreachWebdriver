using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SummerOutreach.ComponentHelper;
using SummerOutreach.ExtensionClass;
using SummerOutreach.Interfaces;
using SummerOutreach.PageObject.LoginPage;

namespace SummerOutreach.BaseClasses
{
    public class PageBase : IPage
    {
       protected PageBase(IWebDriver driver)
        {
            if (driver == null)
            {
                throw new ArgumentNullException(nameof(driver));
            }
            PageFactory.InitElements(driver,this);
            Driver = driver;
        }

        [FindsBy(How = How.XPath,Using = "//li[@id='logout']/a")]
        private IWebElement Logout { get; set; }

        public IWebDriver Driver { get; private set; }

        public string Title
        {
            get { return Driver.Title; }
        }

        public virtual LoginPageClass LogoutFromApplication()
        {
            Logout.ScrollToElementAndClick();
            var lPage = new LoginPageClass(Driver);
            GenericHelper.WaitForElement(lPage.LoginBtn);
            return lPage;
        }
    }
}
