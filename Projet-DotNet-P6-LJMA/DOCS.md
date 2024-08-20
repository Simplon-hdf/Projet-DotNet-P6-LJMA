# Commandes de projet

## Les Migrations

### Utilisation de la ligne de commande (CLI)
```
dotnet ef migrations add v1 --output-dir Infrastructure/Migrations
```

### Utilisation de la Console du Gestionnaire de Packages (Package Manager Console) dans Visual Studio
```
Add-Migration v1 -OutputDir Infrastructure/Migrations
Update-Database
```

## Scaffold 
TODO : Models to Entities
### Utilisation de la ligne de commande (CLI)
```
dotnet ef dbcontext scaffold "Your Connection String" Microsoft.EntityFrameworkCore.SqlServer -o Infrastructure/Data/Models
```

### Utilisation de la Console du Gestionnaire de Packages (Package Manager Console) dans Visual Studio
```
Scaffold-DbContext "Your Connection String" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Infrastructure/Data/Models -Context YourDbContext -ContextDir Infrastructure/Data -DataAnnotations
```
