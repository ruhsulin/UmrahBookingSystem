# UmrahBookingSystem — Naming Conventions

This document defines the naming conventions applied consistently across all layers of the project to ensure readability, maintainability, and alignment with professional .NET development standards.

## 1. General Rules
- All names use PascalCase unless stated otherwise
- Naming must be consistent across the entire codebase
- Names should be clear, descriptive, and aligned with domain terminology

## 2. Domain & Core Models
- Entities / Classes: Singular, PascalCase
- Examples: User, Booking, PackageHotel

- Properties: PascalCase
- Examples: FirstName, CreatedAt, PaymentMethod

- Foreign Key Properties : Format: {ReferencedEntity}Id:  Singular, PascalCase
- Examples: UserId, PackageId, GuardianId

## 3. Navigation Properties
- Single Navigation Properties: Singular, PascalCase
- Examples: User, Package, Location

- Collection Navigation Properties: Plural, PascalCase
- Examples: Bookings, Passengers, PackageHotels

## 4. DTOs & View Models
- DTOs: Singular, PascalCase, with descriptive suffix
- Examples: CreateBookingDto, BookingResponseDto, UpdateUserDto

- ViewModels: Singular, PascalCase
- Examples: BookingViewModel, UserProfileViewModel

## 5. Enums
- Enum Types: Singular, PascalCase
- Examples: BookingStatus, PaymentMethod, NotificationType

- Enum Values: Singular, PascalCase
- Examples: Pending, Confirmed, Cancelled, BankTransfer

## 6. Data Access & Configuration
- DbSet Properties: Plural, PascalCase
- Examples: Users, Bookings, PackageHotels

- Configuration Classes (Fluent API)
- Format: {EntityName}Configuration: Singular, PascalCase
- Examples: UserConfiguration, BookingConfiguration, PackageHotelConfiguration

- Fluent API Rules
- Class names: PascalCase
- Property mappings: must match entity property names exactly

- Table mapping: Plural PascalCase
- Example: builder.ToTable("Users");

## 7. Database (Generated via Code-First)
- Table Names: Plural, PascalCase
- Examples: Users, Bookings, Notifications

## 8. Application Layer Naming
- Interfaces: Prefix with I, Singular, PascalCase
- Examples: IUserService, IBookingRepository

- Services: Singular, PascalCase
- Examples: UserService, BookingService

- Repositories: Singular, PascalCase
- Examples: UserRepository, BookingRepository

## 9. Project Structure
- C# Folders: Plural, PascalCase (when containing multiple items)
- Examples: Entities, Repositories, Configurations, Controllers

- Repository-level folders: lowercase
- Example: docs, .github

## 10. Bridge Entities (Many-to-Many)
- Class Names: Singular, PascalCase
- Examples: PackageHotel, PackageService, BookingRoom

- Table Names: Plural, PascalCase
- Examples: PackageHotels, PackageServices, BookingRooms

