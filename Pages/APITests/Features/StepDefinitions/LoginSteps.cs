using TechTalk.SpecFlow;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

[Binding]
public class LoginSteps
{
    private IWebDriver? _driver;

    // Hook do SpecFlow que roda antes de cada cenário para abrir o navegador
    [BeforeScenario]
    public void BeforeScenario()
    {
        _driver = new ChromeDriver();
        _driver.Manage().Window.Maximize();
    }

    [Given(@"que estou na página de login do SauceDemo")]
    public void DadoQueEstouNaPaginaDeLoginDoSauceDemo()
    {
        _driver.Navigate().GoToUrl("https://www.saucedemo.com/");
    }

    [When(@"preencho o usuário ""(.*)"" e a senha ""(.*)""")]
    public void QuandoPreenchoOUsuarioEASenha(string usuario, string senha)
    {
        // Se você já tem sua LoginPage estruturada, pode chamá-la aqui:
        // LoginPage loginPage = new LoginPage(_driver);
        // loginPage.PreencherUsuario(usuario);
        // loginPage.PreencherSenha(senha);

        // Exemplo direto com Selenium caso queira testar rapidinho:
        _driver.FindElement(By.Id("user-name")).SendKeys(usuario);
        _driver.FindElement(By.Id("password")).SendKeys(senha);
    }

    [When(@"clico no botão de login")]
    public void QuandoClicoNoBotaoDeLogin()
    {
        _driver.FindElement(By.Id("login-button")).Click();
    }

    [Then(@"sou redirecionado para a página de inventário de produtos")]
    public void EntaoSouRedirecionadoParaAPaginaDeInventarioDeProdutos()
    {
        bool estaNaPaginaDeInventario = _driver.Url.Contains("inventory.html");
        Assert.That(estaNaPaginaDeInventario, Is.True, "O usuário não foi redirecionado para a página de inventário.");
    }

    // Hook do SpecFlow que roda depois de cada cenário para fechar o navegador
    [AfterScenario]
    public void AfterScenario()
    {
        if (_driver != null)
        {
            _driver.Quit();
            _driver.Dispose();
        }
    }
}
