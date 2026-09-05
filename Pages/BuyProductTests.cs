using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using projeto_qa_csharp.Pages;

namespace projeto_qa_csharp
{
    public class BuyProductTests
    {
        private IWebDriver _driver = null!;
        private LoginPage _loginPage = null!;
        private InventoryPage _inventoryPage = null!;

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            
            _loginPage = new LoginPage(_driver);
            _inventoryPage = new InventoryPage(_driver);
        }

        [Test]
        public void DeveAdicionarProdutoAoCarrinhoComSucesso()
        {
            // Act 1: Faz o login utilizando a LoginPage (reaproveitando o POM anterior)
            _loginPage.FazerLogin("standard_user", "secret_sauce");

            // Assert 1: Garante que chegou na página de inventário
            Assert.That(_inventoryPage.ObterTituloDaPagina(), Is.EqualTo("Products"), "Não foi possível acessar a página de produtos.");

            // Act 2: Adiciona o produto e vai para o carrinho usando a InventoryPage
            _inventoryPage.AdicionarMochilaAoCarrinho();
            _inventoryPage.IrParaCarrinho();

            // Assert 2: Valida se foi direcionado para a página do carrinho
            Assert.That(_driver.Url, Does.Contain("cart.html"), "O usuário não foi direcionado para o carrinho.");
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
            _driver.Dispose();
        }
    }
}