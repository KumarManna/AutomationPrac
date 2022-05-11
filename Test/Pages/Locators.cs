using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using BrowserControl;
namespace Test.Pages
{
    class Locators
    {
        #region Sign_In
        public static By Sign_in = By.XPath("//div/a[@class='login']");
        public static By Sign_in_Email=By.XPath("//*[@id='email']");
        public static By Sign_in_Pass= By.XPath("//*[@id='email']//following::input[@id='passwd']");
        public static By Sign_in_Sub =By.XPath("//*[@id='email']//following::input[@id='passwd']//following::button[@id='SubmitLogin']");
        #endregion

        #region Sign_Up Page
        public static By Email_create = By.XPath("//*[@id='email_create']");
        public static By Sub_create = By.XPath("//*[@id='SubmitCreate']");
        public static By F_Name1 = By.XPath("//input[@id='customer_firstname']");
        public static By L_Name1= By.XPath("//input[@id='customer_lastname']");
        public static By Sign_Up_Email = By.XPath("//input[@id='email']");
        public static By Sign_Up_Pass = By.XPath("//input[@id='passwd']");
        public static By F_Name2 = By.XPath("//input[@id='firstname']");
        public static By L_Name2=By.XPath("//input[@id='lastname']");
        public static By company=  By.XPath("//*[@id='company']");
        public static By address = By.XPath("//*[@id='address1']");
        public static By house_name = By.XPath("//*[@id='address1']//following::input[@id='address2']");
        public static By City = By.XPath("//*[@id='city']");
        public static By State= By.XPath("//*[@id='uniform-id_state']");
        public static By Pin = By.XPath("//*[@id='postcode']");
        public static By Country = By.XPath("//*[@id='id_country']");
        public static By Sign_up_Sub= By.XPath("//*[@id='submitAccount']");
        #endregion
    }
}
