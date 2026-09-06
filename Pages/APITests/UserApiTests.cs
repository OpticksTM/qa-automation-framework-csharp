using NUnit.Framework;
using System.Net.Http;
using System.Threading.Tasks;
using System;

[TestFixture]
public class UserApiTests
{
    [Test]
    public async Task DeveRetornarNotFoundAoBuscarPostInexistente()
    {
        // Arrange (Configuração do cliente HTTP e do cenário com um ID inválido)
        var client = new HttpClient();
        client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");
        int idInexistente = 9999;

        // Act (Execução da requisição GET para um recurso que não existe)
        HttpResponseMessage response = await client.GetAsync($"posts/{idInexistente}");

        // Assert (Validação se o status code retornado é 404 - Not Found)
        Assert.That((int)response.StatusCode, Is.EqualTo(404), "A API deveria retornar 404 para um post inexistente.");
    }
}