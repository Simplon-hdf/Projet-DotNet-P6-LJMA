# Projet-DotNet-P6-MLJA
L'objectif est de développer un nouveau site web pour remplacer l'actuel site "https://marchedeviens.com/" et ajouter les fonctionalités liés à la réservation d'un randonnée (compte de réservation, réservation à date, catalogue de randonnée, sejours proposé avec un nombre minimal et maximale de participant).  
Optionnellement ajout d'une section dédiés aux posts et vlogs de Dimitri actuellement posté sur linkedin.

## Stack Technologique

Notre projet utilise une combinaison de technologies modernes pour le développement front-end et back-end. Voici un aperçu de notre stack :

### Front-end
- [**Angular 18**](https://angular.dev/installation) : Framework JavaScript pour la construction d'interfaces utilisateur
- [**Angular Material**](https://material.angular.io/guide/getting-started) : Bibliothèque de composants UI pour Angular
- [**HTML5**](https://developer.mozilla.org/fr/docs/Learn/Getting_started_with_the_web/HTML_basics) : Langage de balisage pour la structure des pages web
- [**CSS3**](https://developer.mozilla.org/fr/docs/Learn/Getting_started_with_the_web/CSS_basics) : Langage de style pour la mise en forme des pages web
- [**TypeScript**](https://www.w3schools.com/typescript/typescript_intro.php) : Surensemble typé de JavaScript

### Back-end
- [**ASP.NET Core 8.0 (avec Swagger)**](https://learn.microsoft.com/fr-fr/aspnet/core/tutorials/first-web-api?view=aspnetcore-8.0&tabs=visual-studio) : Framework web pour la création d'APIs et d'applications web
- [**.NET 8**](https://learn.microsoft.com/fr-fr/dotnet/core/install/) : Plateforme de développement open-source
- [**MySQL**](https://www.youtube.com/watch?v=1UWNOG1EGWE) : Système de gestion de base de données relationnelle

### Outils et Environnement de Développement
- [**WampServer**](https://wampserver.aviatechno.net/) : Environnement de développement Web pour Windows

### Bibliothèques et Frameworks Supplémentaires
- [**Riok.Mapperly**](https://mapperly.riok.app/docs/intro/) : Bibliothèque de mapping d'objets pour .NET
- [**Microsoft.AspNetCore.Authentication.JwtBearer**](https://www.youtube.com/watch?v=_UGSG7vxq2Q) : Middleware pour l'authentification JWT dans ASP.NET Core

### Sécurité
- [JWT (JSON Web Tokens)](https://jwt.io/) pour l'authentification et l'autorisation

### Gestion de Version
- [Git](https://git-scm.com/downloads) pour le contrôle de version

## Environnements de Développement

Notre projet utilise plusieurs environnements de développement pour répondre à différents besoins :

### Visual Studio Code (VS Code)

[VS Code](https://visualstudio.microsoft.com/fr/free-developer-offers/) est notre éditeur de code principal pour le développement front-end et certaines tâches back-end légères.

- **Type** : Éditeur de code source léger mais puissant
- **Utilisation principale** : Développement Angular, TypeScript, HTML, CSS
- **Caractéristiques clés** :
  - Hautement personnalisable avec une large gamme d'extensions
  - Intégration Git intégrée
  - Débogage intégré pour JavaScript et TypeScript
  - Terminal intégré

### Visual Studio

[Visual Studio](https://visualstudio.microsoft.com/fr/free-developer-offers/) est notre IDE complet pour le développement back-end .NET.

- **Type** : Environnement de développement intégré (IDE) complet
- **Utilisation principale** : Développement ASP.NET Core, C#
- **Caractéristiques clés** :
  - Outils de développement .NET intégrés
  - Débogueur puissant
  - Outils de test intégrés
  - Support natif pour le développement ASP.NET Core

### WampServer

[WampServer](https://wampserver.aviatechno.net/?lang=fr) est utilisé comme environnement de développement local pour notre stack web.

- **Type** : Suite d'applications pour le développement web local
- **Utilisation principale** : Hébergement local de la base de données MySQL et serveur web
- **Caractéristiques clés** :
  - Intègre Apache, MySQL et PHP
  - Interface de gestion facile à utiliser
  - Permet de tester l'application en environnement local
  - Facilite la configuration et la gestion de la base de données MySQL

Ces outils complémentaires nous permettent de couvrir efficacement tous les aspects de notre stack de développement, du front-end au back-end, en passant par l'hébergement local et la gestion de base de données.

## Nomenclature

### Nommage des branches
| commande git depuis la branche `develop` | description |
|---|---|
| `git checkout -b feat/front/nom_ticket` | Création d'une branche feature front |
| `git checkout -b feat/back/nom_ticket` | Création d'une branche feature back |

### Convention de style de codage
[**Règles et conventions de nommage des identificateurs C#**](https://learn.microsoft.com/fr-fr/dotnet/csharp/fundamentals/coding-style/identifier-names)  
[**Conventions de code C# courantes**](https://learn.microsoft.com/fr-fr/dotnet/csharp/fundamentals/coding-style/coding-conventions)  
[**Angular 18: syntaxe, les conventions et la structure d'application**](https://angular.dev/style-guide)

### [Commits](https://arunkumarvallal.medium.com/become-a-pro-at-commit-messages-using-commitlint-56dab86333b3)

![](https://miro.medium.com/v2/resize:fit:750/format:webp/1*naLIcn5hr9OiBwmopSLucQ.png)
```
[type](fileName): [commit message]
```

| **Type** | **Description** |
|---|---|
| `build` | Changements qui affectent le système de build ou les dépendances externes (exemples : gulp, broccoli, npm) |
| `ci` | Changements apportés aux fichiers et scripts de configuration CI (exemples | Travis, Circle, BrowserStack, SauceLabs) |
| `chore` | Changements qui ne modifient pas le code source ou les tests, par exemple des modifications du processus de build, des outils auxiliaires et des bibliothèques |
| `docs` | Modifications de la documentation uniquement |
| `feat` | Nouvelle fonctionnalité |
| `fix` | Correction d'un bug |
| `perf` | Changement de code qui améliore les performances |
| `refactor` | Changement de code qui ne corrige pas un bug et n'ajoute pas de fonctionnalité |
| `revert` | Annulation d'un changement précédent |
| `style` | Changements qui n'affectent pas la signification du code (espaces, formatage, points-virgules manquants, etc.) |
| `test` | Ajout de tests manquants ou correction de tests existants |

## Gestion de la Base de Données et ORM

Notre projet utilise Entity Framework Core comme ORM (Object-Relational Mapping) pour interagir avec la base de données MySQL. Voici un aperçu des outils et techniques utilisés :

### [Entity Framework Core](https://learn.microsoft.com/fr-fr/ef/core/)

- **Utilisation** : ORM pour .NET, facilitant l'interaction avec la base de données
- **Version** : Entity Framework Core 8.0 (compatible avec .NET 8)

![](https://www.entityframeworktutorial.net/Images/efcore/ef-core-dev-approaces.png)

### DbContext

- **Rôle** : Représente une session avec la base de données, permettant d'interroger et de sauvegarder des données
- **Utilisation** : Configuration des entités, définition des relations, et personnalisation du comportement de l'ORM

### [Migrations](https://learn.microsoft.com/fr-fr/ef/core/managing-schemas/migrations/?tabs=dotnet-core-cli)

- **Objectif** : Gestion des changements de schéma de base de données de manière contrôlée et versionnée
- **Utilisation de la ligne de commande (CLI)** :
  ```
  dotnet ef migrations add [NomMigration]
  dotnet ef database update
  ```
- **Utilisation de la Console du Gestionnaire de Packages (Package Manager Console) dans Visual Studio**:
  ```
  Add-Migration [NomMigration]
  Update-Database
  ```

### [Scaffolding](https://learn.microsoft.com/fr-fr/ef/core/managing-schemas/scaffolding/?tabs=dotnet-core-cli)

- **Utilisation** : Génération automatique de modèles, contrôleurs et vues à partir de la base de données existante
- **Utilisation de la ligne de commande (CLI)** :
  ```
  dotnet ef dbcontext scaffold [ConnectionString] Pomelo.EntityFrameworkCore.MySql -o Models
  ```
- **Utilisation de la Console du Gestionnaire de Packages (Package Manager Console) dans Visual Studio** :
  ```
  Scaffold-DbContext [ConnectionString] Pomelo.EntityFrameworkCore.MySql -OutputDir Models
  ```

### Packages NuGet Utilisés

- **Pomelo.EntityFrameworkCore.MySql** : Provider MySQL pour Entity Framework Core
- **Microsoft.EntityFrameworkCore** : Package principal d'Entity Framework Core
- **Microsoft.EntityFrameworkCore.Tools** : Outils pour les migrations et le scaffolding dans la console Package Manager

### Configuration

La configuration de la connexion à la base de données se fait dans le fichier `appsettings.json` :

```json
{
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=NomDeVotreDB;User=root;Password=votreMotDePasse;"
}
}
```

Cette configuration est ensuite utilisée dans la méthode ConfigureServices de `Infrastructure/Configurations/DataBaseConfiguration.cs` :
```csharp
services.AddDbContext<VotreDbContext>(options =>
    options.UseMySql(Configuration.GetConnectionString("DefaultConnection"),
    new MySqlServerVersion(new Version(8, 0, 21))));
```

Cette approche nous permet de maintenir une base de données évolutive et de gérer efficacement les changements de schéma tout au long du développement du projet.
