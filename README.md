# Desafio Técnico - Target Sistemas

Este repositório contém a resolução do desafio técnico de programação da **Target Sistemas**. A aplicação foi desenvolvida em **.NET 10 (Console Application)** em C# e resolve três problemas práticos comumente encontrados no dia a dia do desenvolvimento: cálculo de comissões, movimentação de estoque de produtos e cálculo de juros/multas sobre vencimentos.

---

## 🛠️ Tecnologias Utilizadas

*   **Linguagem:** C# (C# 13)
*   **Plataforma:** **.NET 10.0**
*   **Formato de Dados:** JSON (System.Text.Json) para leitura e escrita de dados

---

## 📁 Estrutura do Projeto e Correlação (Word vs Código)

Abaixo está o mapeamento de pastas do arquivo compactado e como cada arquivo C# resolve uma seção específica descrita no documento do desafio (Word):

```bash
Teste-Target-Systemas-Jr/
│
├── bin/Debug/net10.0/             # Ambiente de execução compilado
│   ├── estoque.json               # Dados base de produtos (Item 2 do Word)
│   └── vendas.json                # Dados base de vendas (Item 1 do Word)
│
├── v18/                           # Pastas de cache e metadados do Visual Studio
│
├── Teste-Target-Systemas-Jr.slnx  # Arquivo de solução moderno do VS 2022
├── Teste-Target-Systemas-Jr.csproj# Configuração do projeto (.NET 10)
├── Program.cs                     # Menu interativo principal que orquestra o Desafio
│
# =========================================================================
# CORRELAÇÃO DIRETA COM AS QUESTÕES DO DESAFIO (Word)
# =========================================================================
│
├── Vendas.cs                      # Classe de modelo para desserialização do JSON de Vendas
├── TesteComissao.cs               # Classe de suporte para execução dos testes de comissão
├── CalculaComissao.cs             # [QUESTÃO 1] Regras de negócio e cálculo de comissões (1% e 5%)
│
├── Estoque.cs                     # [QUESTÃO 2] Regras de negócio, Entradas/Saídas e IDs únicos de estoque
├── estoque.json                   # Arquivo JSON com os itens do depósito (Caneta, Caderno, etc.)
│
└── CalculoDeJuros.cs              # [QUESTÃO 3] Lógica de cálculo de juros diários acumulados (2,5% ao dia)
```

---

## 🚀 Detalhamento das Soluções

### 📊 Questão 1: Cálculo de Comissão do Time Comercial
*   **O Problema (Word):** Ler um JSON com registros de vendas de vendedores (`João Silva`, `Maria Souza`, etc.) e calcular a comissão com base em faixas de valores:
    *   Abaixo de R$ 100,00: **Sem comissão**
    *   Abaixo de R$ 500,00: **1% de comissão**
    *   A partir de R$ 500,00: **5% de comissão**
*   **A Solução (Código):** Implementada no arquivo `CalculaComissao.cs`. O programa faz o parse do arquivo `vendas.json`, agrupa as vendas por funcionário, aplica as estruturas condicionais para cada faixa e exibe o fechamento consolidado da comissão de cada vendedor na tela.

### 📦 Questão 2: Controle e Movimentação de Estoque
*   **O Problema (Word):** Criar um sistema para lançar entradas ou saídas de mercadorias a partir de um inventário inicial em JSON. Cada movimentação precisa gerar um **ID único**, ter uma **descrição do tipo de operação** e retornar o **saldo final em estoque**.
*   **A Solução (Código):** Implementada no arquivo `Estoque.cs`. Utiliza o arquivo `estoque.json` como banco de dados simulado. O sistema valida se há saldo suficiente antes de aprovar saídas, atualiza a quantidade em memória, gera chaves únicas incrementais para a auditoria e grava o novo estado final no arquivo de disco.

### 📅 Questão 3: Cálculo de Juros com Multa Diária
*   **O Problema (Word):** A partir de um valor de boleto/título e uma data de vencimento retroativa, calcular o valor total devido na data atual (hoje), aplicando uma multa/juros de **2,5% ao dia** de atraso.
*   **A Solução (Código):** Implementada no arquivo `CalculoDeJuros.cs`. Utiliza a estrutura `DateTime.Today` para capturar a data atual do sistema de forma dinâmica, calcula o intervalo de dias decorridos utilizando operações de `TimeSpan` e aplica a taxa cumulativa sobre o montante inicial.

---

## ⚡ Como Executar o Projeto

1. Certifique-se de ter o **SDK do .NET 10** instalado em seu computador.
2. Extraia os arquivos e navegue até a pasta raiz do projeto onde está o arquivo de solução:
   ```bash
   cd Teste-Target-Systemas-Jr
   ```
3. Execute a aplicação através do terminal do .NET:
   ```bash
   dotnet run
   ```
4. Um menu interativo no console será exibido para que você possa escolher qual das 3 questões do desafio deseja testar e visualizar os outputs.
