using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Helpers.ExcelHelpers;
using Common.Helpers.Settings;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SummerOutreach.PageObject.LoginPage;
using SummerOutreach.PageObject.LoginPage.DetailPages;

namespace SummerOutreach.TestCases.PersonalPage
{
    [TestClass]
    public class Class2
    {
        [TestMethod]
        public void TestExcel()
        {
            string path = @"C:\downloads\SummerOutreachTestData.xlsx";
            var lPage = new LoginPageClass(ObjectRepository.Driver);
            DataEngine.ExecuteScript(lPage,path, "Data");
            var pPage = new PersonalPageClass(ObjectRepository.Driver);
            DataEngine.ExecuteScript(pPage, path, "Personal");
        }
    }
}
