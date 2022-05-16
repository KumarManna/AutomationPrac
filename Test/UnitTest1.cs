using NUnit.Framework;
using BrowserControl;
using OpenQA.Selenium;
using System.Threading;
using System.Collections.Generic;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System.Text;
using System;

namespace Test
{
    public class Tests : Browser
    {
        public static ExtentReports Extent;
        public static ExtentTest Test;

        public static string def_handle;
        [OneTimeSetUp]
        public void Setup()
        {
            url = "http://automationpractice.com/index.php";
            Open_Url();
            def_handle = driver.CurrentWindowHandle;
            
        }

        [OneTimeSetUp]
        public void Initialize()
        {
            Extent = new ExtentReports();
            var HTMLReport = new ExtentHtmlReporter(@"D:\Bassetti Training\AutomationPrac Reports\" + DateTime.Now.ToString("__MMddyyyy__hhmmtt") + ".html");
            Extent.AttachReporter(HTMLReport);
        }

        [Test, Category("Sign in")]
        public void Test1()
        {
            Test = null;
            Test = Extent.CreateTest("T001").Info("Sign-in");
            try
            {
                Sign_In();

                Test.Log(Status.Pass, "Test Pass");

            }
            catch (Exception)
            {

                Test.Log(Status.Pass, "Test Failed");
                throw;
            }
        }
        public void Sign_In()
        {
            By s = By.XPath("//div/a[@class='login']");
            Move(driver, s);
            By email = By.XPath("//*[@id='email']");
            string Email = "Abo@hopefull.com";
            string password = "56@oi!AbghuIO";
            Move(driver, email, Email);

            By p = By.XPath("//*[@id='email']//following::input[@id='passwd']");
            Move(driver, p, password);

            By sub = By.XPath("//*[@id='email']//following::input[@id='passwd']//following::button[@id='SubmitLogin']");
            Move(driver, sub);
        }
        public void Sign_Out()
        {
            By sign_out = By.XPath("//*[@id='header']//child::a[@class='logout']");
            Move(driver, sign_out);
        }
        [Test, Category("Invalid Email")]
        public void Test2()
        {
            Sign_Out();
            Test = null;
            Test = Extent.CreateTest("T002").Info("Invalid Email Check");
            try
            {
                By s = By.XPath("//div/a[@class='login']");
                Move(driver, s);
                By email = By.XPath("//*[@id='email']");
                Move(driver, email, "xyt");
                By sub = By.XPath("//*[@id='email']//following::input[@id='passwd']//following::button[@id='SubmitLogin']");
                Move(driver, sub);
                Test.Log(Status.Pass, "Test Case Passed");

            }
            catch (Exception)
            {
                Test.Log(Status.Fail, "Test Case Failed");

            }
        }

        [Test, Category("Mandatory Field Error Message")]
        public void Test3()
        {
            driver.SwitchTo().Window(def_handle);
            Test = null;
            Test = Extent.CreateTest("T003").Info("Mandatory Field Error Message");
            try
            {
                By s = By.XPath("//div/a[@class='login']");
                Move(driver, s);
                By email = By.XPath("//*[@id='email_create']");
                Move(driver, email, "abf@hopefull.com");
                By sub = By.XPath("//*[@id='SubmitCreate']");
                Move(driver, sub);
                By f = By.XPath("//input[@id='customer_firstname']");
                Move(driver, f);
                By l = By.XPath("//input[@id='customer_lastname']");
                Move(driver, l);
                By e = By.XPath("//input[@id='email']");
                driver.FindElement(e).Clear();
                Move(driver, e);
                By p = By.XPath("//input[@id='passwd']");
                Move(driver, p);

                By f1 = By.XPath("//input[@id='firstname']");
                //driver.FindElement(f1).Clear();
                Move(driver, f1);
                By l1 = By.XPath("//input[@id='lastname']");
                // driver.FindElement(l1).Clear();
                Move(driver, l1);
                By company = By.XPath("//*[@id='company']");
                Move(driver, company);
                By address = By.XPath("//*[@id='address1']");
                Move(driver, address);
                By house_name = By.XPath("//*[@id='address1']//following::input[@id='address2']");
                Move(driver, house_name);
                By c = By.XPath("//*[@id='city']");
                Move(driver, c);
                By state = By.XPath("//*[@id='uniform-id_state']");
                Move(driver, state);
                By state_list = By.XPath("//*[@id='uniform-id_state']//child::select[@id='id_state']/option");
                drop_down_list(state_list, "-");
                By pin = By.XPath("//*[@id='postcode']");
                Move(driver, pin, "00");
                scroll();
                By country = By.XPath("//*[@id='id_country']");
                drop_down_list(country, "-");


                scroll();
                By submitBtn = By.XPath("//*[@id='submitAccount']");
                Move(driver, submitBtn);

                Test.Log(Status.Pass, "Test Case Passed");

            }
            catch (Exception)
            {
                Test.Log(Status.Fail, "Test Case Failed");

            }
        }

        [Test, Category("Search Product")]
        public void Test4()
        {

            By t = By.XPath("//div[@id='block_top_menu']/ul/li[3]");
            Move(driver, t);
            scroll();
            scroll();
            By image = By.XPath("//*[@class='product-image-container']");
            Mouse_Hover(driver, driver.FindElement(image));
            Thread.Sleep(100);
            By more = By.XPath("//div[@class='right-block']//child::a[2]");
            Mouse_Action(driver, driver.FindElement(more));
            Thread.Sleep(1000);

            string t1 = "//*[@class='table-data-sheet']//child::tr[";
            string t2 = "]/td[";
            string t3 = "]";
            IReadOnlyCollection<IWebElement> e;
            int j;
            IDictionary<string, string> d = new Dictionary<string, string>();
            for (int i = 1; i <= 3; i++)
            {
                e = driver.FindElements(By.XPath(t1 + i.ToString() + "]"));
                j = 1;
                foreach (IWebElement s in e)
                {
                    while (j < 3)
                    {
                        d.Add(driver.FindElement(By.XPath(t1 + i.ToString() + "]")).Text, driver.FindElement(By.XPath(t1 + i.ToString() + t2 + j.ToString() + t3)).Text);
                        j++;
                        if (j == 2)
                            break;
                    }
                }
            }

            string item_name = driver.FindElement(By.XPath("//*[@itemprop='name']")).Text;
            By s1 = By.XPath("//*[@id='search_query_top']");
            Move(driver, s1, item_name);
            Thread.Sleep(100);
            By search = By.XPath("//*[@id='search_query_top']//following-sibling::button");
            Move(driver, search);
            Thread.Sleep(1000);
            scroll();
            scroll();


            Mouse_Hover(driver, driver.FindElement(image));
            Thread.Sleep(100);
            Mouse_Action(driver, driver.FindElement(more));
            Thread.Sleep(1000);
            IDictionary<string, string> d1 = new Dictionary<string, string>();
            for (int i = 1; i <= 3; i++)
            {
                //Console.WriteLine(i);
                e = driver.FindElements(By.XPath(t1 + i.ToString() + "]"));
                j = 1;
                foreach (IWebElement s in e)
                {
                    while (j < 3)
                    {
                        d1.Add(driver.FindElement(By.XPath(t1 + i.ToString() + "]")).Text, driver.FindElement(By.XPath(t1 + i.ToString() + t2 + j.ToString() + t3)).Text);
                        j++;
                        if (j == 2)
                            break;
                    }
                }

            }
            bool equal = false;
            if (d.Count == d1.Count) // Require equal count.
            {
                equal = true;
                foreach (var pair in d)
                {
                    string value;
                    if (d1.TryGetValue(pair.Key, out value))
                    {
                        // Require value be equal.
                        if (value != pair.Value)
                        {
                            equal = false;
                            break;
                        }
                    }
                    else
                    {
                        // Require key be present.
                        equal = false;
                        break;
                    }
                }
            }
            bool x = true;
            Assert.AreEqual(x, equal);
       }

        [Test, Category("Buy Product")]
        public void Test5()
        {
            Test = null;
            Test = Extent.CreateTest("T005").Info("Buy Product");
            driver.Navigate().GoToUrl(url);
            try
            {
                By t1 = By.XPath("//div[@id='block_top_menu']/ul/li[1]");
                Mouse_Hover(driver, driver.FindElement(t1));
                By t2 = By.XPath("//div[@id='block_top_menu']/ul/li[1]//child::li[1]//child::li[1]/a");
                Mouse_Hover(driver, driver.FindElement(t2));
                Move(driver, t2);
                By image = By.XPath("//*[@class='product-image-container']");
                Mouse_Hover(driver, driver.FindElement(image));
                Thread.Sleep(100);
                By more = By.XPath("//div[@class='right-block']//child::a[2]");
                Cursor_Move(driver, driver.FindElement(more));
                Mouse_Action(driver, driver.FindElement(more));
                Thread.Sleep(100);
                By inc = By.XPath("//*[@id='quantity_wanted_p']//child::a[2]");
                Move(driver, inc);
                By size_c = By.XPath("//*[@id='attributes']//child::*[@id='uniform-group_1']");
                Move(driver, size_c);
                Thread.Sleep(1000);
                string o = "//*[@id='attributes']//child::*[@id='uniform-group_1']//child::*[@id='group_1']/option[@value='";
                By size_option = By.XPath("//*[@id='attributes']//child::*[@id='uniform-group_1']//child::*[@id='group_1']/option");

                IReadOnlyCollection<IWebElement> list = driver.FindElements(size_option);
                Console.WriteLine(list.Count);
                string t, v;
                foreach (IWebElement element in list)
                {
                    t = element.Text;
                    v = element.GetAttribute("value");
                    if ("L" == t)
                    {
                        element.Click();
                        break;
                    }
                    Console.WriteLine(o + v.ToString() + "']");
                }
                Thread.Sleep(100);
                scroll();
                By or = By.XPath("//*[@id='color_to_pick_list']/li[2]/a");
                Move(driver, or);
                Thread.Sleep(100);
                scroll();
                By sub = By.XPath("//*[@id='add_to_cart']//child::button");
                Move(driver, sub);
                Thread.Sleep(100);
                By check_out_btn1 = By.XPath("//*[@class='button-container']//child::a");
                Move(driver, check_out_btn1);
                Thread.Sleep(100);
                scroll();
                By check_out_btn2 = By.XPath("//*[@class='cart_navigation clearfix']/a");
                Move(driver, check_out_btn2);
                Thread.Sleep(100);
                // Sign_In();
                By email = By.XPath("//*[@id='email']");
                //Console.WriteLine(Email);
                //Console.WriteLine(this.Email);
                string Email = "Abo@hopefull.com";
                string Password = "56@oi!AbghuIO";
                Move(driver, email, Email);

                By p = By.XPath("//*[@id='email']//following::input[@id='passwd']");
                Move(driver, p, Password);

                By sub_Login = By.XPath("//*[@id='email']//following::input[@id='passwd']//following::button[@id='SubmitLogin']");
                Move(driver, sub_Login);
                Thread.Sleep(100);
                By check_out_btn3 = By.XPath("//*[@class='cart_navigation clearfix']//child::button");
                Move(driver, check_out_btn3);
                Thread.Sleep(100);
                scroll();
                scroll();
                // By check_box = By.XPath("//*[@id='uniform-cgv']//child::input[@id='cgv']");
                By check_box = By.Id("cgv");
                Mouse_Hover(driver, driver.FindElement(check_box));
                Mouse_Action(driver, driver.FindElement(check_box));
                //f.Form_Fill(driver, check_box, b);
                Thread.Sleep(100);
                //*[@class='cart_navigation clearfix']//child::button
                Move(driver, check_out_btn3);
                Thread.Sleep(100);
                scroll();
                By pay_bank_wire = By.XPath("//*[@id='HOOK_PAYMENT']//child::p/a");
                Move(driver, pay_bank_wire);

                scroll();
                Thread.Sleep(100);
                Move(driver, check_out_btn3);
                scroll();
                scroll();
                Thread.Sleep(5000);

                Test.Log(Status.Pass, "Test Case Passed");
                //Assert.Pass("Order test passed");
            }
            catch (Exception)
            {
                Test.Log(Status.Fail, "Test Case Failed");
                throw;
            }

        }



        [Test, Category("Add to wish list")]

        public void Test6()
        {
            By t1 = By.XPath("//div[@id='block_top_menu']/ul/li[1]");
            Mouse_Hover(driver, driver.FindElement(t1));
            By t2 = By.XPath("//div[@id='block_top_menu']/ul/li[1]//child::li[1]//child::li[1]/a");
            Mouse_Hover(driver, driver.FindElement(t2));
            Move(driver, t2);
            By image = By.XPath("//*[@class='product-image-container']");
            Mouse_Hover(driver, driver.FindElement(image));
            Thread.Sleep(100);
            By wl = By.XPath("//*[@class='functional-buttons clearfix']//child::a");
            Mouse_Hover(driver, driver.FindElement(wl));
            Thread.Sleep(100);
            Move(driver, wl);
            Thread.Sleep(1000);
            By e_txt = By.XPath("//*[@class='fancybox-skin']//child::p");
            Thread.Sleep(3000);
            string error_txt = driver.FindElement(e_txt).Text;
            Console.WriteLine(error_txt);

            if (error_txt == "You must be logged in to manage your wishlist.")
            {
                Console.WriteLine("Test case passed");
            }
            else
            {
                Console.WriteLine("Failed");//*[@class='fancybox-skin']//child::p
            }
            Assert.AreEqual("You must be logged in to manage your wishlist.", error_txt, "Test case 6 passed");
        }

        [Test, Category("Shopping Cart Summary Page")]

        public void Test7()
        {
            driver.SwitchTo().Window(def_handle);
            By t1 = By.XPath("//div[@id='block_top_menu']/ul/li[1]");
            Mouse_Hover(driver, driver.FindElement(t1));
            By t2 = By.XPath("//div[@id='block_top_menu']/ul/li[1]//child::li[1]//child::li[1]/a");
            Mouse_Hover(driver, driver.FindElement(t2));
            Move(driver, t2);
            By image = By.XPath("//*[@class='product-image-container']");
            Mouse_Hover(driver, driver.FindElement(image));
            Thread.Sleep(100);
            By more = By.XPath("//div[@class='right-block']//child::a[2]");
            Cursor_Move(driver, driver.FindElement(more));
            Mouse_Action(driver, driver.FindElement(more));
            Thread.Sleep(100);
            scroll();
            By min_item = By.XPath("//*[@id='quantity_wanted_p']//child::input");
            string min_num = driver.FindElement(min_item).GetAttribute("value");
            if (min_num == "1")
                Console.WriteLine("Test case inner passed");
            else
                Console.WriteLine("Test case inner not passed");
            Assert.AreEqual("1", min_num, "Inner case passed");

            By size_c = By.XPath("//*[@id='attributes']//child::*[@id='uniform-group_1']");
            Move(driver, size_c);
            Thread.Sleep(1000);
            string o = "//*[@id='attributes']//child::*[@id='uniform-group_1']//child::*[@id='group_1']/option[@value='";
            By size_option = By.XPath("//*[@id='attributes']//child::*[@id='uniform-group_1']//child::*[@id='group_1']/option");

            IReadOnlyCollection<IWebElement> list = driver.FindElements(size_option);
            Console.WriteLine(list.Count);
            string t, v;
            foreach (IWebElement element in list)
            {
                t = element.Text;
                v = element.GetAttribute("value");
                if ("M" == t)
                {
                    element.Click();
                    break;
                }
                Console.WriteLine(o + v.ToString() + "']");
            }
            Thread.Sleep(100);
            scroll();
            By or = By.XPath("//*[@id='color_to_pick_list']/li[2]/a");
            Move(driver, or);
            By sub = By.XPath("//*[@id='add_to_cart']//child::button");
            Move(driver, sub);
            Thread.Sleep(100);
            By check_out_btn1 = By.XPath("//*[@class='button-container']//child::a");
            Move(driver, check_out_btn1);
            Thread.Sleep(100);
            string price1 = driver.FindElement(By.XPath("//*[@id='cart_summary']//child::td[6]/span")).Text;
            Console.WriteLine(price1);
            By inc = By.XPath("//*[@class='cart_quantity_button clearfix']/a[2]");
            Move(driver, inc);
            Thread.Sleep(3000);
            scroll();
            scroll();
            string tp = driver.FindElement(By.XPath("//*[@id='total_price_container']/span")).Text;

            Assert.AreEqual("$35.02", tp, "Test case total price passed");

        }
        [OneTimeTearDown]
        public void EndTest()
        {
            Extent.Flush();
            close_quit();
        }
    }
}