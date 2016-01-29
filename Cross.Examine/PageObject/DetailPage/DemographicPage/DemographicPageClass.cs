using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Helpers.ComponentHelper;
using Cross.Examine.BaseClasses;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Cross.Examine.PageObject.DetailPage.DemographicPage
{
    public class DemographicPageClass : PageBase
    {
        #region Constructor

        public DemographicPageClass(IWebDriver driver) : base(driver) { }

        #endregion

        #region WebElements

        [FindsBy(How = How.Id,Using = "SuffixIds")]
        public IWebElement ProfessionalSuffix { get; set; }

        [FindsBy(How = How.Id, Using = "btnSfxDown")]
        public IWebElement BtnSfxDown { get; set; }

        [FindsBy(How = How.Id, Using = "btnSfxUp")]
        public IWebElement BtnSfxUp { get; set; }

        [FindsBy(How = How.Id, Using = "SuffixIdsSelected")]
        public IWebElement ProfessionalSuffixSelected { get; set; }

        [FindsBy(How = How.Id, Using = "FirstName")]
        public IWebElement FirstName { get; set; }

        [FindsBy(How = How.Id, Using = "LastName")]
        public IWebElement LastName { get; set; }

        [FindsBy(How = How.Id, Using = "MiddleName")]
        public IWebElement MiddleName { get; set; }

        [FindsBy(How = How.Id, Using = "MaritalStatus")]
        public IWebElement MaritalStatus { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[text()='Are You Hispanic/Latino']/following-sibling::div/input[1]")]
        public IWebElement Yes { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[text()='Are You Hispanic/Latino']/following-sibling::div/input[2]")]
        public IWebElement No { get; set; }

        [FindsBy(How = How.Id, Using = "EthnicityIds")]
        public IWebElement EthnicityIds { get; set; }

        [FindsBy(How = How.Id, Using = "btnEthDown")]
        public IWebElement BtnEthDown { get; set; }

        [FindsBy(How = How.Id, Using = "btnEthUp")]
        public IWebElement BtnEthUp { get; set; }

        [FindsBy(How = How.Id, Using = "EthnicityIdsSelected")]
        public IWebElement EthnicityIdsSelected { get; set; }

        [FindsBy(How = How.Id, Using = "Email")]
        public IWebElement Email { get; set; }

        #endregion

        #region Public

        public void SelectProfessionalSuffix(params string[] suffix)
        {
            foreach (var str in suffix)
            {
                DropDownHelper.SelectByVisibleText(ProfessionalSuffix, str);
                BtnSfxDown.Click();
            }
            
        }

        #endregion
    }
}
