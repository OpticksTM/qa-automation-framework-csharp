global using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace projeto_qa_csharp;

public class LoginTests
{
    private IWebDriver driver = null!;

    [SetUp]
    public void Setup()
    {
        // Inicializa o navegador Chrome
        driver = new ChromeDriver();
        
        // Acessa a página oficial do SauceDemo
        driver.Navigate().GoToUrl("https://www.saucedemo.com/");
    }

    [Test]
    public void DeveRealizarLoginComSucessoComUsuarioPadrao()
    {
        // Valida se o título da página contém a palavra "Swag Labs"
        Assert.That(driver.Title, Does.Contain("Swag Labs"));
    }

    [TearDown]
    public void TearDown()
    {
        // Fecha o navegador e descarta o objeto da memória corretamente
        if (driver != null)
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}