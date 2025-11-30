# DDD API (.NET 8, SQL Server)

## Descrição
API RESTful desenvolvida em .NET com arquitetura DDD, Entity Framework Core e SQL Server. Permite gerenciar Estados, Cidades e Locais turísticos, com campos de situação e seed automático de dados.

## Estrutura do Projeto
- **DDD.Domain**: Entidades de domínio
- **DDD.Application**: Lógica de aplicação
- **DDD.Infrastructure**: Persistência, DbContext, Seed
- **DDD.Presentation**: API, Controllers, Swagger
- **DDD.Tests**: Testes automatizados

## Como Utilizar

### 1. Pré-requisitos
- .NET 8 SDK
- .NET 10 SDK
- SQL Server
- VS Code ou outro editor

### 2. Configuração
- Edite a string de conexão em `appsettings.json` do projeto DDD.Presentation:
  ```json
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=webLocalize;User Id=usuario;Password=senha;TrustServerCertificate=True;"
  }
  ```

### 3. Criação do Banco de Dados
Execute os comandos abaixo no terminal na pasta raiz do projeto:

```powershell
dotnet ef database update --project DDD.Infrastructure --startup-project DDD.Presentation
```

### 4. Executando a API
```powershell
dotnet run --project DDD.Presentation
```

### 5. Seed de Dados
Ao iniciar a aplicação, 5 registros de cada entidade são inseridos automaticamente se as tabelas estiverem vazias.

## Observações
- Sempre rode as migrations após alterações no modelo.
- O seed só insere dados se as tabelas estiverem vazias.
- Para reiniciar do zero, apague o banco, rode o update e execute a aplicação.

## Contato
Autor: [Marcos Felipe Gava da Cruz]
Contato: [marcosfelipegava@gmail.com]
LinkedIn: [(https://www.linkedin.com/in/marcos-felipe-gava-093910263/)]
