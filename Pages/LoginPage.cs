using OpenQA.Selenium;

namespace projeto_qa_csharp.Pages
{
    public class LoginPage
    {
        private readonly IWebDriver _driver;

        // Mapeamento dos elementos da tela (Locators)
        private IWebElement UsernameField => _driver.FindElement(By.Id("user-name"));
        private IWebElement PasswordField => _driver.FindElement(By.Id("password"));
        private IWebElement LoginButton => _driver.FindElement(By.Id("login-button"));

        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
        }

        // Ações encapsuladas da página
        public void PreencherUsuario(string usuario)
        {
            UsernameField.SendKeys(usuario);
        }

        public void PreencherSenha(string senha)
        {
            PasswordField.SendKeys(senha);
        }

        public void ClicarNoBotaoLogin()
        {
            LoginButton.Click();
        }

        // Método agregador para facilitar o fluxo de login
        public void FazerLogin(string usuario, string senha)
        {
            PreencherUsuario(usuario);
            PreencherSenha(senha);
            ClicarNoBotaoLogin();
        }
    }
}