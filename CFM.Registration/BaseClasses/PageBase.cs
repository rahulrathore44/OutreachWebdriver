using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using CFM.Registration.PageObject.LoginPage;
using Common.Helpers.ComponentHelper;
using Common.Helpers.ExtensionClass;
using Common.Helpers.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace CFM.Registration.BaseClasses
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
            var T = GetClassType();
            var field = T.GetProperty(elementName, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
            var cusAttri = field.GetCustomAttribute(typeof(FindsByAttribute));
            var ele = (FindsByAttribute)cusAttri;
            return GetElementLocator(ele.How, ele.Using);
        }

        public virtual Type GetClassType()
        {
            return GetType();
        }

        public void FileUpload(string fileName)
        {
            var infor = new ProcessStartInfo()
            {
                FileName = "FileUpload.exe",
                Arguments = "\"" + Directory.GetCurrentDirectory() + "\\" + fileName + "\""
            };

            using (var process = Process.Start(infor))
            {
                process.WaitForExit();
            }
        }
    }

    #endregion


}
