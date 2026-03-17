# 🎮 LostArkOffice

[![.NET](https://img.shields.io/badge/.NET-7.0-512BD4?style=flat-square&logo=dotnet)](https://dotnet.microsoft.com/)
[![ASP.NET Core](https://img.shields.io/badge/ASP.NET%20Core-MVC-512BD4?style=flat-square&logo=dotnet)](https://dotnet.microsoft.com/apps/aspnet)
[![Entity Framework](https://img.shields.io/badge/Entity%20Framework-7.0-512BD4?style=flat-square)](https://docs.microsoft.com/ef/)
[![SQL Server](https://img.shields.io/badge/SQL%20Server-CC2927?style=flat-square&logo=microsoft-sql-server)](https://www.microsoft.com/sql-server)
[![Bootstrap](https://img.shields.io/badge/Bootstrap-5.3-7952B3?style=flat-square&logo=bootstrap)](https://getbootstrap.com/)
[![Webpack](https://img.shields.io/badge/Webpack-5.89-8DD6F9?style=flat-square&logo=webpack)](https://webpack.js.org/)
[![License](https://img.shields.io/badge/License-MIT-green?style=flat-square)](LICENSE)

[![CleanCode](https://img.shields.io/badge/Pattern-MVC-blue?style=flat-square)](https://en.wikipedia.org/wiki/Model%E2%80%93view%E2%80%93controller)
[![Architecture](https://img.shields.io/badge/Arch-Repository%20Pattern-informational?style=flat-square)](https://docs.microsoft.com/en-us/dotnet/architecture/modern-web-apps-azure/)
[![SCRUM](https://img.shields.io/badge/Methodology-SCRUM-orange?style=flat-square)](https://www.scrum.org/)
[![Teamwork](https://img.shields.io/badge/Soft%20Skills-Problem%20Solving-yellow?style=flat-square)](https://github.com/samuelhm/)

---

## 📝 Descripción

**LostArkOffice** es una plataforma web de gestión para gremios de *Lost Ark* que centraliza la organización de raids, el seguimiento de personajes y la coordinación de miembros. Resuelve el problema de dispersión de información en comunidades gaming mediante un sistema unificado de autenticación y administración de recursos del gremio.

---

## ✨ Características Principales

- **Autenticación Robusta** - Login/Registro con validación asíncrona de email y username, protección CSRF y gestión de sesiones persistentes
- **Autorización Basada en Roles** - Sistema de permisos granular con ASP.NET Core Identity (SuperAdmin, GremioAdmin, Usuario)
- **Gestión de Gremios** - CRUD completo de gremios con asignación de usuarios
- **Administración de Raids** - Creación de tipos (4/8 jugadores), programación con fechas y duración
- **Control de Personajes** - Sistema de clases, niveles (ItemLevel) y asociación con usuarios
- **Validación Frontend** - Verificaciones en tiempo real con JavaScript vanilla + Bootstrap

---

## 🛠️ Stack Tecnológico

| Capa | Tecnología |
|------|------------|
| **Backend** | ASP.NET Core MVC 7.0 |
| **ORM** | Entity Framework Core 7.0.13 |
| **Database** | SQL Server |
| **Auth** | ASP.NET Core Identity |
| **Frontend** | Bootstrap 5.3 + JavaScript ES6 |
| **Bundler** | Webpack 5.89 |

---

## 🏗️ Decisiones Técnicas

El proyecto adopta el patrón **MVC** para garantizar separación de responsabilidades y facilita rel mantenimiento a largo plazo. Se eligió **ASP.NET Core Identity** por ofrecer hashing de contraseñas, protección contra ataques de fuerza bruta y gestión de claims out-of-the-box, evitando vulnerabilidades comunes en implementaciones custom.

**Entity Framework Core** con enfoque Code-First permite versionar los cambios de esquema mediante migraciones, manteniendo sincronizados el modelo y la base de datos. La integración de **Webpack** moderniza el manejo de assets frontend sin abandonar la arquitectura .NET tradicional.

---

## 📊 Diagrama de Arquitectura

```mermaid
flowchart TB
    subgraph Client["Navegador"]
        UI["Bootstrap 5"]
        JS["Webpack Bundle"]
    end

    subgraph Server["ASP.NET Core 7"]
        MW["Middleware"]
        subgraph MVC["MVC Layer"]
            CTRL["Controllers"]
            VIEW["Razor Views"]
            VM["ViewModels"]
        end
        subgraph ID["Identity"]
            AUTH["Auth"]
            ROLES["Roles"]
        end
    end

    subgraph Data["Persistencia"]
        EF["EF Core"]
        DB[("SQL Server")]
    end

    UI --> MW
    JS --> UI
    MW --> CTRL
    CTRL --> VIEW
    CTRL --> VM
    CTRL --> ID
    ID --> EF
    CTRL --> EF
    EF --> DB
    VIEW --> UI
```

---

## 🚀 Getting Started

### Prerrequisitos

- [.NET 7.0 SDK](https://dotnet.microsoft.com/download/dotnet/7.0)
- [SQL Server](https://www.microsoft.com/sql-server) (LocalDB o instancia completa)
- [Node.js](https://nodejs.org/) v16+

### Instalación

```bash
git clone https://github.com/samuelhm/LostArkOffice.git
cd LostArkOffice
dotnet restore
npm install && npm run build
```

Configura `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=LostArkOffice;Trusted_Connection=True;TrustServerCertificate=true;"
  }
}
```

```bash
dotnet ef database update
dotnet run
```

Abre https://localhost:5001

---

## 📁 Estructura

```
LostArkOffice/
├── Controllers/
│   ├── AccountController.cs
│   ├── SuperAdminController.cs
│   └── HomeController.cs
├── Models/
│   ├── DataModels/ (EF Entities)
│   ├── ViewModels/
│   └── ApplicationDbContext.cs
├── Views/
│   ├── Account/
│   ├── SuperAdmin/
│   └── Shared/
├── src/
│   ├── index.js
│   └── ValidarFormularioRegister.js
├── Migrations/
└── Program.cs
```

---

## 📬 Contacto

**Samuel Hurtado**

[![GitHub](https://img.shields.io/badge/GitHub-samuelhm-181717?style=flat-square&logo=github)](https://github.com/samuelhm/)
[![LinkedIn](https://img.shields.io/badge/LinkedIn-shurtado--m-0A66C2?style=flat-square&logo=linkedin)](https://www.linkedin.com/in/shurtado-m/)