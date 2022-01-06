# .NET 6 Flashing AuthorizeView

## Introduction
This repository is designed to reproduce an issue in .NET 6 where `StateHasChanged` causes visible UI flashes for elements within `AuthorizeView` components where the associated policy awaits an async call of at least 1ms.

## Reproduction Steps
1. Pull down a local copy of the repository
2. Open the solution (`.sln` file) in your IDE of choice
3. Run the project
4. A webpage will open with a table of policies and example text that is being rendered within an `AuthorizeView` that implements the associated policy
5. Note that the text alongside the "Task.Delay(1)" policy visibly flashes once every second while the others remain constant. This can also be seen in the DOM inspector in most browsers which will indicate an update on the element every second
6. Update the project to .NET 5
7. Run the project again
8. Note that the text alongside the "Task.Delay(1)" policy no longer visibly flashes when `StateHasChanged` is being called with no other code changes (a breakpoint can be added to line 80 in `Index.razor` to confirm that the timer is running and `StateHasChanged` is still being called correctly
