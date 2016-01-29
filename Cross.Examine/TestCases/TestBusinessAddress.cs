using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Helpers.BaseClasses;
using Common.Helpers.ComponentHelper;
using Common.Helpers.Settings;
using Cross.Examine.PageObject.DetailPage;
using Cross.Examine.PageObject.DetailPage.DemographicPage;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cross.Examine.TestCases
{
    [TestClass]
    public class TestBusinessAddress : InitializeWebDriver
    {

        [TestMethod]
        public void VerifyBusinessAddress()
        {
            NavigationalHelper.NavigateToUrl(ObjectRepository.Config.GetWebsite() + Properties.Settings.Default.GSBSAlumnis);
            var dPage = new DemographicPageClass(ObjectRepository.Driver);
            dPage.NextBtn.Click();
            dPage.SelectProfessionalSuffix("ACNP", "ACNP-BC", "BA", "CHCA");
        }

    }
}
