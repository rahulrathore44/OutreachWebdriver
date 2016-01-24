using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Common.Helpers.ComponentHelper;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
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

        #region Protected

        protected By GetElementLocator(How locator, string locatorValue)
        {
            switch (locator)
            {
                case How.XPath:
                    return By.XPath(locatorValue);
                case How.ClassName:
                    return By.ClassName(locatorValue);
                case How.CssSelector:
                    return By.CssSelector(locatorValue);
                case How.LinkText:
                    return By.LinkText(locatorValue);
                case How.Name:
                    return By.Name(locatorValue);
                case How.PartialLinkText:
                    return By.PartialLinkText(locatorValue);
                default:
                    return By.Id(locatorValue);
            }
        }

        protected By GetLocatorOfWebElement(string elementName)
        {
            var T = GetClassType();
            var field = T.GetProperty(elementName, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
            var cusAttri = field.GetCustomAttribute(typeof(FindsByAttribute));
            var ele = (FindsByAttribute)cusAttri;
            return GetElementLocator(ele.How, ele.Using);
        }


        #endregion



        #region Public

        public virtual Type GetClassType()
        {
            return GetType();
        }

        public virtual LoginPageClass LogoutFromApplication()
        {
            var lPage = new LoginPageClass(Driver);
            if (GenericHelper.IsElementPresentQuick(By.XPath("//li[@id='logout']/a")))
            {
                Logout.ScrollToElementAndClick();
                GenericHelper.WaitForElement(lPage.LoginBtn);
                return lPage;
            }
            return lPage;

        }
    }

    #endregion


}
