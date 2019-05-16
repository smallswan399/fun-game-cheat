using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://catch.cryptland.com/");
            var text = driver.Title;
            var play = driver.FindElement(By.Id("play"));
            
            play.Click();

            var button = driver.FindElement(By.Id("button"));
            var submit = driver.FindElement(By.Id("submit-score-modal"));
            var classes = submit.GetAttribute("class");
            while (!classes.Contains("in"))
            {
                Actions builder = new Actions(driver);
                builder.MoveToElement(button, 50, 50).Click().Build().Perform();
                //Thread.Sleep(5);
                classes = submit.GetAttribute("class");
            }

            Console.ReadLine();
            driver.Quit();
        }
    }
}
