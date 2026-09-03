Markdown

# BookStore App - ASP.NET Core API & Blazor Full-Stack Practice

A full-stack web application developed as part of hands-on practice, experimentation, and rework for the Udemy course **[End-to-End ASP.NET Core 3.1 API and Blazor Development](https://www.udemy.com/course/end-to-end-aspnet-core-31-api-and-blazor-development/)** by Trevoir Williams.

## 🚀 Key Features Covered

### Backend (ASP.NET Core Web API)

* **RESTful Endpoints:** Complete CRUD operations for Books and Authors resources with standard HTTP status code responses (`200 OK`, `201 Created`, `400 Bad Request`, `404 Not Found`, `500 Internal Server Error`).
* **Data Persistence:** Entity Framework Core Code-First workflow, migrations, and one-to-many relationship mapping (`Author` -> `Books`).
* **Design Patterns:** Repository Pattern and Unit of Work abstractions to isolate business logic from database operations.
* **DTO Mapping:** AutoMapper integration for mapping domain entities to request/response DTOs without leaking database structures.
* **Security & Identity:**
* ASP.NET Core Identity for user management, password hashing, and role-based access control (`Admin`, `Customer`).
* Secure token-based authentication using **JSON Web Tokens (JWT)**.
* Endpoint route authorization with `[Authorize]` and policy/role checks.


* **Diagnostics & API Docs:**
* Structured application logging using **NLog** / **Serilog**.
* Interactive API documentation and testing via **Swagger UI / OpenAPI specification**.


* **Cross-Origin Resource Sharing (CORS):** Granular CORS configuration to allow secure communication with the Blazor frontend.

### Frontend (Blazor Web UI)

* **Component Architecture:** Reusable Razor UI components, data-binding (`@bind`), event handling, and cascading parameters.
* **Authentication State:** Custom `AuthenticationStateProvider` implementation to intercept, decode JWT payloads, and maintain authentication session state across pages.
* **Protected Routing:** Enforcing access control via `<AuthorizeRouteView>`, `<Authorizing>`, and `<NotAuthorized>` templates.
* **Secure Token Storage:** Local storage handling for bearer tokens and dynamic attachment to outgoing HTTP request headers.

## 🛠️ Tech Stack & Prerequisites

### Technology Stack

* **Runtime / Framework:** .NET Core 3.1 *(adaptable to .NET 8 / 9 LTS)*
* **Backend Framework:** ASP.NET Core Web API
* **Frontend Framework:** Blazor (Server / WebAssembly)
* **ORM:** Entity Framework Core (EF Core) 3.1+
* **Database:** Microsoft SQL Server (LocalDB / Express / Azure SQL / Docker)
* **Authentication:** ASP.NET Core Identity + JWT (Bearer Authentication)
* **Object Mapping:** AutoMapper
* **Logging:** NLog / Serilog
* **API Tooling:** Swashbuckle.AspNetCore (Swagger / OpenAPI)

### Prerequisites

Before running the solution, ensure the following are installed:

* [.NET Core 3.1 SDK](https://www.google.com/search?q=https://dotnet.microsoft.com/download/dotnet/3.1) or [.NET 8.0 SDK](https://www.google.com/search?q=https://dotnet.microsoft.com/download/dotnet/8.0)
* [Visual Studio 2019/2022](https://www.google.com/search?q=https://visualstudio.microsoft.com/) (with *ASP.NET and web development* workload) or [JetBrains Rider](https://www.google.com/search?q=https://www.jetbrains.com/rider/) / [VS Code](https://www.google.com/search?q=https://code.visualstudio.com/) with C# Dev Kit
* [SQL Server](https://www.google.com/search?q=https://www.microsoft.com/en-us/sql-server/sql-server-downloads) or SQL Server Express / LocalDB
* [SQL Server Management Studio (SSMS)](https://www.google.com/search?q=https://learn.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms) or Azure Data Studio
* `dotnet-ef` CLI tool:
```bash
dotnet tool install --global dotnet-ef

```



```

```
---
