using NUnit.Framework;
using BrowserControl;
using OpenQA.Selenium;
using System.Threading;
using System.Collections.Generic;
using System.Text;
using System;

namespace Test
{
    public class Tests:Browser
    {
        [SetUp]
        public void Setup()
        {
            url = "http://automationpractice.com/index.php";
            Open_Url();
        }

        [Test,Category("Sign in")]
        public void Test1()
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

            Assert.Pass();
        }

        [Test,Category("Invalid Email")]
        public void Test2()
        {
            By s = By.XPath("//div/a[@class='login']");
            Move(driver, s);
            By email = By.XPath("//*[@id='email']");
            Move(driver, email, "xyt");

            Assert.Pass();
        }

        [Test,Category("Mandatory Field Error Message")]
        public void Test3()
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
            Move(driver,company);
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
            Move(driver, pin,"00");
            scroll();
            By country = By.XPath("//*[@id='id_country']");
            drop_down_list(country, "-");
         

            scroll();
            By submitBtn = By.XPath("//*[@id='submitAccount']");
            Move(driver, submitBtn);
            Assert.Pass("Passed");
        }
      
        [Test, Category("Search Product")]
        public void Test4()
        {
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

       // [Test,Category("Buy Product")]

        [TearDown]
        public void EndTest()
        {
            close_quit();
        }
    }
}