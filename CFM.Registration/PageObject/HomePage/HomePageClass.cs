using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CFM.Registration.BaseClasses;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace CFM.Registration.PageObject.HomePage
{
    public class HomePageClass : PageBase
    {
        #region Constructor

         public HomePageClass(IWebDriver driver) : base(driver) { }

        #endregion

        #region AjaxLoader Element

        [FindsBy(How = How.XPath, Using = "//*[@id='ajaxLoaderProgramTypeID' and contains(@style,'display: none;')]")]
        public IWebElement AjaxLoaderProgramTypeId { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='ajaxLoader' and contains(@style,'display: none;')]")]
        public IWebElement AjaxLoader { get; set; }

        #endregion

        #region WebElements

        [FindsBy(How = How.Id, Using = "ddProgramTypeID")]
        public IWebElement ProgramType { get; set; }

        [FindsBy(How = How.Id,Using = "ddProgram")]
        public IWebElement Program { get; set; }

        [FindsBy(How = How.Id, Using = "ddSessionType")]
        public IWebElement SessionType { get; set; }

        [FindsBy(How = How.Id, Using = "ddSession")]
        public IWebElement Session { get; set; }

        [FindsBy(How = How.Id, Using = "UserApplicant_first_name")]
        public IWebElement ApplicantFirstName { get; set; }

        [FindsBy(How = How.Id, Using = "UserApplicant_last_name")]
        public IWebElement UserApplicantLastName { get; set; }

        [FindsBy(How = How.Id, Using = "UserApplicant_street")]
        public IWebElement UserApplicantStreet { get; set; }

        [FindsBy(How = How.Id, Using = "UserApplicant_city")]
        public IWebElement UserApplicantCity { get; set; }

        [FindsBy(How = How.Id, Using = "ddCountry")]
        public IWebElement Country { get; set; }

        [FindsBy(How = How.Id, Using = "ddState")]
        public IWebElement State { get; set; }

        [FindsBy(How = How.Id, Using = "UserApplicant_zip")]
        public IWebElement UserApplicantZip { get; set; }

        [FindsBy(How = How.Id, Using = "UserApplicant_day_phone")]
        public IWebElement UserApplicantDayPhone { get; set; }

        [FindsBy(How = How.Id, Using = "UserApplicant_email")]
        public IWebElement UserApplicantEmail { get; set; }

        [FindsBy(How = How.Id, Using = "UserApplicant_Confirmemail")]
        public IWebElement UserApplicantConfirmemail { get; set; }

        [FindsBy(How = How.Id, Using = "UserApplicant_userpasswordtext")]
        public IWebElement UserApplicantUserpasswordtext  { get; set; }

        [FindsBy(How = How.Id, Using = "UserApplicant_confirmpasswordtext")]
        public IWebElement UserApplicantConfirmpasswordtext { get; set; }

        [FindsBy(How = How.Id, Using = "ddHighestEducationDegree")]
        public IWebElement HighestEducationDegree { get; set; }

        [FindsBy(How = How.Id, Using = "UserApplicant_area_speciality")]
        public IWebElement UserApplicantAreaSpeciality { get; set; }

        [FindsBy(How = How.Id, Using = "file")]
        public IWebElement File { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='ddAnswer34' or @id='ddAnswer41' or @id='ddAnswer81' or @id='ddAnswer107']")]
        public IWebElement MeditationPractise { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='ddAnswer36' or @id='ddAnswer43' or @id='ddAnswer83' or @id='ddAnswer109']")]
        public IWebElement Yoga { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='ddAnswer37' or @id='ddAnswer44' or @id='ddAnswer84' or @id='ddAnswer110']")]
        public IWebElement Reiki { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='ddAnswer38' or @id='ddAnswer45' or @id='ddAnswer85' or @id='ddAnswer111']")]
        public IWebElement QiGong { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='ddAnswer39' or @id='ddAnswer46' or @id='ddAnswer86' or @id='ddAnswer112']")]
        public IWebElement TaiChi { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='ddAnswer40' or @id='ddAnswer47' or @id='ddAnswer87' or @id='ddAnswer113']")]
        public IWebElement Aikido { get; set; }

        [FindsBy(How = How.Id, Using = "rdoAnswer_1_No")]
        public IWebElement Week8 { get; set; }

        [FindsBy(How = How.Id, Using = "rdoAnswer_2_No")]
        public IWebElement Cfm8 { get; set; }

        [FindsBy(How = How.Id, Using = "rdoAnswer_48_No"),]
        [Description("Program : Teacher Development Intensive")]
        public IWebElement CfmPracticum { get; set; }

        [FindsBy(How = How.Id, Using = "txtAnswer77"),]
        [Description("Program : Teacher Development Intensive")]
        public IWebElement Institution { get; set; }

        [FindsBy(How = How.Id, Using = "txtAnswer78"),]
        [Description("Program : Teacher Development Intensive")]
        public IWebElement InstitutionYear { get; set; }

        [FindsBy(How = How.Id, Using = "txtAnswer79"),]
        [Description("Program : Teacher Development Intensive")]
        public IWebElement InstitutionLocation { get; set; }

        [FindsBy(How = How.Id, Using = "txtAnswer80"),]
        [Description("Program : Teacher Development Intensive")]
        public IWebElement InstitutionTecher { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='rdoAnswer_3_No' or @id='rdoAnswer_56_No']")]
        public IWebElement Mbsr { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='txtAnswer18' or @id='txtAnswer61' or @id='txtAnswer89']")]
        public IWebElement Year { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='txtAnswer19' or @id='txtAnswer62' or @id='txtAnswer90']")]
        public IWebElement Duration { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='txtAnswer20' or @id='txtAnswer63' or @id='txtAnswer91']")]
        public IWebElement Location { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='txtAnswer21' or @id='txtAnswer64' or @id='txtAnswer92']")]
        public IWebElement Teacher { get; set; }


        [FindsBy(How = How.XPath, Using = "//*[@id='txtAnswer65' or @id='txtAnswer93']")]
        [Description("Program : Teacher Development Intensive,Supervision")]
        public IWebElement Year2Nd { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='txtAnswer66' or @id='txtAnswer94']")]
        [Description("Program : Teacher Development Intensive,Supervision")]
        public IWebElement Duration2Nd { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='txtAnswer67' or @id='txtAnswer95']")]
        [Description("Program : Teacher Development Intensive,Supervision")]
        public IWebElement Location2Nd { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='txtAnswer68' or @id='txtAnswer96']")]
        [Description("Program : Teacher Development Intensive,Supervision")]
        public IWebElement Teacher2Nd { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='txtAnswer97']")]
        [Description("Program : Supervision")]
        public IWebElement Year3Rd { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='txtAnswer98']")]
        [Description("Program : Supervision")]
        public IWebElement Duration3Rd { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='txtAnswer99']")]
        [Description("Program : Supervision")]
        public IWebElement Location3Rd { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='txtAnswer100']")]
        [Description("Program : Supervision")]
        public IWebElement Teacher3Rd { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='txtAnswer101']")]
        [Description("Program : Supervision")]
        public IWebElement Language { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='txtAnswer103']")]
        [Description("Program : Supervision")]
        public IWebElement Option1 { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='txtAnswer104']")]
        [Description("Program : Supervision")]
        public IWebElement Option2 { get; set; }


        [FindsBy(How = How.Id, Using = "txtAnswer158")]
        [Description("Program : Supervision")]
        public IWebElement TeacherDevelopment { get; set; }


        [FindsBy(How = How.XPath, Using = "//*[@id='txtAnswer5' or @id='txtAnswer69']")]
        public IWebElement Description1 { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='txtAnswer6' or @id='txtAnswer70']")]
        public IWebElement Description2 { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='txtAnswer7' or @id='txtAnswer71']")]
        public IWebElement Description3 { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='txtAnswer8' or @id='txtAnswer72']")]
        public IWebElement Description4 { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='rdoAnswer_75_No' or @id='rdoAnswer_73_No']")]
        public IWebElement ContiEducation { get; set; }

        [FindsBy(How = How.Id, Using = "btnSubmit")]
        public IWebElement ContiBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[contains(text(),'Log Off')]")]
        public IWebElement LogOff { get; set; }
        #endregion
    }
}
