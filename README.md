# Backend API - WebLocalize

## Descrição do Projeto
O **Backend API - WebLocalize** é uma aplicação desenvolvida para gerenciar informações de estados, cidades e locais, com suporte a operações CRUD e regras de negócio específicas, como "soft delete". O projeto segue os princípios de Domain-Driven Design (DDD) e utiliza tecnologias modernas para garantir escalabilidade e manutenibilidade.

## Tecnologias Utilizadas
- **.NET 10**: Framework principal para desenvolvimento do backend.
- **Entity Framework Core**: ORM para gerenciamento do banco de dados.
- **SQL Server**: Banco de dados relacional utilizado para persistência de dados.
- **Swagger**: Documentação interativa da API.
- **C#**: Linguagem de programação utilizada no desenvolvimento.

## Estrutura do Projeto
O projeto segue a arquitetura DDD (Domain-Driven Design) e está dividido nos seguintes contextos:
- **DDD.Application**: Contém a lógica de aplicação.
- **DDD.Domain**: Define as entidades e regras de negócio.
- **DDD.Infrastructure**: Gerencia a persistência de dados e configurações do banco.
- **DDD.Presentation**: Contém os controladores e serviços expostos pela API.
- **DDD.Tests**: Testes unitários e de integração.

## Dados Iniciais do Banco de Dados
Ao criar o banco de dados, os seguintes dados são inseridos automaticamente:

### Estados
| Nome          | Sigla |
|---------------|-------|
| São Paulo     | SP    |
| Rio de Janeiro| RJ    |
| Minas Gerais  | MG    |
| Bahia         | BA    |
| Paraná        | PR    |

### Cidades
| Nome             | Estado         |
|------------------|----------------|
| São Paulo        | São Paulo (SP) |
| Rio de Janeiro   | Rio de Janeiro (RJ) |
| Belo Horizonte   | Minas Gerais (MG) |
| Salvador         | Bahia (BA) |
| Curitiba         | Paraná (PR) |

### Locais
| Nome               | Descrição                                                                 | Endereço                                      | Cidade          | Estado         |
|--------------------|---------------------------------------------------------------------------|----------------------------------------------|-----------------|----------------|
| Parque Ibirapuera  | O mais importante parque urbano de São Paulo, com museus e planetário.   | Av. Pedro Álvares Cabral - Vila Mariana      | São Paulo       | São Paulo (SP) |
| Cristo Redentor    | Famosa estátua Art Déco de Jesus Cristo no topo do morro do Corcovado.   | Parque Nacional da Tijuca - Alto da Boa Vista| Rio de Janeiro  | Rio de Janeiro (RJ) |
| Praça da Liberdade | Importante conjunto arquitetônico e histórico, cercado por museus.       | Praça da Liberdade, s/n - Savassi            | Belo Horizonte  | Minas Gerais (MG) |
| Pelourinho         | Centro histórico com arquitetura colonial barroca portuguesa preservada. | Largo do Pelourinho, s/n - Centro Histórico  | Salvador        | Bahia (BA)     |
| Jardim Botânico    | Principal cartão-postal da cidade, famoso por sua estufa de vidro.       | Rua Eng°. Ostoja Roguski, 690 - Jardim Botânico | Curitiba        | Paraná (PR)    |

## Como Executar o Projeto
1. Clone o repositório:
   ```bash
   git clone https://github.com/FelpaGava/Backend_API_Weblocalize.git
   ```
2. Navegue até o diretório do projeto:
   ```bash
   cd Backend_API_Weblocalize
   ```
3. Restaure as dependências:
   ```bash
   dotnet restore
   ```
4. Execute as migrações para criar o banco de dados:
   ```bash
   dotnet ef database update --project DDD.Infrastructure --startup-project DDD.Presentation
   ```
5. Inicie o servidor:
   ```bash
   dotnet run --project DDD.Presentation
   ```
6. Acesse a documentação da API no navegador:
   ```
   http://localhost:5229/swagger
   ```

## Regras de Negócio
- **Tabelas com nomes padronizados**: Seguindo boas práticas de nomenclatura para facilitar a manutenção.
- **Tabelas relacionais**: Estrutura do banco de dados projetada para garantir integridade referencial.
- **Modelo de não exclusão de dados**: Utilização de "soft delete" para melhor rastreabilidade e histórico de alterações.
- **(IMPLEMENTAÇÃO FUTURA) Intenção de implementar uma tabela de parâmetros**: Planejamento para armazenar configurações dinâmicas no banco de dados, evitando dados fixos no front-end.

## Contato

Para dúvidas ou sugestões, entre em contato pelo [LinkedIn](www.linkedin.com/in/marcos-felipe-gava-093910263) ou [GitHub](https://github.com/FelpaGava).