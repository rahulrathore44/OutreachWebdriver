using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CFM.Registration.PageObject.LoginPage;
using Common.Helpers.BaseClasses;
using Common.Helpers.ComponentHelper;
using Common.Helpers.Settings;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CFM.Registration.TestCases.ManagePrgDates
{
    [TestClass]
    public class TestManagePrgDates : InitializeWebDriver
    {
        [TestMethod]
        public void TestManageDates()
        {
            var lPage = new LoginPageClass(ObjectRepository.Driver);
            var sPage = lPage.LogIntoApplication(); // Method to log in to application
            var mPage = sPage.ClickManagePrgDates(); // Method to navigate to the Manage Program Data
            Thread.Sleep(2000);
            string pName = "Practicum in MBSR";
            mPage.SelectProgram(pName); // Method for Selecting the Program
            Thread.Sleep(2000);
            string sName = "8-Week Practicum in MBSR";
            mPage.SelectType(sName); // Method for Selecting the Type
            mPage.ClickAddNewRecord(); // Method for clicking the New Record button
            mPage.EnterStartDate("01/01/2017"); // Method for entering the start date , make sure the format should be xx/xx/xxxx
            mPage.EnterEndDate("03/31/2017");
            mPage.EnterStartTime("1:30:00 AM"); // Method for entering the Time , Make sure the format should be yy:yy:yy AM/PM
            // Similarly for rest of the method
            mPage.EnterEndTime("9:00:00 AM");
            mPage.EnterRegStartDate("11/01/2014");
            mPage.EnterRegEndDate("12/15/2017");
            var name = "CFM Shrewsbury -" + DateTime.UtcNow.ToString("hh:mm:ss");
            mPage.Location.SendKeys(name);
            mPage.Cost.SendKeys("100");
            mPage.Update.Click();
            Thread.Sleep(2000);
            var hPage = mPage.Logout();
            DropDownHelper.SelectByVisibleText(hPage.Program,pName);
            GenericHelper.WaitForAjaxLoader();
            DropDownHelper.SelectByVisibleText(hPage.SessionType,sName);
            Thread.Sleep(2000);
            Assert.IsTrue(DropDownHelper.VerifyInOptions(hPage.Session,name));


        }
    }
}
