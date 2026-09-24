using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace projeto_qa_csharp.Pages
{
    public class InventoryPage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        private IWebElement AddToCartBackpackButton => _wait.Until(d => d.FindElement(By.Id("add-to-cart-sauce-labs-backpack")));
        private IWebElement CartIcon => _driver.FindElement(By.ClassName("shopping_cart_link"));
        private IWebElement PageTitle => _driver.FindElement(By.ClassName("title"));

        public InventoryPage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        }

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