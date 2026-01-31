AURA Project Guidelines
1. Project Overview
Name: AURA

Stack: Angular (Frontend), .NET 8/9 (Backend), SQL Server (Database).

Hosting: Azure Static Web Apps (Client) & Azure App Service (Server).

2. Folder Architecture
All code must strictly follow this structure:

/client: Angular workspace.

/src/environments: Must contain environment.ts, environment.uat.ts, and environment.prod.ts.

/server: .NET Solution.

/Aura.Api: Entry point, controllers, and appsettings.{Env}.json.

/Aura.Core: Domain entities, interfaces, and business logic.

/Aura.Data: Entity Framework Core, DbContext, and Migrations.

3. Coding Standards & Constraints
Naming: Use Aura as the root namespace for .NET (e.g., Aura.Api.Controllers).

Angular: * Use Standalone Components.

Lazy loading for all feature modules.

Strict typing (no any).

Backend: * Use the Repository and Unit of Work patterns.

Dependency Injection is mandatory.

Global Exception Handling middleware must be present.

Database: * Use EF Core Code-First migrations.

Naming convention: PascalCase for tables and columns.

4. Environment & Configuration
Client: All API URLs must be pulled from the environment files. Do not hardcode strings.

Server: Use IConfiguration to toggle between local SQL Server and Azure SQL Database.

Azure: * Static Web App will point to the /client build output.

App Service will host the /server/Aura.Api project.