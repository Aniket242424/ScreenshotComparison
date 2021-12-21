using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SpecFlowProject1.Utility
{
    class Utils:Base
    {
       
        
        public void Navigate(string url)
        {
            Utils.InitializeDriver();
            driver.Navigate().GoToUrl(url);
        }

        public void Login(String userName,String password)
        {

        }

        internal void TypeInTextBox(string keyword)
        {
            driver.FindElement(By.Name("q")).SendKeys(keyword);
        }

        internal void ClickOnSearchButton()
        {
            Thread.Sleep(2000);
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            executor.ExecuteScript("arguments[0].click();", driver.FindElement(By.XPath("(//input[@value='Google Search'])[last()]")));
        }


    }
}
