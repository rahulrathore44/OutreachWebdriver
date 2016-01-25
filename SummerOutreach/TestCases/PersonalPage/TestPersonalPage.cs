using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Common.Helpers.ComponentHelper;
using Common.Helpers.ExtensionClass;
using Common.Helpers.Settings;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using SummerOutreach.PageObject.LoginPage;


namespace SummerOutreach.TestCases.PersonalPage
{
    [TestClass]
    public class TestPersonalPage
    {

        [TestMethod]
        public void TestPositive()
        {
            var lPage = new LoginPageClass(ObjectRepository.Driver);
            var dPage = lPage.LoginInApplication();
            dPage.SelectProgramName("Combined Summer Undergraduate Research Opportunity");
            GenericHelper.WaitForElement(By.Id("FundingInd"));
            dPage.SelectFunding("NIH");
            dPage.FirstName.SendKeys("mahalakshm");
            dPage.LastName.SendKeys("last");
            dPage.MiddleName.SendKeys("middle");
            dPage.StreetAddress.SendKeys("address");
            dPage.City.SendKeys("Texas");
            dPage.SelectHomeState("Alabama");
            dPage.ZipCode.SendKeys("56090");
            dPage.SchoolStreetAddress.SendKeys("School Street Address");
            dPage.SchoolCity.SendKeys("TeXas");
            dPage.SelectSchoolState("Alaska");
            dPage.SchoolZipCode.SendKeys("12345");
            dPage.HomePhone.SendKeys("1234512345");
            dPage.MobilePhone.SendKeys("1234512345");
            dPage.Male.ScrollToElementAndClick();
            dPage.SelectDateOfBirth("1/19/1916");
            dPage.CaptureScreenShot();
            dPage.NextBtn.ScrollToElementAndClick();
            Thread.Sleep(2000);
            dPage.LogoutFromApplication();
        }

        [TestMethod]
        public void TestNegative()
        {
            var lPage = new LoginPageClass(ObjectRepository.Driver);
            var dPage = lPage.LoginInApplication();
            dPage.SelectProgramName("Combined Summer Undergraduate Research Opportunity");
            GenericHelper.WaitForElement(By.Id("FundingInd"));
            dPage.SelectFunding("NIH");
            dPage.FirstName.SendKeys("mahalakshm");
            dPage.LastName.SendKeys("last");
            dPage.MiddleName.SendKeys("middle");
            dPage.StreetAddress.SendKeys("address");
            dPage.City.SendKeys("Texas");
            dPage.SelectHomeState("Alabama");
            dPage.ZipCode.SendKeys("56090");
            dPage.SchoolStreetAddress.SendKeys("School Street Address");
            dPage.SchoolCity.SendKeys("TeXas");
            dPage.SelectSchoolState("Alaska");
            dPage.SchoolZipCode.SendKeys("12345");
            dPage.HomePhone.SendKeys("1234512345");
            dPage.MobilePhone.SendKeys("1234512345");
            dPage.Male.ScrollToElementAndClick();
            dPage.CaptureScreenShot();
            dPage.NextBtn.ScrollToElementAndClick();
            Thread.Sleep(2000);
            Assert.IsTrue(ValidationHelper.IsErrorMsgPresent("Fields marked with an asterisk are mandatory. Please verify."),"Error Message not found");
            dPage.LogoutFromApplication();
        }
    }
}
