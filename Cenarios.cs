using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TesteProjeto
{
    public class Cenarios
    {
        public IWebDriver driver;

        [SetUp]
        public void InicioTeste()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            if (CoreHelpers.IsNatura)
            {
                driver.Navigate().GoToUrl("https://www.natura.com.br/");
            }
            else
            {
                driver.Navigate().GoToUrl("https://www.aesop.com.br/");
            }
        }

      

        [TearDown]
        public void FimDoTeste()
        {
        }
    }
}