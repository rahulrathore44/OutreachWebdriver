using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CFM.Registration.PageObject.LoginPage;
using Common.Helpers.Settings;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CFM.Registration.TestCases.ManagePrgDates
{
    [TestClass]
    public class TestManagePrgDates
    {
        [TestMethod]
        public void TestManageDates()
        {
            var lPage = new LoginPageClass(ObjectRepository.Driver);
            var sPage = lPage.LogIntoApplication(); // Method to log in to application
            var mPage = sPage.ClickManagePrgDates(); // Method to navigate to the Manage Program Data
            mPage.SelectProgram("Practicum in MBSR"); // Method for Selecting the Program
            Thread.Sleep(2000);
            mPage.SelectType("8-Week Practicum in MBSR"); // Method for Selecting the Type
            mPage.ClickAddNewRecord(); // Method for clicking the New Record button
            mPage.EnterStartDate("01/01/2015"); // Method for entering the start date , make sure the format should be xx/xx/xxxx
            mPage.EnterEndDate("03/31/2015");
            mPage.EnterStartTime("1:30:00 AM"); // Method for entering the Time , Make sure the format should be yy:yy:yy AM/PM
            // Similarly for rest of the method
            mPage.EnterEndTime("9:00:00 AM");
            mPage.EnterRegEndDate("12/15/2014");
            mPage.EnterRegStartDate("11/01/2014");
            mPage.Location.SendKeys($"CFM Shrewsbury-{DateTime.UtcNow.ToString("hh:mm:ss")}");
            mPage.Cost.SendKeys("100");
            mPage.Update.Click();
            Thread.Sleep(2000);
            mPage.Logout();

        }
    }
}
