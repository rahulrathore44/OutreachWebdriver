using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Helpers.ComponentHelper;
using Common.Helpers.Interfaces;

namespace Common.Helpers.ExcelHelpers
{
    public class DataEngine
    {
        public static void ExecuteScript(IPage pageObject,string xlPath, string sheetName)
        {
            var totalRow = ExcelReaderHelper.GetTotalRows(xlPath, sheetName);
            for (int i = 2; i < totalRow; i++)
            {
                var webEle = ExcelReaderHelper.GetCellValue(xlPath, sheetName, i, 2);

                if (webEle == string.Empty)
                    break;

                var locator = pageObject.GetLocatorOfWebElement(webEle);
                switch (ExcelReaderHelper.GetCellValue(xlPath, sheetName, i, 1)) 
                {

                    case "SendKeys":
                    {
                        var text = ExcelReaderHelper.GetCellValue(xlPath, sheetName, i, 3);
                        TextBoxHelper.TypeInTextBox(locator,text);
                    }
                        break;

                    case "Click":
                    {
                        ButtonHelper.ClickButton(locator);
                    }
                        break;

                    case "ClickIfExist":
                    {
                        if (GenericHelper.IsElementPresentQuick(locator))
                        {
                                ButtonHelper.ClickButton(locator);
                        }
                    }
                        break;

                    case "Select":
                    {
                        var text = ExcelReaderHelper.GetCellValue(xlPath, sheetName, i, 3);
                        DropDownHelper.SelectByVisibleText(locator,text);
                    }
                        break;

                    case "WaitForEle":
                    {
                        GenericHelper.WaitForElement(locator);
                    }
                        break;

                    default:
                        break;
                }

            }
        }
    }
}
