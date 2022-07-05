using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;

namespace InvoiceCloudTest
{
    [TestClass]
    public class CodeTest
    {
        [TestMethod]
        public void TestMethod()
        {
            int numElements = 5;

            string path = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
            var driver = new ChromeDriver(path+"\\drivers\\");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/add_remove_elements/");

            var addElement = driver.FindElement(By.CssSelector("button[onclick=\"addElement()\"]"));

            for (int n = 0; n < numElements; ++n)
            {
                addElement.Click();
            }

            var createdElements = driver.FindElements(By.ClassName("added-manually"));

            Assert.AreEqual(createdElements.Count, numElements);

            driver.Quit();
        }
    }
}