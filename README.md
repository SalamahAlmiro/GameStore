<<<<<<< HEAD
# GameStore

A Windows desktop game storefront built in C# / WPF, following the MVVM (Model-View-ViewModel) architectural pattern.

The login/authentication screen was built by following a WPF MVVM tutorial to learn the framework. Everything past login — the store, library, discounts, and the underlying data layer — was designed and built independently.

## Features

- **Store** — browse the full game catalog
- **Library** — view games owned by the logged-in user, backed by a joined `Ownership` → `Games` query
- **Discounts** — view currently discounted titles
- Custom, reusable WPF `UserControl` for masked password entry (`SecureString`-backed, bindable dependency property)
- Repository pattern behind interfaces (`IGameRepository`, `IUserRepository`) separating data access from view-model logic

## Tech stack

C#, WPF, XAML, MVVM, SQL Server, ADO.NET

## Getting started

1. Open `WPF-LoginForm.sln` in Visual Studio
2. Create the SQL Server database and update the connection string in `App.config` (`connectionStrings` → `GameStoreDb`) to match your instance
3. Run the schema/seed script for your `Games`, `User`, `Ownership`, and `Discounts` tables
4. Build and run

> Note: `MVVMLoginDb.sql` in the repo root reflects an earlier version of the schema (database name `MVVMLoginDb`) from the original login tutorial. The application code now targets a database named `TestDataBase` — if you're setting this up fresh, create your schema under that name, or update the connection string in `App.config` to match whichever database you use.

## Project structure

```
Core/            RelayCommand (ICommand implementation for MVVM bindings)
CustomControls/  Reusable WPF controls (bindable password box, custom buttons)
Models/          Data models and repository interfaces
Repositories/    ADO.NET data access layer
ViewModels/      MVVM view models (Store, Library, Discounts, Login, Main)
Views/           XAML views
```
=======

>>>>>>> 9e5f9b0603b6a0e5a8ab362d9a24a2371afc54cc
