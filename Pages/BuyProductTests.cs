using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using projeto_qa_csharp.Pages;

namespace projeto_qa_csharp.Tests
{
    public class BuyProductTests
    {
        private IWebDriver _driver;

        [SetUp]
        public void Setup()
        {
            var options = new ChromeOptions();
            
            // Desativa gerenciador de senhas e alertas de vazamento para evitar pop-ups na tela
            options.AddUserProfilePreference("credentials_enable_service", false);
            options.AddUserProfilePreference("profile.password_manager_enabled", false);
            options.AddUserProfilePreference("profile.password_manager_leak_detection", false);
            
            options.AddArgument("--disable-save-password-bubble");
            options.AddArgument("--disable-notifications");
            options.AddArgument("--disable-infobars");

            _driver = new ChromeDriver(options);                              // Inicializa o Chrome          [Setup]
            _driver.Manage().Window.Maximize();                                 // Maximiza a janela            [Setup]
            _driver.Navigate().GoToUrl("https://www.saucedemo.com/");            // Abre o site do SauceDemo     [Setup]
        }

        // 1. Cenário do Caminho Feliz (Happy Path E2E Completo)
        [Test]
        public void TesteHappyPath_CompraCompletaComSucesso()
        {
            var loginPage = new LoginPage(_driver);                             // Instancia a página de login  [Página]
            var inventoryPage = new InventoryPage(_driver);                     // Instancia a de inventário    [Página]
            var cartPage = new CartAndCheckoutPage(_driver);                    // Instancia a de carrinho      [Página]

            loginPage.FazerLogin("standard_user", "secret_sauce");              // Realiza o login com sucesso  [Ação]
            inventoryPage.AdicionarMochilaAoCarrinho();                         // Adiciona produto ao carrinho [Ação]
            inventoryPage.IrParaCarrinho();                                     // Navega para o carrinho       [Ação]
            
            cartPage.IrParaCheckout();                                          // Clica no botão de checkout   [Ação]
            cartPage.PreencherDadosCheckout("João", "Silva", "29100-000");        // Preenche dados válidos       [Ação]
            cartPage.FinalizarCompra();                                         // Clica em finalizar           [Ação]

            // Valida se a mensagem de sucesso apareceu na tela
            Assert.That(cartPage.ObterMensagemSucesso(), Does.Contain("Thank you for your order!"));
        }

        // 2. Cenário Negativo (Validação de Erro no Login)
        [Test]
        public void TesteNegativo_LoginInvalido()
        {
            var loginPage = new LoginPage(_driver);                             // Instancia a página de login  [Página]

            loginPage.FazerLogin("standard_user", "senha_errada_123");            // Tenta logar com senha errada [Ação]

            string mensagemEsperada = "Epic sadface: Username and password do not match any user in this service";
            string mensagemAtual = loginPage.ObterMensagemErro();                 // Pega o erro exibido na tela  [Leitura]

            Assert.That(mensagemAtual, Does.Contain(mensagemEsperada), "A mensagem de erro difere."); // Valida erro [Assert]
        }

        // 3. Cenário Negativo de Checkout (Campos Obrigatórios Vazios)
        [Test]
        public void TesteNegativo_CheckoutCamposVazios()
        {
            var loginPage = new LoginPage(_driver);
            var inventoryPage = new InventoryPage(_driver);
            var cartPage = new CartAndCheckoutPage(_driver);

            loginPage.FazerLogin("standard_user", "secret_sauce");
            inventoryPage.AdicionarMochilaAoCarrinho();
            inventoryPage.IrParaCarrinho();
            
            cartPage.IrParaCheckout();
            
            // Tentamos avançar preenchendo o nome e sobrenome, mas deixando o CEP vazio ("")
            cartPage.PreencherDadosCheckout("João", "Silva", "");

            string mensagemEsperada = "Error: Postal Code is required";
            string mensagemAtual = cartPage.ObterMensagemErroCheckout();

            Assert.That(mensagemAtual, Does.Contain(mensagemEsperada), "A mensagem de erro do checkout difere.");
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();                                                     // Fecha o navegador            [TearDown]
            _driver.Dispose();                                                  // Libera os recursos de memória[TearDown]
        }
    }
}