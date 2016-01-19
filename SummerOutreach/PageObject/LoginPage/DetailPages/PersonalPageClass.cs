using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SummerOutreach.BaseClasses;
using SummerOutreach.ComponentHelper;
using SummerOutreach.ExtensionClass;

namespace SummerOutreach.PageObject.LoginPage.DetailPages
{
    public class PersonalPageClass : PageBase
    {
        public PersonalPageClass(IWebDriver driver) : base(driver) { }

        #region Personal Details Fields

        [FindsBy(How = How.Id, Using = "ddProgram")]
        private IWebElement ProgramName { get; set; }

        [FindsBy(How = How.Id, Using = "FundingInd")]
        private IWebElement FundingInd { get; set; }

        [FindsBy(How = How.Id, Using = "PersonalPage_FirstName")]
        public IWebElement FirstName { get; set; }

        [FindsBy(How = How.Id, Using = "PersonalPage_LastName")]
        public IWebElement LastName { get; set; }

        [FindsBy(How = How.Id, Using = "PersonalPage_MiddleName")]
        public IWebElement MiddleName { get; set; }

        #endregion



        #region Home Address Field

        [FindsBy(How = How.Id, Using = "PersonalPage_PersonalAddress_StreetAddress")]
        public IWebElement StreetAddress { get; set; }

        [FindsBy(How = How.Id, Using = "PersonalPage_PersonalAddress_City")]
        public IWebElement City { get; set; }

        [FindsBy(How = How.Id, Using = "PersonalPage_PersonalAddress_State")]
        private IWebElement State { get; set; }

        [FindsBy(How = How.Id, Using = "PersonalPage_PersonalAddress_ZipCode")]
        public IWebElement ZipCode { get; set; }

        [FindsBy(How = How.Id, Using = "chkCopyAddress")]
        public IWebElement CopyAddress { get; set; }

        #endregion



        #region School Address Field

        [FindsBy(How = How.Id, Using = "PersonalPage_SchoolYearAddress_StreetAddress")]
        public IWebElement SchoolStreetAddress { get; set; }

        [FindsBy(How = How.Id, Using = "PersonalPage_SchoolYearAddress_City")]
        public IWebElement SchoolCity { get; set; }

        [FindsBy(How = How.Id, Using = "PersonalPage_SchoolYearAddress_State")]
        private IWebElement SchoolState { get; set; }

        [FindsBy(How = How.Id, Using = "PersonalPage_SchoolYearAddress_ZipCode")]
        public IWebElement SchoolZipCode { get; set; }

        [FindsBy(How = How.Id, Using = "PersonalPage_HomePhone")]
        public IWebElement HomePhone { get; set; }

        [FindsBy(How = How.Id, Using = "PersonalPage_MobilePhone")]
        public IWebElement MobilePhone { get; set; }

        [FindsBy(How = How.Id, Using = "PersonalPage_HomeEmail")]
        public IWebElement HomeEmail { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='PersonalPage_DateOfBirth']/following-sibling::span/span")]
        private IWebElement DateOfBirth { get; set; }

        [FindsBy(How = How.Id, Using = "PersonalPage_DateOfBirth")]
        private IWebElement DateOfBirthInput { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@value='M']")]
        public IWebElement Male { get; set; }

        [FindsBy(How = How.Id, Using = "//input[@value='F']")]
        public IWebElement Female { get; set; }


        #endregion

        [FindsBy(How = How.XPath, Using = "//button[text()='Next']")]
        public IWebElement NextBtn { get; set; }



        #region Public Methods

        public void SelectProgramName(string name)
        {
            DropDownHelper.SelectByVisibleText(ProgramName, name);
        }

        public void SelectFunding(string name)
        {
            DropDownHelper.SelectByVisibleText(FundingInd, name);
        }

        public void SelectHomeState(string name)
        {
            DropDownHelper.SelectByVisibleText(State, name);
        }

        public void SelectSchoolState(string name)
        {
            DropDownHelper.SelectByVisibleText(SchoolState, name);
        }

        public void SelectDateOfBirth(string day, string month, string year)
        {
            DateOfBirth.ScrollToElementAndClick();
            CalenderHelper.SelectDate(Properties.Settings.Default.DateOfBirthId,day,month,year);
        }

        public void SelectDateOfBirth(string dob)
        {
            DateOfBirthInput.ScrollToElementAndType(dob);
        }

        #endregion


    }
}
