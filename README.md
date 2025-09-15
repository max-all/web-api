# Web API de Estudos (.NET + Docker + SQL Server)

Este projeto é uma **Web API ASP.NET Core** criada para fins de estudo.  
O objetivo é demonstrar boas práticas no desenvolvimento de APIs, com **Entity Framework Core**, **SQL Server** em **Docker** e configuração de ambiente de desenvolvimento simplificada.

---

## 🚀 Tecnologias

- [.NET](https://dotnet.microsoft.com/)
- [ASP.NET Core Web API](https://learn.microsoft.com/aspnet/core/web-api)
- [Entity Framework Core](https://learn.microsoft.com/ef/core/)
- [SQL Server 2022](https://hub.docker.com/_/microsoft-mssql-server)
- [Docker Compose](https://docs.docker.com/compose/)

---

## 📦 Pré-requisitos

Antes de iniciar, você precisa ter instalado:

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- [Docker Desktop](https://www.docker.com/products/docker-desktop)
- (Opcional) [Azure Data Studio](https://azure.microsoft.com/en-us/products/data-studio) ou [SQL Server Management Studio](https://aka.ms/ssmsfullsetup) para gerenciar o banco.

---

## ⚙️ Configuração do ambiente

### 1. Clonar o repositório
```bash
git clone https://github.com/max-all/web-api.git
cd web-api
```

### 2. Validar a connection string
No arquivo `appsettings.Development.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost,1433;Database=WebApiDb;User Id=sa;Password=Webapi123;TrustServerCertificate=True;"
  }
}
```

---

## ▶️ Como rodar o projeto

### Opção 1: Usando os perfis do Visual Studio/VS Code
- **DockerUp** → sobe o SQL Server no Docker.  
- **https** → roda a Web API com Swagger em `https://localhost:7116`.  
- **DockerDown** → derruba os containers (mantém dados).  
- **DockerDownReset** → derruba containers e apaga volumes (zera o banco).  

### Opção 2: Via CLI
```bash
# Sobe o banco no Docker
docker-compose up -d

# Roda a API (com hot reload)
dotnet watch run --project web-Api
```

Ao encerrar:
```bash
# Derruba containers (mantém dados)
docker-compose down

# Derruba containers e apaga volumes (zera banco)
docker-compose down -v
```

---

## 🗄️ Migrations e banco de dados

- Em **Development**, as migrations são aplicadas automaticamente quando a API sobe.  
- Caso queira rodar manualmente:
```bash
dotnet ef migrations add InitialCreate -p web-Api
dotnet ef database update -p web-Api
```

---

## 📚 Documentação da API

Com a aplicação rodando, abra no navegador:

- Swagger UI:  
  [https://localhost:7116/swagger](https://localhost:7116/swagger)

Aqui você pode explorar e testar os endpoints.

---

## 🧹 Scripts úteis

- `DockerUp` → `docker-compose up -d`
- `DockerDown` → `docker-compose down`
- `DockerDownReset` → `docker-compose down -v`
- `dotnet watch run` → roda a API em modo desenvolvimento (hot reload)

---

## 🎯 Objetivo do projeto

Este repositório serve como base de estudo para:
- Criar e documentar APIs em ASP.NET Core.  
- Gerenciar ambiente de desenvolvimento com Docker.  
- Usar boas práticas (migration automática, Swagger, perfis de execução).  

## 🧹 Em Construcao

- Validar nas Issues