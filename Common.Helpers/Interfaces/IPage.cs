using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace Common.Helpers.Interfaces
{
    public interface IPage
    {
        IWebDriver Driver { get; }

        string Title { get; }

        By GetLocatorOfWebElement(string elementName);

        void FileUpload(string fileName);

    }
}
