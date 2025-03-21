# Entity Framework Core (EF Core)

Entity Framework Core (EF Core) is a modern Object-Relational Mapper (ORM) for .NET applications, enabling developers to work with databases using .NET objects.

---

## 🚀 Implementation Approaches

### 1️⃣ Code-First  
Define your data model using C# classes, and EF Core generates the database schema for you.

### 2️⃣ Database-First  
Start with an existing database, and EF Core generates the corresponding data model.

---

## 📦 Required Packages

To get started with EF Core, add the following NuGet packages to your project:

```bash
dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 7.0.0
```

```bash
dotnet add package Microsoft.EntityFrameworkCore.Tools --version 7.0.0
```

---

## 🛠️ Demo Application Steps

1. **📝 Create a Model**  
    Example: Define a `Category` class to represent your data model.

2. **⚙️ Configure the Database Context**  
    Set up a `DbContext` class to manage database operations.

3. **📤 Run Migrations**  
    Use EF Core tools to create and apply migrations.

4. **🔍 Query the Database**  
    Perform CRUD operations using LINQ queries.

---

📖 For more details, visit the [official EF Core documentation](https://learn.microsoft.com/en-us/ef/core/).
