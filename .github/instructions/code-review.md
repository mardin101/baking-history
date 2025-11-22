# Instructions for Code Review Agent

## Scope
These instructions apply to the GitHub Copilot code review agent when reviewing pull requests in this repository.

## Excluded Agents
- coding-agent

## Review Focus Areas

### C# and .NET Specific
- **Nullable Reference Types**: Verify proper handling of nullable types (project has nullability enabled)
- **String Initialization**: Check that empty strings use `string.Empty` to match project style
- **Implicit Usings**: Remember that common namespaces are auto-imported (no need to flag missing common usings)
- **Modern C# Syntax**: Encourage use of C# 12 features where appropriate

### Blazor Components
- **Component Structure**: Verify components follow Blazor best practices
- **Lifecycle Methods**: Check proper use of component lifecycle methods
- **Parameter Binding**: Ensure proper use of `[Parameter]` attributes
- **Event Handling**: Verify event handlers are properly implemented

### Architecture
- **Service Usage**: Ensure services are properly injected via DI
- **Singleton State**: Be aware that `BakingHistoryService` is a singleton - watch for state management issues
- **Component Modularity**: Encourage keeping components focused and reusable

### Code Quality
- **Type Safety**: Ensure strong typing is maintained throughout
- **Error Handling**: Check for appropriate error handling in async operations
- **Validation**: Look for proper input validation in forms

### Security
- **Input Validation**: Ensure user inputs are validated
- **XSS Prevention**: Blazor handles most XSS prevention, but review any JavaScript interop
- **Data Sanitization**: Verify data is properly sanitized before display

## What Not to Flag

- Missing unit tests (no test infrastructure exists in this project)
- Missing XML documentation comments (not used consistently in this project)
- Use of `string.Empty` instead of `""` (this is the project standard)
- Missing explicit usings for common namespaces (implicit usings are enabled)

## Review Priorities

1. **Correctness**: Does the code work as intended?
2. **Type Safety**: Are nullable types handled properly?
3. **Security**: Are there any security concerns?
4. **Consistency**: Does it match existing code patterns?
5. **Simplicity**: Is the solution as simple as possible?

## Constructive Feedback

- Focus on issues that could cause bugs or security problems
- Suggest improvements that align with existing patterns
- Be specific about what to change and why
- Acknowledge good practices when you see them
