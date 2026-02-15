# Master Testing Prompt – School Module Only

Use this with ChatGPT or any AI tool to generate **School module** tests for this .NET 8 Clean Architecture system. Keep scope to **school only** and use the folder structure below.

---

## 1. MASTER TESTING PROMPT (Full School System)

Copy when you want full testing coverage for the School module:

```
I am building a .NET 8 Web API using Clean Architecture (School module only).

Architecture:
- Domain Layer (Entities, ValueObjects, Business Rules)
- Application Layer (Services, Mappers, Result Pattern)
- Infrastructure Layer (EF Core, Repository Pattern)
- API Layer (Controllers + optional Global Exception Middleware)

Patterns Used:
- Result Pattern instead of throwing business exceptions
- Role-based Authorization (SuperAdmin, Admin, Teacher, Student) – when implemented
- DTOs and Repositories for School CRUD

Generate a complete professional testing strategy for the SCHOOL module including:

1) Unit tests (Domain + Application layer – Services, Mappers)
2) Integration tests (API + DB + Middleware) – school endpoints only
3) Authorization tests (when roles are in place)
4) Validation tests
5) Regression strategy
6) Edge case tests
7) Test folder structure (see below)
8) Recommended tools: xUnit, Moq, FluentAssertions, Testcontainers or SQLite in-memory
9) Example real test code for:
   - CreateSchool (success, validation failure, duplicate email/phone, DB failure)
   - GetById (success, not found)
   - Unauthorized/Forbidden when auth is added

Follow best practices for enterprise backend systems.
Think like a senior .NET architect working in a production enterprise system with high scalability and security for school-only scope.
```

---

## 2. SCHOOL TEST FOLDER STRUCTURE

Use this structure for all generated tests (school only):

```
school.sys/
├── tests/
│   ├── School.UnitTests/
│   │   ├── Application/
│   │   │   ├── Services/
│   │   │   │   └── SchoolServiceTests.cs
│   │   │   ├── Mappers/
│   │   │   │   └── SchoolMapperTests.cs
│   │   │   └── Validation/          (when you add validators)
│   │   └── Domain/                  (entities, value objects, business rules)
│   │       └── ...
│   ├── School.IntegrationTests/
│   │   └── Api/
│   │       ├── SchoolWebApplicationFactory.cs
│   │       └── SchoolControllerIntegrationTests.cs
│   └── School.ArchitectureTests/
│       └── School/
│           └── CleanArchitectureTests.cs
```

---

## 3. UNIT TEST GENERATOR PROMPT (School Class)

Use when generating unit tests for a specific School-related class:

```
Generate complete unit tests using xUnit and Moq for the following class (School module only).

Rules:
- Do NOT test infrastructure.
- Mock all dependencies (IGenericRepository<School>, ISchoolRepository, etc.).
- Cover: success case, validation failure, business rule violation, null input, edge cases.
- Use FluentAssertions.
- Test behavior, not implementation.
- Place under tests/School.UnitTests/Application/ or Domain/ as appropriate.

Here is the class:
[PASTE YOUR CLASS HERE]
```

---

## 4. INTEGRATION TEST PROMPT (School API)

Use when generating integration tests for School endpoints:

```
Generate integration tests for the School module ASP.NET Core Web API using WebApplicationFactory.

Requirements:
- Use real EF Core database (SQLite in-memory; config key: UseInMemoryDatabase = true).
- Test full HTTP pipeline for school endpoints only: /api/v1/school.
- Test: 201 Created, 400 BadRequest, 401 Unauthorized, 403 Forbidden, 404 NotFound, 409 Conflict, 500 InternalServerError.
- Use SchoolWebApplicationFactory and EnsureDbSeededAsync for default Language.
- Provide real working example code under tests/School.IntegrationTests/Api/.
Think like a senior .NET architect working in a production enterprise system.
```

---

## 5. REGRESSION + EDGE CASE PROMPT (School Feature)

Use for regression and edge cases:

```
Act as a senior backend QA engineer. Analyze this SCHOOL module feature and generate regression test scenarios.

Feature:
[Describe feature – e.g. Create School, Update School, Get by Id]

Generate:
- Edge cases (empty name, very long strings, invalid LanguageId)
- Concurrency issues (duplicate email/phone)
- Invalid state transitions
- Boundary values (paging 0, negative, huge pageSize)
- Security risks (injection, cross-school access when multi-tenant)
- Data corruption scenarios
- Performance risks

Focus on breaking the system. School module only.
```

---

## 6. AUTHORIZATION TEST PROMPT (School Roles)

Use when you add role-based auth:

```
Generate authorization tests for the School module with role hierarchy:

Roles: SuperAdmin (IT), SchoolAdmin, Teacher, Student.

Rules:
- Higher role can see lower role data where allowed.
- Lower role cannot see higher role data.
- Users cannot access other school data (when multi-tenant).
- Students can only see their own data.

Generate:
- Unit-level authorization tests (policy/requirement handlers).
- Integration HTTP tests (401/403 for school endpoints).
- Edge security cases.

School module only. Think like a senior .NET architect.
```

---

## 7. ARCHITECTURE SAFETY PROMPT (School Module)

Use to protect Clean Architecture for School:

```
Generate architecture tests that enforce (School module only):

- Domain layer must NOT reference Infrastructure or WebAPI.
- Application must NOT reference Infrastructure or WebAPI.
- No circular dependencies.
- Repositories (interfaces) are in Domain; implementations only in Infrastructure.

Use NetArchTest.Rules. Place under tests/School.ArchitectureTests/School/.
Think like a senior .NET architect.
```

---

## 8. WHAT TO COVER (School – Important Testing Types)

| Type                  | What to cover (School) |
|-----------------------|------------------------|
| Unit                  | SchoolService, mappers, domain rules |
| Integration           | Full request pipeline for /api/v1/school |
| Authorization         | Role security (when implemented) |
| Validation            | DTOs, required fields, email/phone format |
| Middleware            | Global exception handling (when added) |
| Regression            | Prevent breaking existing school CRUD |
| Architecture         | Clean layers, no forbidden references |
| Edge / Boundary       | Duplicate email/phone, not found, DB failure |

---

## 9. PRO VERSION LINE

Add this at the end of any prompt when you want senior-level output:

```
Think like a senior .NET architect working in a production enterprise system with high scalability and security. Scope: School module only. Use the folder structure: tests/School.UnitTests, tests/School.IntegrationTests, tests/School.ArchitectureTests.
```

---

## 10. QUICK REFERENCE – THIS REPO

- **Unit tests:** `school.sys/tests/School.UnitTests/` (xUnit, Moq, FluentAssertions)
- **Integration tests:** `school.sys/tests/School.IntegrationTests/` (WebApplicationFactory, SQLite in-memory)
- **Architecture tests:** `school.sys/tests/School.ArchitectureTests/` (NetArchTest.Rules)
- **Run all:** `dotnet test school.sys/school.sys.sln`
