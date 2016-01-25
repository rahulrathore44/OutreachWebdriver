using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel;
using OfficeOpenXml;

namespace Common.Helpers.ExcelHelpers
{
    public class ExcelReaderHelper
    {
        #region Fields

        private readonly static IDictionary<string, ExcelWorksheet> _cache;
        private static FileInfo _fileInfo;
        private static ExcelPackage _package;
        private static ExcelWorksheet _excelWorksheet;

        #endregion

        #region Constructor

        static ExcelReaderHelper()
        {
            _cache = new Dictionary<string, ExcelWorksheet>();
        }


        #endregion

        #region Private
        private static ExcelWorksheet GetExcelReader(string xlPath, string sheetName)
        {
            if (_cache.ContainsKey(sheetName))
            {
                _excelWorksheet = _cache[sheetName];
            }
            else
            {
                _fileInfo = new FileInfo(xlPath);
                _package = new ExcelPackage(_fileInfo);
                _excelWorksheet = _package.Workbook.Worksheets[sheetName];
                _cache.Add(sheetName, _excelWorksheet);
            }
            return _excelWorksheet;
        }


        #endregion

        #region Public

        public static int GetTotalRows(string xlPath, string sheetName)
        {
            var reader = GetExcelReader(xlPath, sheetName);
            return reader.Cells.Count();
        }

        //public static DataTable GetDataTable(string xlPath, string sheetName)
        //{
        //    var reader = GetExcelReader(xlPath, sheetName);
        //    return reader.AsDataSet().Tables[sheetName];
        //}

        //public static T GetCellValue<T>(string xlPath, string sheetName,int row ,int column) 
        //{
        //    var dataTable = GetDataTable(xlPath, sheetName);
        //    var datareader = dataTable.CreateDataReader();
        //    return "";

        //}

        #endregion


    }
}
