# QA Automation Framework - C# (.NET)

Framework de testes automatizados desenvolvido em C# com uma abordagem híbrida de qualidade (Full-Cycle QA), cobrindo testes de interface de usuário (UI) guiados por comportamento (BDD) e validação de serviços de API.

## Tecnologias e Ferramentas Utilizadas

* **Linguagem:** C# (.NET)
* **Automação UI:** Selenium WebDriver
* **Padrão de Projeto:** Page Object Model (POM)
* **Desenvolvimento Guiado por Comportamento (BDD):** SpecFlow (Gherkin)
* **Testes Unitários/Funcionais:** NUnit
* **Testes de API:** HttpClient nativo do .NET (.NET REST Client)
* **Gerenciamento e Versionamento:** Git e GitHub

## Arquitetura do Framework

O projeto adota uma arquitetura limpa e estruturada para garantir alta manutenibilidade e legibilidade de negócio:
* **Camada BDD (Features & Steps):** Traduz os cenários de negócio em linguagem natural (Gherkin) para código de automação executável cobrindo o e-commerce SauceDemo.
* **Camada de Interface (Pages - POM):** Centraliza o mapeamento de elementos e ações de tela, isolando a lógica de automação da camada de teste.
* **Camada de Backend (API):** Valida contratos REST, códigos de status HTTP e payloads JSON.

## Estrutura do Repositório

```text
├── Features/                # Cenários de comportamento em linguagem natural (Gherkin)
├── Pages/                   # Mapeamento de elementos e ações (Page Object Model)
├── Steps/                   # Implementação dos passos BDD (Glue Code)
├── Tests/                   # Testes funcionais estruturados em NUnit
├── .gitignore               # Arquivos e pastas ignoradas pelo controle de versão
├── README.md                # Documentação do projeto
└── projeto-qa-csharp.csproj # Configuração e dependências do projeto .NET
