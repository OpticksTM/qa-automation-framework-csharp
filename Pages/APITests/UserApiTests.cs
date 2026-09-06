using NUnit.Framework;
using System.Net.Http;

namespace projeto_qa_csharp.APITests
{
    public class UserApiTests
    {
        private HttpClient _httpClient;

        [SetUp]
        public void Setup()
        {
            // Inicializa o cliente HTTP nativo apontando para a API de testes
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");
        }

        [Test]
        public void TesteAPI_ValidarRetornoUsuarioComSucesso()
        {
            // Act: Faz uma requisição GET para buscar o usuário de ID 1 na API
            HttpResponseMessage response = _httpClient.GetAsync("users/1").Result;

            // Assert 1: Valida se a requisição foi bem-sucedida e se o status code é 200 (OK)
            Assert.That(response.IsSuccessStatusCode, Is.True, "A requisição da API falhou.");
            Assert.That((int)response.StatusCode, Is.EqualTo(200), "O Status Code deveria ser 200.");

            // Act: Lê o corpo da resposta em formato JSON como string
            string jsonResponse = response.Content.ReadAsStringAsync().Result;

            // Assert 2: Valida se o payload JSON contém o dado esperado
            Assert.That(jsonResponse, Does.Contain("Leanne Graham"), "O corpo da resposta não contém o usuário esperado.");
        }

        [TearDown]
        public void TearDown()
        {
            // Libera os recursos de memória do HttpClient
            _httpClient.Dispose();
        }
    }
}