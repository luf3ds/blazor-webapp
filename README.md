# 🛡️ RPG Shop

A web application developed with ASP.NET Core Blazor Server for managing RPG item sales, using PostgreSQL hosted on Supabase.

## 📋 About the Project

RPG Shop is a web-based application designed to manage RPG item sales, allowing users to handle customers, products, and sales through a Blazor Server interface.

The system is built using:

- ASP.NET Core 6
- Blazor Server
- PostgreSQL
- Supabase
- Npgsql

---

## 🚀 Technologies Used

| Technology | Description |
|------------|-------------|
| .NET 6 | Main Framework |
| Blazor Server | Web Interface |
| PostgreSQL | Database Management System |
| Supabase | Database Hosting Platform |
| Npgsql | PostgreSQL Driver for .NET |

---

## 📂 Project Structure

```text
RpgShop/
│
├── DAO/
│   ├── Database.cs
│   └── SaleDAO.cs
│
├── Models/
│   └── Sale.cs
│
├── Pages/
│
├── App.razor
├── Program.cs
├── appsettings.json
└── appsettings.Development.json
```

---

## ⚙️ Features

### Customers

- Customer registration
- Customer search and consultation

### RPG Items

- RPG item registration
- RPG item search and consultation

### Sales

- Sales registration
- Customer-item association
- Quantity management
- Total price calculation
- Sales history tracking

---

## 🗄️ Database

The system uses a PostgreSQL database hosted on Supabase.

### Main Tables

#### Customers

```sql
customers
```

| Field | Type |
|---------|---------|
| user_id | int |
| user_name | varchar |

---

#### RPG Items

```sql
rpg_items
```

| Field | Type |
|---------|---------|
| id | int |
| name | varchar |

---

#### Sales

```sql
sales
```

| Field | Type |
|---------|---------|
| id | int |
| customer_id | int |
| item_id | int |
| quantity | int |
| total_value | decimal |
| sale_date | timestamp |

---

## 🔄 Sales Workflow

1. Select a customer
2. Select an item
3. Enter the quantity
4. Calculate the total value
5. Register the sale
6. Save the transaction to the database

---

## 🛠️ Installation

### 1. Clone the repository

```bash
git clone https://github.com/your-username/rpg-shop.git
```

### 2. Navigate to the project directory

```bash
cd rpg-shop
```

### 3. Restore dependencies

```bash
dotnet restore
```

### 4. Run the application

```bash
dotnet run
```

---

## 📦 Dependencies

```xml
<PackageReference Include="Npgsql" Version="6.0.13" />
```

---

## 🏆 Team

This project was developed for academic purposes as part of the **Desktop Applications** course at **Santa Cecília University (UNISANTA)**.

### 🤝 Contributors

| Name | GitHub |
|--------|--------|
| Juan Victor Pereira Santos | [@juanVic7](https://github.com/juanVic7) |
| Matheus Enrico Araujo Santos | [@V0rtexs](https://github.com/V0rtexs) |
| Scott Kayllou Vitorino Melo | [@scottmelo2005-ops](https://github.com/scottmelo2005-ops) |
| Rogerio Gomes Lacerda | [@rogeriomaci3l](https://github.com/rogeriomaci3l) |

### Institution

**Santa Cecília University (UNISANTA)**

**Course:** Desktop Applications

---

## 🤝 Acknowledgements

We would like to thank our professors, classmates, and collaborators for their guidance, feedback, and support throughout the development of this academic project.

---

## 📄 License

This project was developed exclusively for academic and educational purposes.
````
