using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using SummerOutreach.ComponentHelper;
using SummerOutreach.ExtensionClass;
using SummerOutreach.PageObject.LoginPage;
using SummerOutreach.Settings;

namespace SummerOutreach.TestCases.PersonalPage
{
    [TestClass]
    public class TestPersonalPage
    {

        [TestMethod]
        public void TestPositive1()
        {
            var lPage = new LoginPageClass(ObjectRepository.Driver);
            var dPage = lPage.LoginInApplication();
            dPage.SelectProgramName("Combined Summer Undergraduate Research Opportunity");
            GenericHelper.WaitForElement(By.Id("FundingInd"));
            dPage.SelectFunding("NIH");
            dPage.FirstName.ScrollToElementAndType("mahalakshm");
            dPage.LastName.ScrollToElementAndType("last");
            dPage.MiddleName.ScrollToElementAndType("middle");
            dPage.StreetAddress.ScrollToElementAndType("address");
            dPage.City.ScrollToElementAndType("Texas");
            dPage.SelectHomeState("Alabama");
            dPage.ZipCode.ScrollToElementAndType("56090");
            dPage.SchoolStreetAddress.ScrollToElementAndType("School Street Address");
            dPage.SchoolCity.ScrollToElementAndType("TeXas");
            dPage.SelectSchoolState("Alaska");
            dPage.SchoolZipCode.ScrollToElementAndType("12345");
            dPage.HomePhone.ScrollToElementAndType("1234512345");
            dPage.MobilePhone.ScrollToElementAndType("1234512345");
            dPage.Male.ScrollToElementAndClick();
            dPage.SelectDateOfBirth("1/19/1916");
            dPage.CaptureScreenShot();
            dPage.NextBtn.ScrollToElementAndClick();
            Thread.Sleep(2000);
            dPage.LogoutFromApplication();
        }

        [TestMethod]
        public void TestPositive2()
        {
            var lPage = new LoginPageClass(ObjectRepository.Driver);
            var dPage = lPage.LoginInApplication();
            dPage.SelectProgramName("Combined Summer Undergraduate Research Opportunity");
            GenericHelper.WaitForElement(By.Id("FundingInd"));
            dPage.SelectFunding("NIH");
            dPage.FirstName.ScrollToElementAndType("mahalakshm");
            dPage.LastName.ScrollToElementAndType("last");
            dPage.MiddleName.ScrollToElementAndType("middle");
            dPage.StreetAddress.ScrollToElementAndType("address");
            dPage.City.ScrollToElementAndType("Texas");
            dPage.SelectHomeState("Alabama");
            dPage.ZipCode.ScrollToElementAndType("56090");
            dPage.SchoolStreetAddress.ScrollToElementAndType("School Street Address");
            dPage.SchoolCity.ScrollToElementAndType("TeXas");
            dPage.SelectSchoolState("Alaska");
            dPage.SchoolZipCode.ScrollToElementAndType("12345");
            dPage.HomePhone.ScrollToElementAndType("1234512345");
            dPage.MobilePhone.ScrollToElementAndType("1234512345");
            dPage.Male.ScrollToElementAndClick();
            dPage.CaptureScreenShot();
            dPage.NextBtn.ScrollToElementAndClick();
            Thread.Sleep(2000);
            Assert.IsTrue(ValidationHelper.IsErrorMsgPresent("Fields marked with an asterisk are mandatory. Please verify."),"Error Message not found");
            dPage.LogoutFromApplication();
        }
    }
}
