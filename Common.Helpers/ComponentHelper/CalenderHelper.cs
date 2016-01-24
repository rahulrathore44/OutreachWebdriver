using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Common.Helpers.Settings;
using OpenQA.Selenium;


namespace Common.Helpers.ComponentHelper
{
    public class CalenderHelper
    {
        private static void ClickHeader(string tableXPath)
        {
            ObjectRepository.Driver.FindElement(By.XPath(tableXPath + "/div[1]/div[1]/a[2]")).Click();
            Thread.Sleep(500);
        }

        private static void SelectMonth(string tableXPath, string month)
        {
            for (int i = 1; i <= 3; i++)
            {
                for (int j = 1; j <= 4; j++)
                {
                    if (GenericHelper.IsElementPresentQuick(By.XPath(tableXPath + "//table/tbody/tr[" + i + "]/td[" + j + "]/a")))
                    {
                        string aMonth = ObjectRepository.Driver.FindElement(By.XPath(tableXPath + "//table/tbody/tr[" + i + "]/td[" + j + "]/a")).Text;
                        if (month.Equals(aMonth, StringComparison.OrdinalIgnoreCase))
                        {
                            ObjectRepository.Driver.FindElement(By.XPath(tableXPath + "//table/tbody/tr[" + i + "]/td[" + j + "]/a")).Click();
                            return;
                        }
                    }
                }
            }
        }

        private static void SelectYear(string tableXPath, string year)
        {
            for (int i = 1; i <= 3; i++)
            {
                for (int j = 1; j <= 4; j++)
                {
                    if (GenericHelper.IsElementPresentQuick(By.XPath(tableXPath + "//table/tbody/tr[" + i + "]/td[" + j + "]/a")))
                    {
                        string aYear = ObjectRepository.Driver.FindElement(By.XPath(tableXPath + "//table/tbody/tr[" + i + "]/td[" + j + "]/a")).Text;
                        if (year.Equals(aYear, StringComparison.OrdinalIgnoreCase))
                        {
                            ObjectRepository.Driver.FindElement(By.XPath(tableXPath + "//table/tbody/tr[" + i + "]/td[" + j + "]/a")).Click();
                            return;
                        }
                    }
                }
            }
        }

        private static void SelectDay(string tableXPath, string day)
        {
            for (int i = 1; i <= 6; i++)
            {
                for (int j = 1; j <= 7; j++)
                {
                    if (GenericHelper.IsElementPresentQuick(By.XPath(tableXPath + "//table/tbody/tr[" + i + "]/td[" + j + "]/a")))
                    {
                        var xpath = tableXPath + "//table/tbody/tr[" + i + "]/td[" + j + "]/a";
                        var aday = ObjectRepository.Driver.FindElement(By.XPath(xpath)).Text;
                        if (day.Equals(aday, StringComparison.OrdinalIgnoreCase))
                        {
                            if (
                                !ObjectRepository.Driver.FindElement(By.XPath(xpath))
                                    .GetAttribute("class")
                                    .Contains("k-other-month"))
                            {
                                ObjectRepository.Driver.FindElement(By.XPath(xpath)).Click();
                                return;
                            }

                        }
                    }
                }
            }
        }

        public static void SelectDate(string tableXPath, string day, string month, string year)
        {
            ClickHeader(tableXPath);
            Thread.Sleep(500);
            ClickHeader(tableXPath);
            Thread.Sleep(500);
            SelectYear(tableXPath, year);
            Thread.Sleep(1000);
            SelectMonth(tableXPath, month);
            Thread.Sleep(500);
            SelectDay(tableXPath, day);
            Thread.Sleep(500);

        }
    }
}
