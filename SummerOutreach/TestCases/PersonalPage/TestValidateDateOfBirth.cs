using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Common.Helpers.BaseClasses;
using Common.Helpers.ComponentHelper;
using Common.Helpers.ExcelHelpers;
using Common.Helpers.Settings;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SummerOutreach.PageObject.DetailPages;
using SummerOutreach.PageObject.LoginPage;

namespace SummerOutreach.TestCases.PersonalPage
{
    [TestClass]
    public class TestValidateDateOfBirth : InitializeWebDriver
    {
        [TestMethod]
        public void ValidateDateOfBirth()
        {
            var lPage = new LoginPageClass(ObjectRepository.Driver);
            var username = "Test" + DateTime.UtcNow.ToString("hhmmss") + "@yahoo.com";
            var pPage = lPage.CreateNewAccount(username);
            pPage.SelectProgramName("High School Health Careers Program");
            GenericHelper.WaitForElement(pPage.FirstName);
            pPage.FirstName.SendKeys("TestFname");
            pPage.MiddleName.SendKeys("TestMname");
            pPage.LastName.SendKeys("TestLname");
            pPage.StreetAddress.SendKeys("TestStAdd");
            pPage.City.SendKeys("Boston");
            pPage.SelectHomeState("Florida");
            pPage.ZipCode.SendKeys("12345");
            pPage.HomePhone.SendKeys("1233211231");
            pPage.MobilePhone.SendKeys("1233211231");
            pPage.Male.Click();
            pPage.SelectDateOfBirth(DateTime.UtcNow.AddYears(2).ToString("MM/dd/yyyy"));
            pPage.NextBtn.Click();
            Thread.Sleep(2000);
            Assert.IsTrue(ValidationHelper.IsErrorMsgPresent("Date of Birth cannot be greater than or equal to current date."), "Error Message not found");
            pPage.LogoutFromApplication();
        }

        [TestMethod]
        public void ValidateMandatoryFields()
        {
            var lPage = new LoginPageClass(ObjectRepository.Driver);
            var username = "Test" + DateTime.UtcNow.ToString("hhmmss") + "@yahoo.com";
            var pPage = lPage.CreateNewAccount(username);
            pPage.SelectProgramName("High School Health Careers Program");
            GenericHelper.WaitForElement(pPage.FirstName);
            pPage.FirstName.SendKeys("TestFname");
            pPage.MiddleName.SendKeys("TestMname");
            pPage.LastName.SendKeys("TestLname");
            pPage.SelectHomeState("Florida");
            pPage.HomePhone.SendKeys("1233211231");
            pPage.MobilePhone.SendKeys("1233211231");
            pPage.Male.Click();
            pPage.SelectDateOfBirth(DateTime.UtcNow.AddYears(-3).ToString("MM/dd/yyyy"));
            pPage.NextBtn.Click();
            Thread.Sleep(2000);
            Assert.IsTrue(ValidationHelper.IsErrorMsgPresent("Fields marked with an asterisk are mandatory. Please verify."), "Error Message not found");
            pPage.LogoutFromApplication();
        }

        [DeploymentItem("Driver")]
        [DeploymentItem("Data")]
        [TestMethod]
        public void ValidateUserAlreadyExis()
        {
            var lPage = new LoginPageClass(ObjectRepository.Driver);
            var username = "Test" + DateTime.UtcNow.ToString("hhmmss") + "@yahoo.com";
            var pPage = lPage.CreateNewAccount(username);
            DataEngine.ExecuteScript(pPage, "Data.xlsx", "Personal");
            var dPage = new DemographicPageClass(ObjectRepository.Driver);
            DataEngine.ExecuteScript(dPage, "Data.xlsx", "Demographic");
            pPage.LogoutFromApplication();
            var myPage = lPage.LoginInApplication(username);
            myPage.HighSchoolProgram.Click();
            Assert.IsTrue(ValidationHelper.IsPageTitlePresent("Demographic Information"));
        }

        [DeploymentItem("Driver")]
        [DeploymentItem("Data")]
        [TestMethod]
        public void ValidateForTotal()
        {
            var lPage = new LoginPageClass(ObjectRepository.Driver);
            var username = "Test" + DateTime.UtcNow.ToString("hhmmss") + "@yahoo.com";
            var pPage = lPage.CreateNewAccount(username);
            DataEngine.ExecuteScript(pPage, "ValidateData.xlsx", "Personal");
            var dPage = new DemographicPageClass(ObjectRepository.Driver);
            DataEngine.ExecuteScript(dPage, "ValidateData.xlsx", "Demographic");
            Assert.IsTrue(ValidationHelper.IsErrorMsgPresent("Amount does not total 100.  Please verify."));
            pPage.LogoutFromApplication();
        }
    }
}
