using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace projeto_qa_csharp.Pages
{
    public class CartAndCheckoutPage
    {
        private readonly IWebDriver _driver;

        // Mapeamentos usando By
        private By CheckoutButton => By.Id("checkout");
        private By FirstNameField => By.Id("first-name");
        private By LastNameField => By.Id("last-name");
        private By PostalCodeField => By.Id("postal-code");
        private By ContinueButton => By.Id("continue");
        private By FinishButton => By.Id("finish");
        private By CompleteHeader => By.ClassName("complete-header");

        public CartAndCheckoutPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void IrParaCheckout()
        {
            // Espera inteligente: garante que o botão de checkout está visível e clicable
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            var checkoutBtn = wait.Until(d => d.FindElement(CheckoutButton));
            checkoutBtn.Click();
        }

        public void PreencherDadosCheckout(string nome, string sobrenome, string cep)
        {
            // Espera inteligente: garante que o formulário de primeiro nome carregou após ir para o checkout
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            var firstNameElement = wait.Until(d => d.FindElement(FirstNameField));

            firstNameElement.SendKeys(nome);
            _driver.FindElement(LastNameField).SendKeys(sobrenome);
            _driver.FindElement(PostalCodeField).SendKeys(cep);
            _driver.FindElement(ContinueButton).Click();
        }

        public void FinalizarCompra()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            var finishElement = wait.Until(d => d.FindElement(FinishButton));
            finishElement.Click();
        }

        public string ObterMensagemSucesso()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            return wait.Until(d => d.FindElement(CompleteHeader)).Text;
        }
    }
}