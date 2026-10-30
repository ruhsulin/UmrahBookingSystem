# Umrah Booking System

A web platform for Umrah travel agencies. Clients will be able to browse Umrah packages, book for a group, upload travel documents, and pay online or in cash. The agency will manage packages, hotels, activities, bookings, and document verification through an administration panel.

This is my bachelor's thesis project at **Riinvest College, Computer Science**. It is a full rebuild of an earlier project, [TravelAgjensiUmrah](https://github.com/ruhsulin/TravelAgjensiUmrah), built with ASP.NET Core 6. The rebuild introduces Clean Architecture, a redesigned database, and explicitly defined business rules.
> **Status:** Active development.  
> The architecture and data foundation are implemented. The administration interface, client booking flow, and external integrations are planned or under development.

## Tech Stack

| Area | Technology |
| --- | --- |
| Language | C# 14 |
| Framework | ASP.NET Core MVC (.NET 10 LTS) |
| Database | Microsoft SQL Server |
| ORM | Entity Framework Core 10 — Code First, Fluent API |
| Mapping | AutoMapper |
| User interface — planned | Bootstrap |
| Continuous integration | GitHub Actions — builds on `develop` and `main` |
| Real-time notifications — planned | SignalR |
| Background jobs — planned | Hangfire |
| Online payments — planned | Stripe |

## Architecture

The solution follows Clean Architecture, separating business logic from database access and presentation concerns.

```text
UmrahBookingSystem
├── UmrahBookingSystem.Domain
│   └── Entities, enums, and BaseEntity
├── UmrahBookingSystem.Application
│   └── Interfaces, services, DTOs, mappings, and Result pattern
├── UmrahBookingSystem.Infrastructure
│   └── AppDbContext, entity configurations, repositories,
│       Unit of Work, and database seeding
└── UmrahBookingSystem.Web
    └── MVC controllers, views, view models, and middleware
```

### Project Dependencies

```text
Domain         → No project dependencies
Application    → Domain
Infrastructure → Application, Domain
Web            → Application, Infrastructure
```

Business logic belongs in the inner layers. Infrastructure implements the interfaces defined by Application.

Web references Infrastructure to register its implementations through dependency injection. Controllers access application functionality through Application interfaces.

## Implemented Features

### Data Model and Persistence

- 21 entities, including `Package`, `Booking`, `Passenger`, `Payment`, `PackageRoom`, `WaitingList`, and `Notification`.
- Entity relationships and database constraints configured with the Fluent API.
- Audit fields through `BaseEntity` and an overridden `SaveChanges()`:
  - `CreatedAt`
  - `CreatedBy`
  - `UpdatedAt`
  - `UpdatedBy`
- Soft delete with global query filters.
- Unique constraints and indexes on performance-critical fields.
- Database seeding for roles, countries, and cities.
- Repository and Unit of Work patterns.

### Application Foundation

- Result pattern for service responses, with a shared `Error` model.
- AutoMapper integration for object mapping.
- Global exception-handling middleware and logging.
- Dependency injection registration separated into modules per layer.
- Environment-based configuration.

## Planned Features

### Administration

- Admin and Client areas with a Bootstrap layout.
- Package, hotel, activity, and service management.
- Image uploads for managed content.
- Booking and passenger management.
- Travel document review and verification.
- Manual recording of cash payments.

### Client Booking

- Browse available Umrah packages.
- Create one booking for a group of passengers.
- Select rooms for the whole group.
- Validate package and room capacity.
- Upload travel documents.
- Pay a deposit or the full booking amount.

### Integrations and Automation

- Stripe for online payments.
- SignalR for real-time notifications.
- Hangfire for automatic reminders and cancellation jobs.

## Business Rules

The following rules guide the implementation. This summary describes the intended behavior; it does not mean every rule is already implemented.

| Area | Rule |
| --- | --- |
| Group booking | One group is represented by one booking. |
| Room selection | Rooms are selected for the whole group within that booking. |
| Reservation | A place is reserved only after the required deposit is paid. |
| Deposit | The deposit depends on the room price per passenger. |
| Remaining balance | The balance is due 30 days before departure. |
| Cancellation | Cancellation fees vary according to the number of days remaining before departure. |
| Passenger information | Passenger data is locked 10 days before departure. |

## Database and Documentation

The project uses Microsoft SQL Server with EF Core Code First migrations.

The current database schema is available on [dbdiagram.io](https://dbdiagram.io/d/69bc67ad78c6c4bc7a278888).
Naming conventions and schema validation documentation are available in [docs/](docs/).

## Getting Started

### Requirements

- .NET 10 SDK
- SQL Server LocalDB or SQL Server Express
- Entity Framework Core CLI tools compatible with EF Core 10

The connection string below uses LocalDB, which is available on Windows. If you use SQL Server Express or another SQL Server instance, update the server and authentication settings accordingly.

### 1. Clone the Repository

```bash
git clone https://github.com/ruhsulin/UmrahBookingSystem.git
cd UmrahBookingSystem/UmrahBookingSystem
```

### 2. Restore Dependencies

```bash
dotnet restore
```

If the Entity Framework Core CLI tool is not installed, install a compatible version:

```bash
dotnet tool install --global dotnet-ef --version "10.*"
```

### 3. Configure the Database Connection

Navigate to the Web project:

```bash
cd UmrahBookingSystem.Web
```

Set the connection string using User Secrets:

```bash
dotnet user-secrets set "ConnectionStrings:DefaultConnection" "Server=(localdb)\MSSQLLocalDB;Database=UmrahBookingSystem;Trusted_Connection=True;TrustServerCertificate=True"
```

If the project does not already have a `UserSecretsId`, initialize User Secrets first:

```bash
dotnet user-secrets init
```

Then run the connection string command again.

Do not commit database credentials, payment keys, or other secrets to the repository. User Secrets are intended for local development.

### 4. Apply Database Migrations

Run the following command from `UmrahBookingSystem.Web`:

```bash
dotnet ef database update --project ../UmrahBookingSystem.Infrastructure --startup-project .
```

### 5. Run the Application

```bash
dotnet run
```

Open the application URL shown in the terminal.

## Development Workflow

The project uses Scrum adapted for a solo developer. Work is tracked in Jira under the project key **UBS**.

| Branch | Purpose |
| --- | --- |
| `main` | Stable releases |
| `develop` | Integration of completed work |
| `feature/UBS-{number}-{description}` | Work for an individual Jira ticket |

Feature branches are merged into `develop` through pull requests. Stable releases are merged into `main`.

GitHub Actions runs automated builds on `develop` and `main`.

## Project Background

The original application, **TravelAgjensiUmrah**, was built with ASP.NET Core 6.

This rebuild focuses on:

- Clear separation of responsibilities through Clean Architecture.
- A redesigned relational database.
- Explicit booking, payment, and cancellation rules.
- Maintainable application services and infrastructure.
- Incremental development through Jira tickets and feature branches.

## Author

**Alina Spahiu**  
Bachelor's thesis project — Computer Science  
Riinvest College
