using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using projeto_qa_csharp.Pages;

namespace projeto_qa_csharp
{
    public class LoginTests
    {
        private IWebDriver _driver = null!;
        private LoginPage _loginPage = null!;

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            
            // Instancia a página de login passando o driver ativo
            _loginPage = new LoginPage(_driver);
        }

        [Test]
        public void DeveRealizarLoginComSucesso()
        {
            // Act: Executa as ações usando os métodos do Page Object
            _loginPage.FazerLogin("standard_user", "secret_sauce");

            // Assert: Valida se a URL mudou para o inventory (indicando sucesso no login)
            Assert.That(_driver.Url, Does.Contain("inventory.html"), "O login não foi realizado com sucesso.");
        }

        [TearDown]
        public void TearDown()
        {
            // Fecha o navegador após o teste para não deixar processos abertos
            _driver.Quit();
            _driver.Dispose();
        }
    }
}