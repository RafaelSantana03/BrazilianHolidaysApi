# 🇧🇷 Brazilian Holidays API

API REST desenvolvida em **ASP.NET Core** para consulta de feriados nacionais e estaduais do Brasil, com dados de 2026 a 2031.

---

## 🚀 Tecnologias

- [.NET 8](https://dotnet.microsoft.com/)
- [ASP.NET Core Web API](https://learn.microsoft.com/aspnet/core)
- [Entity Framework Core](https://learn.microsoft.com/ef/core/)
- [SQLite](https://www.sqlite.org/)
- [Swagger / Swashbuckle](https://swagger.io/)

---

## 📁 Estrutura do Projeto

```
BrazilianHolidaysApi/
├── Controllers/        # Endpoints da API
├── Data/
│   ├── Context/        # AppDbContext (EF Core)
│   └── Seed/           # Dados iniciais do banco
├── Enums/              # TipoFeriado (Nacional, Estadual, Municipal, PontoFacultativo)
├── Exceptions/         # NegocioException (erros de regra de negócio)
├── Interfaces/         # Contratos de Service e Repository
├── Migrations/         # Migrations do EF Core
├── Models/             # Entidade Feriado e FeriadoDto
├── Repositories/       # Acesso ao banco de dados
└── Services/           # Regras de negócio
```

---

## ⚙️ Como rodar localmente

### Pré-requisitos
- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- Visual Studio 2022 ou VS Code

### Passos

```bash
# Clone o repositório
git clone https://github.com/RafaelSantana03/BrazilianHolidaysApi.git

# Acesse a pasta do projeto
cd BrazilianHolidaysApi

# Restaure os pacotes
dotnet restore

# Rode a aplicação
dotnet run
```

> O banco de dados SQLite é criado e populado automaticamente na primeira execução.

Acesse a documentação interativa em:
```
https://localhost:7016/swagger
```

---

## 📡 Endpoints

### ✅ Feriados Nacionais por Ano

```http
GET /v1/feriados/{ano}/nacionais
```

**Exemplo:** `GET /v1/feriados/2026/nacionais`

**Resposta 200:**
```json
[
  {
    "nome": "Ano Novo",
    "data": "2026-01-01",
    "tipo": "Nacional",
    "uf": null,
    "descricao": "Confraternização Universal"
  },
  {
    "nome": "Tiradentes",
    "data": "2026-04-21",
    "tipo": "Nacional",
    "uf": null,
    "descricao": "Dia de Tiradentes"
  }
]
```

---

### ✅ Feriados por Estado e Ano

```http
GET /v1/feriados/{ano}/estado/{uf}
```

**Exemplo:** `GET /v1/feriados/2026/estado/SP`

Retorna os feriados **nacionais + estaduais** do estado informado.

**Resposta 200:**
```json
[
  {
    "nome": "Ano Novo",
    "data": "2026-01-01",
    "tipo": "Nacional",
    "uf": null,
    "descricao": "Confraternização Universal"
  },
  {
    "nome": "Aniversário de São Paulo",
    "data": "2026-01-25",
    "tipo": "Estadual",
    "uf": "SP",
    "descricao": null
  },
  {
    "nome": "Revolução Constitucionalista",
    "data": "2026-07-09",
    "tipo": "Estadual",
    "uf": "SP",
    "descricao": null
  }
]
```

---

### ✅ Próximo Feriado

```http
GET /v1/feriados/proximo
```

Retorna o próximo feriado nacional a partir da data atual.

**Resposta 200:**
```json
{
  "nome": "Dia do Trabalho",
  "data": "2026-05-01",
  "tipo": "Nacional",
  "uf": null,
  "descricao": "Dia Internacional do Trabalho"
}
```

---

## ❌ Validações e Erros

| Situação | Status | Mensagem |
|---|---|---|
| Ano igual a zero ou negativo | 400 | `Ano inválido.` |
| Ano fora do intervalo disponível | 400 | `Ano fora do intervalo disponível. Consulte entre 2026 e 2031.` |
| UF com mais ou menos de 2 letras | 400 | `UF inválida. Deve conter 2 letras.` |
| UF inexistente (ex: XX) | 400 | `UF 'XX' não encontrada. Verifique se a sigla está correta.` |
| Nenhum feriado próximo encontrado | 404 | `Nenhum feriado encontrado.` |

---

## 🏗️ Arquitetura

O projeto segue uma arquitetura em camadas com separação de responsabilidades:

```
Controller  →  valida o formato do input (UF, ano)
    ↓
Service     →  aplica as regras de negócio (range de ano, UF existente)
    ↓
Repository  →  consulta o banco de dados via EF Core
```

Princípios aplicados:
- **SOLID** — especialmente Dependency Inversion (interfaces) e Single Responsibility
- **Clean Code** — nomenclatura clara, métodos pequenos e coesos
- **DRY** — validação de ano centralizada em `ValidarAno()`

---

## 👤 Autor

**Rafael Santana**

[![LinkedIn](https://img.shields.io/badge/LinkedIn-0077B5?style=for-the-badge&logo=linkedin&logoColor=white)](https://www.linkedin.com/in/rafael-santana-42a810311/)
[![GitHub](https://img.shields.io/badge/GitHub-100000?style=for-the-badge&logo=github&logoColor=white)](https://github.com/RafaelSantana03)
