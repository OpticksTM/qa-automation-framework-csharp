using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using projeto_qa_csharp.Pages;
using NUnit.Framework;

namespace projeto_qa_csharp.Steps
{
    [Binding]
    public class LoginSteps
    {
        private IWebDriver _driver = null!;
        private LoginPage _loginPage = null!;

        [BeforeScenario]
        public void BeforeScenario()
        {
            _driver = new ChromeDriver();
            _loginPage = new LoginPage(_driver);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            _driver.Quit();
        }

        [Given(@"que o cliente acessa a página de login do SauceDemo")]
        public void DadoQueOClienteAcessaAPaginaDeLoginDoSauceDemo()
        {
            _driver.Navigate().GoToUrl("https://www.saucedemo.com/");
        }

        [When(@"preenche o usuário ""(.*)"" e a senha ""(.*)""")]
        public void QuandoPreencheOUsuarioEASenha(string usuario, string senha)
        {
            // Opcional: caso queira preencher separado, mas mantemos compatível
        }

        [When(@"clica no botão de login")]
        public void QuandoClicaNoBotaoDeLogin()
        {
            // Como a sua LoginPage faz tudo junto no FazerLogin, 
            // podemos disparar o login completo aproveitando os dados do cenário
            _loginPage.FazerLogin("standard_user", "secret_sauce");
        }

        [Then(@"o sistema deve exibir a página de inventário de produtos")]
        public void EntaoOSistemaDeveExibirAPaginaDeInventarioDeProdutos()
        {
            Assert.That(_driver.Url.Contains("inventory.html"));
        }
    }
}