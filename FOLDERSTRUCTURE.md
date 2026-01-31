/my-application-root
│
├── /client                 <-- Angular Frontend (Azure Static Web App)
│   ├── /src
│   │   ├── /app
│   │   │   ├── /core       <-- Services, Auth, Guards (Singleton)
│   │   │   ├── /shared     <-- Reusable UI components/pipes
│   │   │   └── /features   <-- Module-based feature folders
│   │   └── /environments   <-- Configuration files
│   │       ├── environment.ts          (Default/Local)
│   │       ├── environment.uat.ts      (UAT)
│   │       └── environment.prod.ts     (Production)
│   ├── angular.json
│   └── package.json
│
├── /server                 <-- .NET Backend (Azure App Service)
│   ├── /MyProject.Api      <-- Entry point, Controllers, Middlewares
│   │   ├── /Controllers
│   │   ├── appsettings.json
│   │   ├── appsettings.Development.json
│   │   ├── appsettings.UAT.json
│   │   └── appsettings.Production.json
│   ├── /MyProject.Core     <-- Business Logic, Interfaces, DTOs
│   ├── /MyProject.Data     <-- DB Context, Migrations (SQL Server)
│   └── MyProject.sln
│
├── /infra                  <-- Infrastructure as Code (Bicep/ARM/Terraform)
└── .gitignore