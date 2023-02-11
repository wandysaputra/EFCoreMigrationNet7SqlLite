## EF Core Net 7 Migration SQL Lite
#### Packages Required

- Microsoft.EntityFrameworkCore.Sqlite
- Microsoft.EntityFrameworkCore.Tools


#### Create migration files

- on Package Manager Console, type `add-migration InitialMigration` 
- on PowerShell, type `dotnet ef migrations add InitialMigration`

#### Update database (or create DB if not exists)

- on Package Manager Console, type `update-database`
- on PowerShell, type `dotnet ef database update`


#### DbContext

`DbContext` registered on Container with `Scoped` lifetime, refer https://learn.microsoft.com/en-us/ef/core/dbcontext-configuration/
, hence the `Repository` need to be registered with same or less lifetime


#### Others

- `Microsoft.VisualStudio.Web.CodeGeneration.Design` used to scaffold empty Api Controller.
- To update `dotnet-ef` cli tool => `dotnet tool install --global dotnet-ef`