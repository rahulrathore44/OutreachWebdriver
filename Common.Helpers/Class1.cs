using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            var stream = new FileStream(@"C:\Keyword\Book1.xlsx", FileMode.Open, FileAccess.Read);
            var reader = ExcelReaderFactory.CreateOpenXmlReader(stream);
            DataTable table = reader.AsDataSet().Tables["Sheet1"];
            var t = table.CreateDataReader();
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("DataType : " + t.GetDataTypeName(i));
            }

            stream.Close();
            reader.Close();
        }
    }
}
