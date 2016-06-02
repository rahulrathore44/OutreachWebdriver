using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Helpers.BaseClasses;
using Common.Helpers.ExcelHelpers;
using Common.Helpers.Settings;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SummerOutreach.PageObject.DetailPages;
using SummerOutreach.PageObject.LoginPage;

namespace SummerOutreach.TestCases.PersonalPage
{
    [TestClass]
    public class Class2 : InitializeWebDriver
    {
        [Ignore]
        [TestMethod]
        public void TestExcel()
        {
            string path = @"C:\downloads\SOTestData.xlsx";
            var lPage = new LoginPageClass(ObjectRepository.Driver);
            DataEngine.ExecuteScript(lPage,path, "Data");
            var pPage = new PersonalPageClass(ObjectRepository.Driver);
            DataEngine.ExecuteScript(pPage, path, "Personal");
        }
    }
}
