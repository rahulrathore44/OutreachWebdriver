using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Common.Helpers.ComponentHelper;
using Common.Helpers.ExtensionClass;
using Common.Helpers.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SummerOutreach.PageObject.LoginPage;

namespace SummerOutreach.BaseClasses
{
    public class PageBase : IPage
    {
        #region Constructor

        protected PageBase(IWebDriver driver)
        {
            if (driver == null)
            {
                throw new ArgumentNullException(nameof(driver));
            }
            PageFactory.InitElements(driver, this);
            Driver = driver;
        }

        #endregion


        #region Fields

        private const string logout = "//li[@id='logout']/a";

        #endregion


        #region Webelements

        [FindsBy(How = How.XPath, Using = logout)]
        private IWebElement Logout { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[text()='Next']")]
        public IWebElement NextBtn { get; set; }

        [FindsBy(How = How.Id, Using = "prevButton")]
        public IWebElement PrevBtn { get; set; }

        #endregion

        #region Property

        public IWebDriver Driver { get; private set; }

        public string Title
        {
            get { return Driver.Title; }
        }

      

        #endregion


        #region Public


        public By GetElementLocator(How locator, string locatorValue)
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

        public By GetLocatorOfWebElement(string elementName)
        {
            try
            {
                var T = GetClassType();
                var field = T.GetProperty(elementName, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
                var cusAttri = field.GetCustomAttribute(typeof(FindsByAttribute));
                var ele = (FindsByAttribute)cusAttri;
                return GetElementLocator(ele.How, ele.Using);
            }
            catch (ArgumentNullException)
            {
                throw new ArgumentNullException(elementName + " Not Found ");
            }
            
        }

        public virtual Type GetClassType()
        {
            return GetType();
        }

        public virtual LoginPageClass LogoutFromApplication()
        {
            var lPage = new LoginPageClass(Driver);
            if (GenericHelper.IsElementPresentQuick(By.XPath(logout)))
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
