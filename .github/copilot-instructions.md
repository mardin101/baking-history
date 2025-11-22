# Copilot Instructions for Baking History

## Project Overview

This is a **Baking History** application - a Blazor WebAssembly application built with .NET 10.0 that helps users track and manage their baking activities. The application allows users to record detailed information about their baking sessions, including temperatures, fermentation times, and baking schedules.

## Technology Stack

- **Framework**: Blazor WebAssembly
- **Runtime**: .NET 10.0
- **Language**: C# with nullable reference types enabled
- **UI Components**: Blazor components (.razor files)
- **State Management**: Singleton service pattern

## Project Structure

```
/
├── Models/           # Data models (BakingEntry)
├── Services/         # Business logic (BakingHistoryService)
├── Pages/           # Blazor page components
├── Layout/          # Layout components
├── wwwroot/         # Static assets (CSS, JS, images)
├── Program.cs       # Application entry point
└── App.razor        # Root component
```

## Code Standards

### C# Conventions
- Use C# 12 features and modern syntax
- Nullable reference types are enabled - always handle nullability properly
- Follow Microsoft's C# coding conventions
- Use `string.Empty` instead of `""` for empty strings
- Use meaningful variable and method names

### Blazor Component Guidelines
- Component files use `.razor` extension
- Separate code-behind logic when components become complex
- Use dependency injection for services
- Follow Blazor component lifecycle best practices

### Project Settings
- `ImplicitUsings` is enabled - common namespaces are automatically imported
- Target framework is `net10.0`

## Building and Running

### Build
```bash
dotnet build
```

### Run
```bash
dotnet run
```

### Development Server
The application runs as a WebAssembly application in the browser. The development server is provided by `Microsoft.AspNetCore.Components.WebAssembly.DevServer`.

## Key Components

### Models
- `BakingEntry`: Core data model tracking baking session details including temperatures, times, and comments

### Services
- `BakingHistoryService`: Singleton service managing baking entries

### Pages
- `Home.razor`: Landing page
- `BakingEntries.razor`: List of all baking entries
- `AddBakingEntry.razor`: Form to add new entries
- `BakingEntryDetails.razor`: Detailed view of a single entry

## Important Notes

- This is a client-side Blazor WebAssembly application (not Blazor Server)
- State is managed through singleton services
- The application uses .NET 10.0 features and APIs

## Best Practices for This Project

1. **Maintain Type Safety**: Always respect nullable reference types
2. **Service-Oriented**: Use dependency injection for services
3. **Component Modularity**: Keep Blazor components focused and reusable
4. **Consistent Naming**: Follow existing naming patterns in the codebase
5. **Modern C#**: Utilize C# 12 features where appropriate
