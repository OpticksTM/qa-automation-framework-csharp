# QA Automation Framework - C# (.NET)

[![C#](https://img.shields.io/badge/C%23-.NET-239120?style=for-the-badge&logo=csharp&logoColor=white)](https://dotnet.microsoft.com/)
[![Selenium](https://img.shields.io/badge/Selenium-43B02A?style=for-the-badge&logo=selenium&logoColor=white)](https://www.selenium.dev/)
[![SpecFlow](https://img.shields.io/badge/SpecFlow-8515C9?style=for-the-badge&logo=cucumber&logoColor=white)](https://specflow.org/)
[![PostgreSQL](https://img.shields.io/badge/PostgreSQL-316192?style=for-the-badge&logo=postgresql&logoColor=white)](https://www.postgresql.org/)
[![Docker](https://img.shields.io/badge/Docker-2CA5E0?style=for-the-badge&logo=docker&logoColor=white)](https://www.docker.com/)

Framework de testes automatizados desenvolvido em C# com uma abordagem híbrida de qualidade (**Full-Cycle QA**), cobrindo testes de interface de usuário (UI) e validação de serviços de API.

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

* **Camada de Interface (UI):** Valida os fluxos de ponta a ponta (End-to-End) do e-commerce simulado SauceDemo utilizando Selenium WebDriver estruturado sob o padrão Page Object Model (POM) para alta manutenibilidade.
* **Camada de Backend (API):** Valida contratos REST, códigos de status HTTP e payloads JSON utilizando o `HttpClient` nativo do .NET, assegurando a robustez dos serviços integrados.

---

## Estrutura do Repositório

```text
├── Pages/               # Mapeamento de elementos e ações (Page Object Model)
├── bin/                 # Arquivos binários de compilação
├── obj/                 # Objetos de compilação intermediários
├── LoginTests.cs        # Cenários de teste automatizados (UI / API / Sad Path)
└── projeto-qa-csharp.csproj # Arquivo de configuração e dependências do projeto .NET
