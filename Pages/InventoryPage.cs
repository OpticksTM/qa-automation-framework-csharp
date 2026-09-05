using OpenQA.Selenium;

namespace projeto_qa_csharp.Pages
{
    public class InventoryPage
    {
        private readonly IWebDriver _driver;

        // Mapeamento dos elementos da tela de inventário/produtos
        // Usando o ID do primeiro produto (Sauce Labs Backpack) como exemplo
        private IWebElement AddToCartBackpackButton => _driver.FindElement(By.Id("add-to-cart-sauce-labs-backpack"));
        private IWebElement CartIcon => _driver.FindElement(By.ClassName("shopping_cart_link"));
        private IWebElement PageTitle => _driver.FindElement(By.ClassName("title"));

        public InventoryPage(IWebDriver driver)
        {
            _driver = driver;
        }

        // Métodos de ação da página
        public string ObterTituloDaPagina()
        {
            return PageTitle.Text;
        }

        public void AdicionarMochilaAoCarrinho()
        {
            AddToCartBackpackButton.Click();
        }

        public void IrParaCarrinho()
        {
            CartIcon.Click();
        }
    }
}