using Bogus;
using Bogus.Extensions.Brazil;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Reflection.PortableExecutable;
using System.Threading;

namespace TesteProjeto
{
    class TestCadastro : Cenarios
    {
        [Test]
        public void Teste()
        {
            try
            {
                var faker = new Faker("pt_BR");

                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(CoreHelpers.TimeSpan));

                if (CoreHelpers.IsNatura)
                {
                    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(CoreHelpers.TimeSpan);
                    driver.FindElement(By.XPath("//span[contains(text(), 'Entre ou cadastre-se')]")).Click();

                    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(CoreHelpers.TimeSpan);
                    driver.FindElement(By.XPath("//span[contains(text(), 'Criar conta')]")).Click();
                }
                else
                {
                    By cadastrarSeButtonLocator = By.XPath("//a[contains(text(), 'Cadastrar-se')]");

                    //wait.Until(driver => driver.FindElement(cadastrarSeButtonLocator).Displayed);

                    // Encontra o botão "Cadastrar-se"
                    IWebElement cadastrarSeButton = driver.FindElement(cadastrarSeButtonLocator);

                    // Clica no botão "Cadastrar-se"
                    cadastrarSeButton.Click();
                }

                DadosPessoais dadosPessoais = new DadosPessoais();

                PreencherFormularios(faker, dadosPessoais);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private void PreencherFormularios(Faker faker, DadosPessoais dadosPessoais)
        {
            try
            {
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(CoreHelpers.TimeSpan);
                driver.FindElement(By.Name("firstName")).Click();
                driver.FindElement(By.Name("firstName")).SendKeys(dadosPessoais.FirstName);

                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(CoreHelpers.TimeSpan);
                driver.FindElement(By.Name("lastName")).Click();
                driver.FindElement(By.Name("lastName")).SendKeys(dadosPessoais.LastName);

                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(CoreHelpers.TimeSpan);
                driver.FindElement(By.Name("email")).Click();
                driver.FindElement(By.Name("email")).SendKeys(dadosPessoais.Email);

                if (CoreHelpers.IsNatura)
                {
                    CoreHelpers.ScrollVertical(driver);
                }

                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(CoreHelpers.TimeSpan);
                driver.FindElement(By.Name("password")).Click();

                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(CoreHelpers.TimeSpan);
                driver.FindElement(By.Name("password")).SendKeys(dadosPessoais.Password);

                CoreHelpers.ScrollVertical(driver);

                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(CoreHelpers.TimeSpan);
                driver.FindElement(By.Name("confirmPassword")).Click();

                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(CoreHelpers.TimeSpan);
                driver.FindElement(By.Name("confirmPassword")).SendKeys(dadosPessoais.ConfirmPassword);

                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(CoreHelpers.TimeSpan);
                driver.FindElement(By.Name("cpf")).Click();
                driver.FindElement(By.Name("cpf")).SendKeys(dadosPessoais.Cpf);

                CoreHelpers.ScrollVertical(driver);

                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(CoreHelpers.TimeSpan);
                driver.FindElement(By.XPath("//input[@name='dateOfBirth']")).SendKeys(dadosPessoais.DateOfBirth);

                if (!CoreHelpers.IsNatura)
                {
                    CoreHelpers.ScrollVertical(driver);
                }

                switch (dadosPessoais.Sexo)
                {
                    case Bogus.DataSets.Name.Gender.Male:
                        driver.FindElement(By.XPath("//span[contains(text(), 'Feminino')]")).Click();
                        break;
                    case Bogus.DataSets.Name.Gender.Female:
                        driver.FindElement(By.XPath("//span[contains(text(), 'Masculino')]")).Click();
                        break;
                    default:
                        driver.FindElement(By.XPath("//span[contains(text(), 'Não especificar')]")).Click();
                        break;
                }

                CoreHelpers.ScrollVertical(driver);

                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(CoreHelpers.TimeSpan);
                driver.FindElement(By.Name("homePhone")).Click();
                driver.FindElement(By.Name("homePhone")).SendKeys(dadosPessoais.PhoneNumber);

                if (CoreHelpers.IsNatura)
                {
                    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(CoreHelpers.TimeSpan);
                    driver.FindElement(By.Name("whatsappPhone")).Click();
                    driver.FindElement(By.Name("whatsappPhone")).SendKeys(dadosPessoais.PhoneNumber);
                }

                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(CoreHelpers.TimeSpan);
                driver.FindElement(By.Name("acceptedterms")).Click();

                driver.FindElement(By.XPath("//span[contains(text(), 'Criar Conta')]")).Click();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
