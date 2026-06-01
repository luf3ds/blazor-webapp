# 🛡️ RPG Shop

Sistema web desenvolvido em ASP.NET Core Blazor Server para gerenciamento de vendas de itens de RPG, utilizando PostgreSQL hospedado no Supabase.

## 📋 Sobre o Projeto

O RPG Shop é uma aplicação destinada ao controle de vendas de itens de RPG, permitindo o gerenciamento de clientes, produtos e vendas através de uma interface web desenvolvida com Blazor Server.

O sistema utiliza:

- ASP.NET Core 6
- Blazor Server
- PostgreSQL
- Supabase
- Npgsql

---

## 🚀 Tecnologias Utilizadas

| Tecnologia | Descrição |
|------------|------------|
| .NET 6 | Framework principal |
| Blazor Server | Interface Web |
| PostgreSQL | Banco de Dados |
| Supabase | Hospedagem do Banco |
| Npgsql | Driver PostgreSQL para .NET |

---

## 📂 Estrutura do Projeto

```text
RpgShop/
│
├── DAO/
│   ├── Database.cs
│   └── VendaDAO.cs
│
├── Models/
│   └── Venda.cs
│
├── Pages/
│
├── App.razor
├── Program.cs
├── appsettings.json
└── appsettings.Development.json
```

---

## ⚙️ Funcionalidades

### Clientes

- Cadastro de clientes
- Consulta de clientes

### Itens RPG

- Cadastro de itens
- Consulta de itens

### Vendas

- Registro de vendas
- Associação entre cliente e item
- Controle de quantidade
- Cálculo do valor total
- Histórico de vendas

---

## 🗄️ Banco de Dados

O sistema utiliza PostgreSQL hospedado no Supabase.

### Principais tabelas

#### Clientes

```sql
clientes
```

| Campo | Tipo |
|---------|---------|
| id_usuario | int |
| nome_usuario | varchar |

---

#### Itens RPG

```sql
itens_rpg
```

| Campo | Tipo |
|---------|---------|
| id | int |
| nome | varchar |

---

#### Vendas

```sql
vendas
```

| Campo | Tipo |
|---------|---------|
| id | int |
| cliente_id | int |
| item_id | int |
| quantidade | int |
| valor_total | decimal |
| data_venda | timestamp |

---

## 🔄 Fluxo de Venda

1. Selecionar cliente
2. Selecionar item
3. Informar quantidade
4. Calcular valor total
5. Registrar venda
6. Salvar no banco de dados

---

## 🛠️ Instalação

### 1. Clonar o repositório

```bash
git clone https://github.com/seu-usuario/rpg-shop.git
```

### 2. Acessar a pasta

```bash
cd rpg-shop
```

### 3. Restaurar dependências

```bash
dotnet restore
```

### 4. Executar o projeto

```bash
dotnet run
```

---

## 📦 Dependências

```xml
<PackageReference Include="Npgsql" Version="6.0.13" />
```

---

## 👨‍💻 Equipe

**Luis Felipe Dias de Souza**

Universidade Santa Cecília - UNISANTA

Disciplina: Aplicações para Desktop

---

## 📄 Licença

Projeto desenvolvido para fins acadêmicos.

## 👨‍💻 Equipe

Projeto desenvolvido por:

### 🤝 Colaboradores

| Nome | GitHub |
|--------|--------|
| Juan Victor Pereira Santos | [@juanVic7](https://github.com/juanVic7) |
| Matheus Enrico Araújo Santos | [@V0rtexs](https://github.com/V0rtexs) |
| Scott Kayllou Vitorino Melo | [@scottmelo2005-ops](https://github.com/scottmelo2005-ops) |
| Rogério Gomes Lacerda | [@rogeriomaci3l](https://github.com/rogeriomaci3l) |

### Instituição

**Universidade Santa Cecília (UNISANTA)**

**Disciplina:** Aplicações para Desktop

---

## 🤝 Agradecimentos

Agradecemos aos professores, colegas e colaboradores que contribuíram com orientações, sugestões e testes durante o desenvolvimento deste projeto acadêmico.

---

## 📄 Licença

Projeto desenvolvido exclusivamente para fins acadêmicos e educacionais.
