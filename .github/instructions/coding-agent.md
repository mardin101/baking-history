# Instructions for Coding Agent

## Scope
These instructions apply to the GitHub Copilot coding agent when working on code changes in this repository.

## Excluded Agents
- code-review

## Build and Test Process

### Before Making Changes
Always build the project first to understand the current state:
```bash
dotnet build
```

### After Making Changes
1. Build the project to ensure no compilation errors:
   ```bash
   dotnet build
   ```

2. If build succeeds, run the application to verify functionality:
   ```bash
   dotnet run
   ```

## Code Change Guidelines

### Minimal Changes
- Make the smallest possible changes to achieve the goal
- Don't refactor unrelated code unless specifically requested
- Preserve existing code style and patterns

### C# and Blazor Specific
- Always respect nullable reference types - the project has `<Nullable>enable</Nullable>`
- Use `string.Empty` instead of `""` for empty strings (matches existing code style)
- When creating Blazor components, follow the existing patterns in the `Pages/` directory
- Use dependency injection for services (already configured in `Program.cs`)
- Keep component logic in the `.razor` file unless it becomes complex enough to warrant a code-behind

### Service Layer
- The `BakingHistoryService` is registered as a singleton - be mindful of state management
- When adding new services, register them in `Program.cs` with the appropriate lifecycle

### Data Models
- Models are in the `Models/` directory
- Keep models simple and focused
- Use appropriate data types (e.g., `DateTime`, `TimeSpan` as seen in `BakingEntry`)

## Common Tasks

### Adding a New Page
1. Create a new `.razor` file in the `Pages/` directory
2. Use `@page` directive for routing
3. Follow the pattern of existing pages
4. Add navigation links in the layout if needed

### Adding a New Model
1. Create a new `.cs` file in the `Models/` directory
2. Use the `BakingHistory.Models` namespace
3. Initialize string properties with `string.Empty` to avoid nullable warnings

### Modifying the Service
1. The `BakingHistoryService` is the main service - changes here affect the entire application
2. Test thoroughly after service changes as it's used by multiple components

## Testing
- No test infrastructure currently exists in this project
- Manual testing should be done by running the application
- Verify UI changes by inspecting the running application in the browser

## Do Not
- Don't add test frameworks unless specifically requested
- Don't modify `.csproj` file unless absolutely necessary for the task
- Don't change the target framework version
- Don't remove or modify existing working code without good reason
