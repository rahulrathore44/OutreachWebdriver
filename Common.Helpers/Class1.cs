using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Helpers.ExcelHelpers;
using Excel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Common.Helpers
{
    [TestClass]
    public class Class1
    {
        [TestMethod]
        public void TestExcel()
        {
            string path = @"C:\downloads\ExcelData.xlsx";
            string sheetName = "Sheet1";
        }
    }
}
