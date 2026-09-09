#language: pt
Funcionalidade: Login no SauceDemo
  Como um usuário do sistema
  Quero me autenticar na plataforma
  Para conseguir acessar o inventário de produtos

  Cenário: Realizar login com sucesso
    Dado que o cliente acessa a página de login do SauceDemo
    Quando preenche o usuário "standard_user" e a senha "secret_sauce"
    E clica no botão de login
    Então o sistema deve exibir a página de inventário de produtos