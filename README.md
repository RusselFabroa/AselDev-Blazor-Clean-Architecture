# 🖥️ AselDev Blazor Clean Architecture Template

A modern **Blazor Server** template implementing **Clean Architecture** principles with **MudBlazor** for UI components and **Serilog** for structured logging.  
This template is designed to help you **kickstart scalable, maintainable, and testable Blazor applications**.

---

## 🚀 Features
- **Blazor Server** with Clean Architecture folder structure
- **Entity Framework Core** for data access
- **MudBlazor** for modern UI components
- **Serilog** for structured logging
- **API Layer** for decoupled data access
- **Authentication & Authorization** built-in
- **Dependency Injection** for service management
- **Configuration via `appsettings.json`**
- **Support for Multiple Database Providers**
- **Fully Responsive Layouts**

---

## 📂 Project Structure
```
src/
│── AselBlazorCleanArchitecture.Application    # Core Business Logic, Interfaces, DTOs, Validation
│── AselBlazorCleanArchitecture.Infrastructure # EF Core, Repositories, Database Context, External Services
│── AselBlazorCleanArchitecture.Server         # Blazor Web App Host, API Controllers, DI Configuration
│── AselBlazorCleanArchitecture.Shared         # Shared Models, Enums, and DTOs for Client & Server
```

---

## 🛠 Tech Stack
- **Frontend**: Blazor Server + MudBlazor  
- **Backend**: ASP.NET Core Web API  
- **ORM**: Entity Framework Core  
- **Database**: SQL Server (configurable to MySQL, PostgreSQL, Oracle, etc.)  
- **Logging**: Serilog (Console, File, Seq)  

---

## 📦 Getting Started

### 1️⃣ Clone the repository
```bash
git clone https://github.com/YourUsername/AselDev-Blazor-Clean-Architecture.git
cd AselDev-Blazor-CleanArchitecture
```

### 2️⃣ Install dependencies
Make sure you have the **.NET SDK (8.0+)** installed.

### 3️⃣ Set up the database (Optional)
```bash
dotnet ef database update --project AselBlazorCleanArchitecture.Infrastructure
```

### 4️⃣ Run the application
```bash
dotnet run --project AselBlazorCleanArchitecture.Server
```


---

## 🔄 Folder Layer Responsibilities
- **Application** → Core logic, service interfaces, DTOs, validation  
- **Infrastructure** → Database context, EF migrations, external services  
- **Server** → Blazor Web App host, API controllers, DI configuration  
- **Shared** → Shared models, enums, DTOs used by client & server  

---



---

## 📌 Example Architecture Diagram
```
[ Client (Blazor) ]
        ↓
[ Application Layer ]
        ↓
[ Infrastructure Layer ]
        ↓
[ Database / External Services ]
```

---

## 📝 License
This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

---

## ❤️ Acknowledgements
- [Blazor](https://dotnet.microsoft.com/apps/aspnet/web-apps/blazor)  
- [MudBlazor](https://mudblazor.com/)  
- [Serilog](https://serilog.net/)  
- [Entity Framework Core](https://learn.microsoft.com/en-us/ef/core/)  
