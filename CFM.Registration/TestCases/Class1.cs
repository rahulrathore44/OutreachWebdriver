using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CFM.Registration.PageObject.HomePage;
using Common.Helpers.BaseClasses;
using Common.Helpers.ExcelHelpers;
using Common.Helpers.Settings;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CFM.Registration.TestCases
{
    [TestClass]
    public class Class1 : InitializeWebDriver
    {
        [TestMethod,TestCategory("Excel")]
        public void TestMultipleSheet()
        {
            var path = @"C:\Users\rahul.rathore\Desktop\Lakshmi\CFMOasisRegistrationTestData.xlsx";
            var sheets = ExcelReaderHelper.GetTotalSheets(path);

            for (var i = 0; i < sheets; i++)
            {
                var hpage = new HomePageClass(ObjectRepository.Driver);
                DataEngine.ExecuteScript(hpage, path, "CFMOasisA");
            }

        }
    }
}
