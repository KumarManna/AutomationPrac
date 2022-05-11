using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using BrowserControl;

namespace Test.Pages
{
    class Sign_In_Page:Browser
    {
        public void Move_To_SignIn()
        {
            By s = By.XPath("//div/a[@class='login']");
            Move(driver, s);
        }

        public void check_mail(string mail)
        {
            Move_To_SignIn();
            Move(driver,Locators.Email_create,mail);
        }

        public void Sign_In(String mail,String psd)
        {   
            Move(driver, Locators.Email_create, mail);

           // By p = By.XPath("//*[@id='email']//following::input[@id='passwd']");
            Move(driver,Locators.Sign_in_Pass, psd);

           // By sub = By.XPath("//*[@id='email']//following::input[@id='passwd']//following::button[@id='SubmitLogin']");
            Move(driver, Locators.Sign_in_Sub);
        }
    }
}
