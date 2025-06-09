# AquaMind - Sistema de Irrigação Inteligente

## Sobre o Projeto

O **AquaMind** é um sistema inteligente de monitoramento e automação de irrigação para agricultura sustentável. A solução utiliza sensores IoT para monitorar a umidade do solo em tempo real e automatiza a irrigação, otimizando o uso da água e aumentando a eficiência agrícola.

## Problema Resolvido

- **Escassez de água**: Otimização do uso de recursos hídricos
- **Agricultura sustentável**: Irrigação inteligente baseada em dados
- **Monitoramento em tempo real**: Prevenção de perdas de safra
- **Automação agrícola**: Redução de mão de obra manual

## Tecnologias Utilizadas

- **.NET 9.0** - Framework principal
- **ASP.NET Core** - Web API
- **Entity Framework Core** - ORM
- **SQLite** - Banco de dados
- **Swagger/OpenAPI** - Documentação da API
- **Razor Pages** - Interface web
- **Bootstrap** - Framework CSS

## Arquitetura do Sistema

### Visão Geral da Arquitetura

```
┌─────────────────┐    ┌─────────────────┐    ┌─────────────────┐
│   Camada IoT    │    │  Camada API     │    │ Camada Dados    │
│                 │    │                 │    │                 │
│ ┌─────────────┐ │    │ ┌─────────────┐ │    │ ┌─────────────┐ │
│ │  Sensores   │ │───▶│ │ Controllers │ │───▶│ │   SQLite    │ │
│ │  Umidade    │ │    │ │  REST API   │ │    │ │  Database   │ │
│ └─────────────┘ │    │ └─────────────┘ │    │ └─────────────┘ │
│                 │    │        │        │    │                 │
│ ┌─────────────┐ │    │ ┌─────────────┐ │    │ ┌─────────────┐ │
│ │   Bombas    │ │◀───│ │  Business   │ │    │ │    Entity   │ │
│ │ Irrigação   │ │    │ │    Logic    │ │    │ │  Framework  │ │
│ └─────────────┘ │    │ └─────────────┘ │    │ └─────────────┘ │
└─────────────────┘    │        │        │    └─────────────────┘
                       │ ┌─────────────┐ │
                       │ │   Swagger   │ │
                       │ │     API     │ │
                       │ └─────────────┘ │
                       │        │        │
                       │ ┌─────────────┐ │
                       │ │   Razor     │ │
                       │ │    Pages    │ │
                       │ └─────────────┘ │
                       └─────────────────┘
```

### Arquitetura em Camadas

#### 1. **Camada de Apresentação**
```
Interface Web (Razor Pages)
         │
    Bootstrap + CSS
         │
    JavaScript + AJAX
```

#### 2. **Camada de API**
```
Controllers (REST Endpoints)
         │
    Business Logic
         │
    Data Transfer Objects (DTOs)
```

#### 3. **Camada de Dados**
```
Entity Framework Core
         │
    DbContext (AppDbContext)
         │
    SQLite Database
```

### Fluxo de Dados

```
1. Sensor IoT ──────────┐
                        ▼
2. HTTP Request ─────▶ API Controller
                        │
3. Business Logic ──────┼─────▶ Validation
                        │
4. Entity Framework ────┼─────▶ Database
                        │
5. Response Data ◀──────┘
                        │
6. JSON Response ◀──────┘
                        │
7. Interface Update ◀───┘
```

### Padrões de Arquitetura Implementados

#### **Repository Pattern (via Entity Framework)**
- `AppDbContext` atua como repository
- Abstração da camada de dados
- Facilita testes unitários

#### **MVC Pattern**
- **Model**: Entidades (Usuario, Sensor, Bomba)
- **View**: Razor Pages + JSON responses
- **Controller**: Controllers REST API

#### **RESTful API Pattern**
- Endpoints seguem convenções REST
- Verbos HTTP apropriados (GET, POST, PUT, DELETE)
- Status codes padronizados

#### **Dependency Injection**
```csharp
// Program.cs
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(connectionString));
```

## Estrutura do Banco de Dados

### Diagrama de Entidade-Relacionamento

```
┌─────────────────┐     ┌─────────────────┐     ┌─────────────────┐
│     ESTADO      │     │     USUARIO     │     │  PROPRIEDADE    │
│─────────────────│     │─────────────────│     │─────────────────│
│ Id (PK)         │     │ Id (PK)         │     │ Id (PK)         │
│ Nome            │────▶│ Nome            │────▶│ Nome            │
│ Sigla           │ 1:N │ Email           │ 1:N │ Endereco        │
│ Ativo           │     │ Telefone        │     │ Cidade          │
│ DataCriacao     │     │ Ativo           │     │ AreaTotal       │
└─────────────────┘     │ DataCriacao     │     │ UsuarioId (FK)  │
                        └─────────────────┘     │ EstadoId (FK)   │
                                                └─────────────────┘
                                                         │ 1:N
                                                         ▼
┌─────────────────┐     ┌─────────────────┐     ┌─────────────────┐
│    SENSOR       │     │      ZONA       │     │     BOMBA       │
│─────────────────│     │─────────────────│     │─────────────────│
│ Id (PK)         │◀────│ Id (PK)         │────▶│ Id (PK)         │
│ Nome            │ 1:N │ Nome            │ 1:N │ Nome            │
│ Tipo            │     │ Descricao       │     │ Modelo          │
│ Modelo          │     │ Area            │     │ Potencia        │
│ Ativo           │     │ TipoCultura     │     │ Ativa           │
│ ZonaId (FK)     │     │ PropriedadeId   │     │ Ligada          │
└─────────────────┘     └─────────────────┘     │ ZonaId (FK)     │
         │ 1:N                    │ 1:1          └─────────────────┘
         ▼                        ▼                       │ 1:N
┌─────────────────┐     ┌─────────────────┐              ▼
│ REGISTROSENSOR  │     │CONFIGURACAOZONA │     ┌─────────────────┐
│─────────────────│     │─────────────────│     │  LOGACAOBOMBA   │
│ Id (PK)         │     │ Id (PK)         │     │─────────────────│
│ Valor           │     │ UmidadeMinima   │     │ Id (PK)         │
│ Unidade         │     │ UmidadeMaxima   │     │ Acao            │
│ DataRegistro    │     │ TempoIrrigacao  │     │ Descricao       │
│ SensorId (FK)   │     │ ZonaId (FK)     │     │ DataAcao        │
└─────────────────┘     └─────────────────┘     │ BombaId (FK)    │
                                                └─────────────────┘
```

### Relacionamentos Implementados

#### **1:N (Um para Muitos)**
1. **Estado** ──(1:N)──▶ **Propriedade**
   - Um estado pode ter várias propriedades
   
2. **Usuario** ──(1:N)──▶ **Propriedade**
   - Um usuário pode possuir várias propriedades
   
3. **Propriedade** ──(1:N)──▶ **Zona**
   - Uma propriedade pode ter várias zonas
   
4. **Zona** ──(1:N)──▶ **Sensor**
   - Uma zona pode ter vários sensores
   
5. **Zona** ──(1:N)──▶ **Bomba**
   - Uma zona pode ter várias bombas
   
6. **Sensor** ──(1:N)──▶ **RegistroSensor**
   - Um sensor pode ter vários registros
   
7. **Bomba** ──(1:N)──▶ **LogAcaoBomba**
   - Uma bomba pode ter vários logs

#### **1:1 (Um para Um)**
8. **Zona** ──(1:1)──▶ **ConfiguracaoZona**
   - Uma zona tem uma configuração específica

## Instalação

### Pré-requisitos
- .NET 9.0 SDK
- Git

### Passos

1. **Clone o repositório**
```bash
git clone https://github.com/zrur/AquaMind.git
cd AquaMind/AquaMind.API
```

2. **Restaure as dependências**
```bash
dotnet restore
```

3. **Configure o banco de dados**
```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

4. **Execute a aplicação**
```bash
dotnet run
```

5. **Acesse a aplicação**
- Interface Web: https://localhost:5001/
- API Swagger: https://localhost:5001/swagger
- Zonas: https://localhost:5001/Zonas

## Endpoints da API

### Estados
- `GET /api/Estados` - Listar todos os estados
- `POST /api/Estados` - Criar novo estado
- `GET /api/Estados/{id}` - Buscar estado por ID
- `PUT /api/Estados/{id}` - Atualizar estado
- `DELETE /api/Estados/{id}` - Deletar estado

### Usuários
- `GET /api/Usuarios` - Listar todos os usuários
- `POST /api/Usuarios` - Criar novo usuário
- `GET /api/Usuarios/{id}` - Buscar usuário por ID
- `PUT /api/Usuarios/{id}` - Atualizar usuário
- `DELETE /api/Usuarios/{id}` - Deletar usuário

### Propriedades
- `GET /api/Propriedades` - Listar todas as propriedades
- `POST /api/Propriedades` - Criar nova propriedade
- `GET /api/Propriedades/{id}` - Buscar propriedade por ID
- `PUT /api/Propriedades/{id}` - Atualizar propriedade
- `DELETE /api/Propriedades/{id}` - Deletar propriedade

### Zonas
- `GET /api/Zonas` - Listar todas as zonas
- `POST /api/Zonas` - Criar nova zona
- `GET /api/Zonas/{id}` - Buscar zona por ID
- `PUT /api/Zonas/{id}` - Atualizar zona
- `DELETE /api/Zonas/{id}` - Deletar zona

### Sensores
- `GET /api/Sensores` - Listar todos os sensores
- `POST /api/Sensores` - Criar novo sensor
- `GET /api/Sensores/{id}` - Buscar sensor por ID
- `PUT /api/Sensores/{id}` - Atualizar sensor
- `DELETE /api/Sensores/{id}` - Deletar sensor

### Bombas
- `GET /api/Bombas` - Listar todas as bombas
- `POST /api/Bombas` - Criar nova bomba
- `GET /api/Bombas/{id}` - Buscar bomba por ID
- `PUT /api/Bombas/{id}` - Atualizar bomba
- `DELETE /api/Bombas/{id}` - Deletar bomba

## Exemplos de Uso

### Criar um Estado
```bash
curl -X POST "https://localhost:5001/api/Estados" \
     -H "Content-Type: application/json" \
     -d '{
       "nome": "São Paulo",
       "sigla": "SP",
       "ativo": true
     }'
```

### Criar um Usuário
```bash
curl -X POST "https://localhost:5001/api/Usuarios" \
     -H "Content-Type: application/json" \
     -d '{
       "nome": "João Silva",
       "email": "joao@aquamind.com",
       "telefone": "(11) 99999-9999",
       "ativo": true
     }'
```

### Criar uma Propriedade
```bash
curl -X POST "https://localhost:5001/api/Propriedades" \
     -H "Content-Type: application/json" \
     -d '{
       "nome": "Fazenda São José",
       "endereco": "Rua das Plantas, 123",
       "cidade": "Campinas",
       "areaTotal": 1000.50,
       "ativa": true,
       "usuarioId": 1,
       "estadoId": 1
     }'
```

### Criar uma Zona
```bash
curl -X POST "https://localhost:5001/api/Zonas" \
     -H "Content-Type: application/json" \
     -d '{
       "nome": "Zona Norte",
       "descricao": "Área de plantio de tomates",
       "area": 250.75,
       "tipoCultura": "Tomate",
       "ativa": true,
       "propriedadeId": 1
     }'
```

### Criar um Sensor
```bash
curl -X POST "https://localhost:5001/api/Sensores" \
     -H "Content-Type: application/json" \
     -d '{
       "nome": "Sensor Umidade 01",
       "tipo": "Umidade do Solo",
       "modelo": "DHT22",
       "ativo": true,
       "zonaId": 1
     }'
```

### Criar uma Bomba
```bash
curl -X POST "https://localhost:5001/api/Bombas" \
     -H "Content-Type: application/json" \
     -d '{
       "nome": "Bomba Principal",
       "modelo": "Bomba 1000L/h",
       "potencia": 2.5,
       "ativa": true,
       "ligada": false,
       "zonaId": 1
     }'
```

## Testes

### Teste via Swagger
1. Acesse: https://localhost:5182/swagger
2. Escolha um endpoint
3. Clique em "Try it out"
4. Preencha os dados
5. Execute e verifique a resposta

### Teste via Interface Web
1. Acesse: https://localhost:5182/
2. Navegue para "Zonas"
3. Verifique a listagem

### Popular com Dados de Teste
Execute o script de população (se disponível):
```bash
./populate_database.sh
```

## Funcionalidades

- **Monitoramento em tempo real** de sensores de umidade
- **Automação de bombas** de irrigação
- **Gestão de múltiplas propriedades** e zonas
- **Histórico de registros** de sensores
- **Sistema de alertas** de umidade
- **Interface web responsiva**
- **API REST completa** com documentação Swagger

## Requisitos Atendidos

### Global Solution Requirements
- ✅ **API REST** com boas práticas
- ✅ **Banco de dados relacional** (SQLite)
- ✅ **Relacionamentos 1:N** implementados
- ✅ **Documentação Swagger** funcionando
- ✅ **Razor Pages e TagHelpers** implementados
- ✅ **Migrations** configuradas corretamente

## Estrutura do Projeto

```
AquaMind.API/
├── 📁 Controllers/              # 🎯 Camada de Apresentação (API)
│   ├── EstadosController.cs     #    Endpoints REST para Estados
│   ├── UsuariosController.cs    #    Endpoints REST para Usuários
│   ├── PropriedadesController.cs#    Endpoints REST para Propriedades
│   ├── ZonasController.cs       #    Endpoints REST para Zonas
│   ├── SensoresController.cs    #    Endpoints REST para Sensores
│   ├── BombasController.cs      #    Endpoints REST para Bombas
│   └── ...                     #    Outros controllers
│
├── 📁 Data/                     # 🗄️ Camada de Dados
│   ├── AppDbContext.cs          #    Contexto do Entity Framework
│   └── AppDbContextFactory.cs  #    Factory para migrations
│
├── 📁 Models/                   # 🏗️ Camada de Domínio
│   ├── Usuario.cs               #    Entidade Usuário
│   ├── Propriedade.cs           #    Entidade Propriedade
│   ├── Zona.cs                  #    Entidade Zona
│   ├── Sensor.cs                #    Entidade Sensor
│   ├── Bomba.cs                 #    Entidade Bomba
│   └── ...                     #    Outras entidades
│
├── 📁 Pages/                    # 🌐 Interface Web (Razor)
│   ├── Index.cshtml             #    Página inicial
│   ├── Index.cshtml.cs          #    CodeBehind da página inicial
│   ├── 📁 Zonas/                #    Páginas específicas de Zonas
│   │   ├── Index.cshtml         #    Lista de zonas
│   │   └── Index.cshtml.cs      #    Logic para lista de zonas
│   └── 📁 Shared/               #    Componentes compartilhados
│       └── _Layout.cshtml       #    Layout principal
│
├── 📁 wwwroot/                  # 📦 Arquivos Estáticos
│   ├── 📁 css/                  #    Estilos CSS
│   │   └── site.css             #    CSS customizado
│   ├── 📁 js/                   #    JavaScript
│   │   └── site.js              #    JS customizado
│   └── 📁 lib/                  #    Bibliotecas externas
│       ├── bootstrap/           #    Framework Bootstrap
│       └── jquery/              #    jQuery
│
├── 📄 Program.cs                # ⚙️ Configuração da Aplicação
├── 📄 appsettings.json          # 🔧 Configurações de Produção
├── 📄 appsettings.Development.json # 🔧 Configurações de Desenvolvimento
├── 📄 AquaMind.API.csproj       # 📋 Configuração do Projeto
└── 📄 GlobalUsings.cs           # 📚 Using statements globais
```

### Responsabilidades por Camada

#### **Controllers** (Camada de Apresentação)
- Recebem requisições HTTP
- Validam dados de entrada
- Chamam a lógica de negócio
- Retornam respostas HTTP

#### **Models** (Camada de Domínio)
- Definem as entidades do negócio
- Contêm as regras de validação
- Representam a estrutura do banco

#### **Data** (Camada de Persistência)
- Gerenciam a conexão com o banco
- Realizam operações CRUD
- Mapeiam objetos para tabelas

#### **Pages** (Interface Web)
- Fornecem interface visual
- Consomem a API REST
- Apresentam dados ao usuário

## Benefícios

- **Economia de água**: Até 40% de redução
- **Aumento da produtividade**: Irrigação otimizada
- **Sustentabilidade**: Agricultura inteligente
- **Automação**: Redução de mão de obra

## Contato

- **Desenvolvedores**: Arthur, Robert, Marcos Ramalho
- **GitHub**: [@zrur](https://github.com/zrur)
- **Repositório**: [AquaMind](https://github.com/zrur/AquaMind)

## Licença

MIT License - veja LICENSE para detalhes.
