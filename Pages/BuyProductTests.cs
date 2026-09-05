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
        private CartAndCheckoutPage _checkoutPage = null!;

        [SetUp]
        public void Setup()
        {
            // Opções avançadas para barrar qualquer pop-up de senha ou alerta de vazamento do Google
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--disable-save-password-bubble");
            options.AddArgument("--disable-autofill-keyboard-access-accessory");
            options.AddArgument("--disable-notifications");
            options.AddUserProfilePreference("credentials_enable_service", false);
            options.AddUserProfilePreference("profile.password_manager_enabled", false);
            
            // Desativa o recurso do Google que detecta vazamento de senhas para esta sessão do teste
            options.AddUserProfilePreference("profile.password_manager_leak_detection", false);

            _driver = new ChromeDriver(options);
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            
            _loginPage = new LoginPage(_driver);
            _inventoryPage = new InventoryPage(_driver);
            _checkoutPage = new CartAndCheckoutPage(_driver);
        }

        [Test]
        public void DeveRealizarFluxoDeCompraDePontaAPontaComSucesso()
        {
            // 1. Login
            _loginPage.FazerLogin("standard_user", "secret_sauce");
            Assert.That(_inventoryPage.ObterTituloDaPagina(), Is.EqualTo("Products"));

            // 2. Adicionar ao carrinho e abrir
            _inventoryPage.AdicionarMochilaAoCarrinho();
            _inventoryPage.IrParaCarrinho();

            // 3. Ir para o Checkout e preencher os dados
            _checkoutPage.IrParaCheckout();
            _checkoutPage.PreencherDadosCheckout("QA", "Automation", "29100-000");

            // 4. Finalizar o pedido
            _checkoutPage.FinalizarCompra();

            // 5. Validar mensagem de sucesso na tela final
            string mensagemSucesso = _checkoutPage.ObterMensagemSucesso();
            Assert.That(mensagemSucesso, Is.EqualTo("Thank you for your order!"), "O pedido não foi concluído com sucesso.");
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
            _driver.Dispose();
        }
    }
}