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
    public class TestProgramWithData : InitializeWebDriver
    {
        [TestMethod,TestCategory("Excel")]
        public void TestMultipleSheet()
        {
            var path = @"CFMOasisRegistrationTestData.xlsx";
            var sheets = ExcelReaderHelper.GetAllSheetName(path);

            foreach (var sheetName in sheets)
            {
                var hpage = new HomePageClass(ObjectRepository.Driver);
                DataEngine.ExecuteScript(hpage, path, sheetName);
            }

        }
    }
}
