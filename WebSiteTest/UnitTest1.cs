using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using System;
using OpenQA.Selenium.Support.UI;

namespace WebSiteTest
{
    public class Tests
    {

        IWebDriver driver;
        
        String test_url = "https://maria-juliajarv22.thkit.ee/Forms/kysemustik.html";

        private readonly Random _random = new Random();

        [SetUp]
        public void start_browser()
        {
            driver = new FirefoxDriver();
            driver.Manage().Window.Maximize();


        }

        [Test]
        public void test_page1()
        {
            driver.Url = test_url;

            driver.Navigate().GoToUrl("https://maria-juliajarv22.thkit.ee/Forms/kysemustik.html");



            driver.SwitchTo().DefaultContent();


            Thread.Sleep(3000);

            for (int a = 0; a < 1; a++)
            {

                Thread.Sleep(2500);
                var sText = driver.FindElements(By.XPath("//input[@type='text']"));
                for (int i = 0; i < sText.Count; i++)
                {
                    try { sText[i].Click(); sText[i].SendKeys("Toivo"); } catch (Exception) { Console.WriteLine("Error,unable to fill in  one of  the input field"); }
                }

                Thread.Sleep(3000);


                var els = driver.FindElements(By.XPath(".//input[@type='radio']"));
                Thread.Sleep(1000);


                var randomIndex = _random.Next(0, els.Count);
                var selectedRadio = els[randomIndex];
                if (selectedRadio.Enabled)
                {

                    try { selectedRadio.Click(); }

                    catch (Exception) { Console.WriteLine("Error,button disabled"); }
                }
                else
                {
                    Console.WriteLine("Error,button disabled");
                }


                Thread.Sleep(2500);
                var Select = driver.FindElements(By.XPath("//input[@type='checkbox']"));
                for (int i = 0; i < Select.Count; i++)
                {
                    try { Select[i].Click(); } catch (Exception) { Console.WriteLine("Error,checkbox did not work"); }

                }
                Thread.Sleep(2500);
                var sSelect = driver.FindElements(By.XPath("//select"));
                for (int i = 0; i < sSelect.Count; i++)
                {
                    try { sSelect[i].Click(); sSelect[i].FindElements(By.XPath(".//*"))[2].Click(); }
                    catch (Exception) { Console.WriteLine("Error,unable to choose select option"); }
                }

                Thread.Sleep(2500);



                var birthdate = driver.FindElements(By.XPath("//input[@type='date']"));
                foreach (var dateInput in birthdate)
                {
                    try
                    {
                        dateInput.Clear();
                        dateInput.SendKeys("2023-09-13"); // Change to the desired date.
                    }
                    catch (Exception ex)
                    {

                        Assert.Fail($"Error: Unable to fill in date input field - {ex.Message}");
                    }

                }

                Thread.Sleep(2500);
                var reg = driver.FindElement(By.XPath("//input[@type='button']"));
                try { reg.Click(); } catch (Exception) { Console.WriteLine("Error, button is functional"); }


                Thread.Sleep(2500);
                var reset = driver.FindElement(By.XPath("//input[@type='reset']"));
                reset.Click();
               
                Thread.Sleep(6000);
                driver.SwitchTo().DefaultContent();
            }
        }
         
                    
        [TearDown]
        public void close_Browser()
        {
            driver.Quit();
        }
    }
}

