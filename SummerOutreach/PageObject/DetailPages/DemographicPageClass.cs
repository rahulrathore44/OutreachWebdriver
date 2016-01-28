using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Helpers.ComponentHelper;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SummerOutreach.BaseClasses;

namespace SummerOutreach.PageObject.DetailPages
{
    public class DemographicPageClass : PageBase
    {
        #region Constructor

         public DemographicPageClass(IWebDriver driver) : base(driver) { }

        #endregion

        #region WebElement

        [FindsBy(How = How.Id,Using = "DemographicPage_MaritalStatusInd")]
        public IWebElement DemographicPageMaritalStatusInd { get; set; }

        [FindsBy(How = How.Id, Using = "DemographicPage_Dependants")]
        public IWebElement DemographicPageDependants { get; set; }

        [FindsBy(How = How.Id, Using = "DemographicPage_CitizenStatusInd")]
        public IWebElement DemographicPageCitizenStatusInd { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='divDisability']/input[1]")]
        public IWebElement Disability_Yes { get; set; }

        [FindsBy(How = How.Id, Using = "DemographicPage_DisabilityDesc")]
        public IWebElement DemographicPageDisabilityDesc { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='divDisability']/input[2]")]
        public IWebElement Disability_No { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='divAdverseRestrictions']/input[1]")]
        public IWebElement AdverseRestrictions_Yes { get; set; }

        [FindsBy(How = How.Id, Using = "DemographicPage_AdverseDesc")]
        public IWebElement DemographicPageAdverseDesc { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='divAdverseRestrictions']/input[2]")]
        public IWebElement AdverseRestrictions_No { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='divEconomicDisadvantage']/input[1]")]
        public IWebElement EconomicDisadvantages_Yes { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='divEconomicDisadvantage']/input[2]")]
        public IWebElement EconomicDisadvantage_No { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='divFirstGenGrad']/input[1]")]
        public IWebElement FirstGenGrad_Yes { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='divFirstGenGrad']/input[2]")]
        public IWebElement FirstGenGrad_No { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='divPriorArrests']/input[1]")]
        public IWebElement PriorArrests_Yes { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='divPriorArrests']/input[2]")]
        public IWebElement PriorArrests_No { get; set; }

        [FindsBy(How = How.Id, Using = "DemographicPage_PriorArrestsDesc")]
        public IWebElement DemographicPagePriorArrestsDesc { get; set; }

        [FindsBy(How = How.Id, Using = "DemographicPage_Race")]
        public IWebElement DemographicPageRace { get; set; }

        [FindsBy(How = How.Id, Using = "DemographicPage_EthnicityInd")]
        public IWebElement DemographicPageEthnicityInd { get; set; }

        [FindsBy(How = How.Id, Using = "DemographicPage_Languages")]
        public IWebElement DemographicPageLanguages { get; set; }

        [FindsBy(How = How.Id, Using = "DemographicPage_OtherLanguages")]
        public IWebElement DemographicPageOtherLanguages { get; set; }

        [FindsBy(How = How.Id, Using = "DemographicPage_EnglishProficiency")]
        public IWebElement DemographicPageEnglishProficiency { get; set; }

        [FindsBy(How = How.Id, Using = "AcademicAmount")]
        public IWebElement AcademicAmount { get; set; }

        [FindsBy(How = How.Id, Using = "FinancialAmount")]
        public IWebElement FinancialAmount { get; set; }

        [FindsBy(How = How.Id, Using = "StudentAmount")]
        public IWebElement StudentAmount { get; set; }

        [FindsBy(How = How.Id, Using = "OtherLoanAmount")]
        public IWebElement OtherLoanAmount { get; set; }

        [FindsBy(How = How.Id, Using = "FamilyAmount")]
        public IWebElement FamilyAmount { get; set; }

        [FindsBy(How = How.Id, Using = "ApplicantAmount")]
        public IWebElement ApplicantAmount { get; set; }

        [FindsBy(How = How.Id, Using = "OtherAmount")]
        public IWebElement OtherAmount { get; set; }

        [FindsBy(How = How.Id, Using = "txtTotal")]
        public IWebElement TxtTotal { get; set; }

        #endregion



        #region Public

        public void SelectMaritalStatus(string status)
        {
            DropDownHelper.SelectByVisibleText(DemographicPageMaritalStatusInd, status);
        }

        public void SelectDependants(string noDependants)
        {
            DropDownHelper.SelectByVisibleText(DemographicPageDependants, noDependants);
        }

        public void SelectCitizenStatus(string citizenStatus)
        {
            DropDownHelper.SelectByVisibleText(DemographicPageCitizenStatusInd, citizenStatus);
        }

        public void SelectRace(string race)
        {
            DropDownHelper.SelectByVisibleText(DemographicPageRace, race);
        }

        public void SelectEthnicity(string ethnicity)
        {
            DropDownHelper.SelectByVisibleText(DemographicPageEthnicityInd, ethnicity);
        }

        public void SelectEnglishProficiency(string englishProficiency)
        {
            DropDownHelper.SelectByVisibleText(DemographicPageEnglishProficiency, englishProficiency);
        }

        #endregion
    }
}
