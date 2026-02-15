# School Module Tests

Professional testing setup for the **School** module (school-only scope) of the .NET 8 Clean Architecture system.

---

## Main code vs test code (where to write what)

| You want to write… | Use this doc | Location |
|--------------------|--------------|----------|
| **Main (production) code** — services, controllers, entities, DTOs, repositories | **[01-MAIN-CODE-WHERE-TO-WRITE.md](01-MAIN-CODE-WHERE-TO-WRITE.md)** | `Src/Modules/School/` (Domain, Application, Infrastructure, WebAPI) |
| **Test code** — unit tests, integration tests, architecture tests | **[02-TEST-CODE-WHERE-TO-WRITE.md](02-TEST-CODE-WHERE-TO-WRITE.md)** | `tests/` (School.UnitTests, School.IntegrationTests, School.ArchitectureTests) |

Keep main code and test code in **separate places**: main code in `Src/`, test code in `tests/`.

---

## Folder structure (test code only)

```
tests/
├── School.UnitTests/           # xUnit, Moq, FluentAssertions
│   └── Application/
│       ├── Services/           # SchoolServiceTests
│       └── Mappers/            # SchoolMapperTests
├── School.IntegrationTests/    # WebApplicationFactory, SQLite in-memory
│   └── Api/                    # SchoolWebApplicationFactory, SchoolControllerIntegrationTests
├── School.ArchitectureTests/   # NetArchTest.Rules
│   └── School/                 # CleanArchitectureTests
└── README.md                  # This file
```

## Run tests

From repo root (`school.sys`):

```bash
# All tests
dotnet test school.sys.sln

# School tests only
dotnet test tests/School.UnitTests/School.UnitTests.csproj
dotnet test tests/School.IntegrationTests/School.IntegrationTests.csproj
dotnet test tests/School.ArchitectureTests/School.ArchitectureTests.csproj
```

## What’s covered

| Project                  | Purpose |
|--------------------------|--------|
| **School.UnitTests**     | Domain/Application: `SchoolService` (Create/Get/Update/Delete, conflict, not found, internal error), `SchoolMapper` (add/update, default policy). |
| **School.IntegrationTests** | Full HTTP pipeline for `/api/v1/school`: 201 Created, 409 Conflict (duplicate email), 404 NotFound, 200 OK (list). Uses in-memory SQLite when `UseInMemoryDatabase=true`. |
| **School.ArchitectureTests** | Clean Architecture: Domain → no Infra/WebAPI; Application → no Infra/WebAPI; Repositories depend on Domain; Controllers depend on Application. |

## AI prompts for more tests

See **docs/TESTING/MASTER-TESTING-PROMPT-SCHOOL.md** for copy-paste prompts (unit, integration, regression, authorization, architecture) and the “Pro version” line for senior-level output. Scope is **school only** with the folder structure above.
