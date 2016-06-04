using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Common.Helpers.ComponentHelper;
using Common.Helpers.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Common.Helpers.Settings;

namespace Common.Helpers.ExcelHelpers
{
    public class DataEngine
    {
        public static void ExecuteScript(IPage pageObject,string xlPath, string sheetName)
        {
            var totalRow = ExcelReaderHelper.GetTotalRows(xlPath, sheetName);
            for (var i = 2; i < totalRow; i++)
            {
                var action = ExcelReaderHelper.GetCellValue(xlPath, sheetName, i, 1);
                var webEle = ExcelReaderHelper.GetCellValue(xlPath, sheetName, i, 2);

                if ((webEle == string.Empty) && (action == string.Empty))
                    break;

                if (webEle == string.Empty)
                    continue;

                var locator = pageObject.GetLocatorOfWebElement(webEle);
                Console.WriteLine("Action {0}, WebElement {1}, Locator {2} ",action,webEle,locator);
                switch (action) 
                {

                    case "SendKeys":
                    {
                        var text = ExcelReaderHelper.GetCellValue(xlPath, sheetName, i, 3);
                        TextBoxHelper.TypeInTextBox(locator,text);
                    }
                        break;

                    case "ClearAndSendKeys":
                    {
                            var text = ExcelReaderHelper.GetCellValue(xlPath, sheetName, i, 3);
                            TextBoxHelper.ClearTextBox(locator);
                            TextBoxHelper.TypeInTextBox(locator, text);
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

                    case "SelectIndex":
                        {
                            var text = ExcelReaderHelper.GetCellValue(xlPath, sheetName, i, 3);
                            DropDownHelper.SelectByIndex(locator, Convert.ToInt32(text));
                        }
                        break;

                    case "WaitForEle":
                    {
                        var text = ExcelReaderHelper.GetCellValue(xlPath, sheetName, i, 3);
                        if (text == string.Empty)
                        {
                            GenericHelper.WaitForElement(locator);
                        }
                        else
                        {
                            GenericHelper.WaitForElement(locator, Convert.ToInt32(text));
                        }
                    }
                        break;

                    case "Sleep":
                    {
                            var text = ExcelReaderHelper.GetCellValue(xlPath, sheetName, i, 3);
                            Thread.Sleep(Convert.ToInt32(text));
                    }
                        break;

                    case "SelectFile":
                    {
                            var text = ExcelReaderHelper.GetCellValue(xlPath, sheetName, i, 3);
                            pageObject.FileUpload(text);
                     }
                        break;
                    case "AssertTitle":
                        {
                            var text = ExcelReaderHelper.GetCellValue(xlPath, sheetName, i, 3);
                            Assert.AreEqual(text, ObjectRepository.Driver.Title);
                        }

                        break;

                    case "PerformClick":
                    {
                        MouseActionHelper.PerformClick(locator);
                    }
                        break;

                }

            }
        }
    }
}
