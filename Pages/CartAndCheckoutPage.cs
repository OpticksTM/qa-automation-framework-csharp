using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace projeto_qa_csharp.Pages
{
    public class CartAndCheckoutPage
    {
        private readonly IWebDriver _driver;

        // Construtor
        public CartAndCheckoutPage(IWebDriver driver)
        {
            _driver = driver;
        }

        // Mapeamento de Elementos (Locators)
        private By CheckoutButton => By.Id("checkout");
        private By FirstNameField => By.Id("first-name");
        private By LastNameField => By.Id("last-name");
        private By ZipCodeField => By.Id("postal-code");
        private By ContinueButton => By.Id("continue");
        private By FinishButton => By.Id("finish");
        private By SuccessMessage => By.CssSelector(".complete-header");
        
        // Novo mapeamento para a mensagem de erro do checkout
        private By ErrorMessageCheckout => By.CssSelector("h3[data-test='error']");

        // Ações da Página
        public void IrParaCheckout()
        {
            _driver.FindElement(CheckoutButton).Click();
        }

        public void PreencherDadosCheckout(string nome, string sobrenome, string cep)
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            
            // Aguarda o campo de primeiro nome ficar visível antes de interagir
            wait.Until(d => d.FindElement(FirstNameField)).SendKeys(nome);
            _driver.FindElement(LastNameField).SendKeys(sobrenome);
            _driver.FindElement(ZipCodeField).SendKeys(cep);
            _driver.FindElement(ContinueButton).Click();
        }

        public void FinalizarCompra()
        {
            _driver.FindElement(FinishButton).Click();
        }

        public string ObterMensagemSucesso()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            return wait.Until(d => d.FindElement(SuccessMessage)).Text;
        }

        // Novo método para capturar o erro de campos obrigatórios no checkout
        public string ObterMensagemErroCheckout()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            return wait.Until(d => d.FindElement(ErrorMessageCheckout)).Text;
        }
    }
}