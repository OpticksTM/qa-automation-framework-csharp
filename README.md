# QA Automation Framework - C# (.NET)

Framework de testes automatizados desenvolvido em C# com uma abordagem híbrida de qualidade (Full-Cycle QA), cobrindo testes de interface de usuário (UI) e validação de serviços de API.

---

## Tecnologias e Ferramentas Utilizadas

* **Linguagem:** C# (.NET)
* **Automação UI:** Selenium WebDriver
* **Padrão de Projeto:** Page Object Model (POM)
* **Desenvolvimento Guiado por Comportamento:** SpecFlow (BDD)
* **Testes de API:** HttpClient nativo do .NET (.NET REST Client)
* **Banco de Dados / Massa de Dados:** PostgreSQL (via Docker) + Npgsql
* **Gerenciamento e Versionamento:** Git e GitHub

---

## Arquitetura do Framework

O projeto adota uma abordagem híbrida de automação para garantir cobertura completa de ponta a ponta:
1. **Camada de Interface (UI):** Valida os fluxos de ponta a ponta (End-to-End) do e-commerce simulado [SauceDemo](https://www.saucedemo.com/) utilizando Selenium WebDriver estruturado sob o padrão Page Object Model (POM) para alta manutenibilidade.
2. **Camada de Backend (API):** Valida contratos REST, códigos de status HTTP e payloads JSON utilizando o HttpClient nativo do .NET, assegurando a robustez dos serviços integrados.

---

## Estrutura do Repositório

```text
├── Pages/               # Mapeamento de elementos e ações (Page Object Model)
├── bin/                 # Arquivos binários de compilação
├── obj/                 # Objetos de compilação intermediários
├── LoginTests.cs        # Cenários de teste automatizados (UI / API / Sad Path)
└── projeto-qa-csharp.csproj # Arquivo de configuração e dependências do projeto .NET
