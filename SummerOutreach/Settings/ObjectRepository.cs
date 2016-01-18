using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using SummerOutreach.Interfaces;

namespace SummerOutreach.Settings
{
    public class ObjectRepository
    {
        public static IConfig Config { get; set; }
        public static IWebDriver Driver { get; set; }
        public static TestContext TestContextInstance { get; set; }
    }
}
