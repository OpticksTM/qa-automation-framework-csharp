using OpenQA.Selenium;

namespace projeto_qa_csharp.Pages
{
    public class LoginPage
    {
        private readonly IWebDriver _driver;

        private IWebElement UsernameField => _driver.FindElement(By.Id("user-name")); // Mapeia o campo de usuário     [Elemento UI]
        private IWebElement PasswordField => _driver.FindElement(By.Id("password")); // Mapeia o campo de senha       [Elemento UI]
        private IWebElement LoginButton => _driver.FindElement(By.Id("login-button"));  // Mapeia o botão de login       [Elemento UI]
        private IWebElement ErrorMessage => _driver.FindElement(By.XPath("//h3[@data-test='error']")); // Mapeia o erro [Elemento UI]

        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
        }

        // Renomeado para FazerLogin para padronizar com a chamada do teste   [Ação]
        public void FazerLogin(string usuario, string senha)
        {
            UsernameField.SendKeys(usuario);
            PasswordField.SendKeys(senha);
            LoginButton.Click();
        }

        public string ObterMensagemErro()                                        // Retorna o texto do erro       [Leitura]
        {
            return ErrorMessage.Text;
        }
    }
}