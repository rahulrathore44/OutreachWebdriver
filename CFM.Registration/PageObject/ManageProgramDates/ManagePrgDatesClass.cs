using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CFM.Registration.BaseClasses.HeaderBasePage;
using Common.Helpers.ComponentHelper;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace CFM.Registration.PageObject.ManageProgramDates
{
    public class ManagePrgDatesClass : HeaderPageClass
    {
        #region Constructor

        public ManagePrgDatesClass(IWebDriver driver) : base(driver) { }

        #endregion

        #region WebElements

        [FindsBy(How = How.XPath, Using = "//label[contains(.,'Programs:')]")]
        public IWebElement ProgramsDropDown { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[text()='Add new record']")]
        public IWebElement AddNewRecord { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[text()='Update']")]
        public IWebElement Update { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[text()='Cancel']")]
        public IWebElement Cancel { get; set; }

        [FindsBy(How = How.Id, Using = "start_date")]
        public IWebElement StartDate { get; set; }

        [FindsBy(How = How.Id, Using = "end_date")]
        public IWebElement EndDate { get; set; }

        [FindsBy(How = How.Id, Using = "start_time")]
        public IWebElement StartTime { get; set; }

        [FindsBy(How = How.Id, Using = "end_time")]
        public IWebElement EndTime { get; set; }

        [FindsBy(How = How.Id, Using = "reg_start_date")]
        public IWebElement RegStartDate { get; set; }

        [FindsBy(How = How.Id, Using = "reg_end_date")]
        public IWebElement RegEndDate { get; set; }

        [FindsBy(How = How.Id, Using = "location")]
        public IWebElement Location { get; set; }

        [FindsBy(How = How.Id, Using = "cost")]
        public IWebElement Cost { get; set; }

        #endregion

        #region Public

        public void SelectProgram(string value)
        {
            DropDownHelper.SelectFromDropDownWithLabel("Programs",value);
        }

        public void SelectType(string value)
        {
            DropDownHelper.SelectFromDropDownWithLabel("Type",value);
        }

        public void ClickAddNewRecord()
        {
            AddNewRecord.Click();
            GenericHelper.WaitForElement(GetLocatorOfWebElement("Cancel"));
        }

        public void EnterStartDate(string date)
        {
            StartDate.Clear();
            StartDate.SendKeys(date);
        }

        public void EnterEndDate(string date)
        {
            EndDate.Clear();
            EndDate.SendKeys(date);
        }

        public void EnterStartTime(string time)
        {
            StartTime.Clear();
            StartTime.SendKeys(time);
        }

        public void EnterEndTime(string time)
        {
            EndTime.Clear();
            EndTime.SendKeys(time);
        }

        public void EnterRegStartDate(string date)
        {
            RegStartDate.Clear();
            RegStartDate.SendKeys(date);
        }

        public void EnterRegEndDate(string date)
        {
            RegEndDate.Clear();
            RegEndDate.SendKeys(date);
        }

        #endregion


    }
}
