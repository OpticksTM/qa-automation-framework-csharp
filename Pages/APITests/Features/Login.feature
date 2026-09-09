# language: pt
Funcionalidade: Login no SauceDemo
  Como um usuário do e-commerce SauceDemo
  Quero realizar o login no sistema
  Para que eu possa acessar a página de produtos

  Cenário: Login com sucesso (Happy Path)
    Dado que estou na página de login do SauceDemo
    Quando preencho o usuário "standard_user" e a senha "secret_sauce"
    E clico no botão de login
    Então sou redirecionado para a página de inventário de produtos