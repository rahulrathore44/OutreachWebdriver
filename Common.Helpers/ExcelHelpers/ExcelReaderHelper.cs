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

        private static ExcelPackage GetExcelPackageObject(FileInfo info)
        {
            if(!info.Exists)
                throw new FileNotFoundException(string.Format("File not found @{0}", info.Name));
            return new ExcelPackage(info);
        }

        private static ExcelWorksheet GetExcelReader(string xlPath, string sheetName)
        {
            if (_cache.ContainsKey(sheetName))
            {
                _excelWorksheet = _cache[sheetName];
            }
            else
            {
                _package = GetExcelPackageObject(new FileInfo(xlPath));
                _excelWorksheet = _package.Workbook.Worksheets[sheetName];
                _cache.Add(sheetName, _excelWorksheet);
            }
            return _excelWorksheet;
        }


        #endregion

        #region Public

        public static List<string> GetAllSheetName(string xlPath)
        {
            var package = GetExcelPackageObject(new FileInfo(xlPath));
            return package.Workbook.Worksheets.Select((worksheet => worksheet.Name)).ToList();
        }

        public static int GetTotalRows(string xlPath, string sheetName)
        {
            var reader = GetExcelReader(xlPath, sheetName);
            return reader.Cells.Count();
        }

        public static int GetTotalSheets(string xlPath)
        {
            var package = GetExcelPackageObject(new FileInfo(xlPath));
            return package.Workbook.Worksheets.Count;
        }

        public static string GetCellValue(string xlPath, string sheetName, int row, int column)
        {
            var reader = GetExcelReader(xlPath, sheetName);
            return reader.Cells[row, column].Text;
        }

        #endregion


    }
}
