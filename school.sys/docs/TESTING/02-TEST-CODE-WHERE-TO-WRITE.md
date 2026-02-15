# Test Code — Where the User/Developer Writes Tests

This file describes **where you write test code only** (unit tests, integration tests, architecture tests).  
**Do not put production/application code here.**  
Main (production) code is in a separate file: **01-MAIN-CODE-WHERE-TO-WRITE.md**.

---

## How it connects

**You write the test code here (in `tests/`).**  
The **main code** you wrote lives in `Src/` in a **separate place** — and the test **calls** that code. For example, `SchoolServiceTests` creates a `SchoolService` (your main code) and calls `CreateAsync(dto)` on it; then the test checks the result. So: **main code is there (`Src/`) → test is here (`tests/`) and already calls it.**

---

## Root folder: `tests/`

All **test code** lives under:

```
school.sys/
└── tests/
    ├── School.UnitTests/           ← Unit tests (services, mappers)
    ├── School.IntegrationTests/    ← API/HTTP tests
    └── School.ArchitectureTests/   ← Architecture rules (NetArchTest)
```

---

## 1. Unit tests — `tests/School.UnitTests/`

**What you write here:** Tests for Domain and Application logic (services, mappers).  
**No production code.** Only test classes and test methods.

### Folder structure

| You write in | Path | Purpose |
|--------------|------|---------|
| **Service tests** | `School.UnitTests/Application/Services/` | Test `SchoolService`, `LanguageService`, etc. |
| **Mapper tests** | `School.UnitTests/Application/Mappers/` | Test `SchoolMapper` and other mappers. |
| **Domain tests** (optional) | `School.UnitTests/Domain/` | Test entities, value objects, domain rules. |

### Example: create-school unit tests

**File:** `tests/School.UnitTests/Application/Services/SchoolServiceTests.cs`

- **Class:** `SchoolServiceTests`
- **What it tests:** `SchoolService.CreateAsync`, `GetByIdAsync`, `UpdateAsync`, `DeleteAsync`, etc.
- **You add:** New `[Fact]` methods for new scenarios (e.g. another Create case).

**Example of what you write in this file (test code only):**

```csharp
[Fact]
public async Task CreateAsync_WhenYourScenario_ExpectedResult()
{
    // Arrange
    var dto = new SchoolAddDTO { Name = "X", Email = "x@x.com", Phone = "+1", LanguageId = Guid.NewGuid(), PolicyTitle = "P", PolicyDescription = "D", PolicyType = "T" };
    _repositoryMock.Setup(r => r.AnyAsync(It.IsAny<Expression<Func<SchoolEntity, bool>>>())).ReturnsAsync(false);
    _repositoryMock.Setup(r => r.AddAsync(It.IsAny<SchoolEntity>())).ReturnsAsync(true);

    // Act
    var result = await _sut.CreateAsync(dto);

    // Assert
    result.IsSuccess.Should().BeTrue();
}
```

### Example: mapper tests

**File:** `tests/School.UnitTests/Application/Mappers/SchoolMapperTests.cs`

- **Class:** `SchoolMapperTests`
- **What it tests:** `SchoolMapper.MapSchoolAddDTOToEntity`, `MapSchoolUpdateDTOToEntity`.
- **You add:** New `[Fact]` methods for new mapping scenarios.

---

## 2. Integration tests — `tests/School.IntegrationTests/`

**What you write here:** Tests that call the real API (HTTP) with a test database.  
**No production code.** Only test classes, test factory, and test methods.

| You write in | Path | Purpose |
|--------------|------|---------|
| **Factory** | `School.IntegrationTests/Api/SchoolWebApplicationFactory.cs` | Configures the test host (e.g. in-memory DB). |
| **API tests** | `School.IntegrationTests/Api/SchoolControllerIntegrationTests.cs` | HTTP tests (POST/GET, 201, 404, 409, etc.). |

**Example of what you write (test code only):**

```csharp
[Fact]
public async Task CreateSchool_WithValidDto_Returns201Created()
{
    await _factory.EnsureDbSeededAsync();
    var dto = new SchoolAddDTO { ... };
    var response = await _client.PostAsJsonAsync("/api/v1/school", dto);
    response.StatusCode.Should().Be(HttpStatusCode.Created);
}
```

---

## 3. Architecture tests — `tests/School.ArchitectureTests/`

**What you write here:** Rules that enforce Clean Architecture (who can reference who).  
**No production code.** Only test classes with `[Fact]` and NetArchTest rules.

| You write in | Path | Purpose |
|--------------|------|---------|
| **Architecture rules** | `School.ArchitectureTests/School/CleanArchitectureTests.cs` | e.g. Domain must not reference Infrastructure. |

---

## 4. How to run the test code

From the **school.sys** folder (where `school.sys.sln` and `tests/` are):

| What to run | Command |
|-------------|---------|
| **All unit tests** | `dotnet test tests/School.UnitTests/School.UnitTests.csproj` |
| **Only create-school unit tests** | `dotnet test tests/School.UnitTests/School.UnitTests.csproj --filter "FullyQualifiedName~CreateAsync"` |
| **All integration tests** | `dotnet test tests/School.IntegrationTests/School.IntegrationTests.csproj` |
| **All architecture tests** | `dotnet test tests/School.ArchitectureTests/School.ArchitectureTests.csproj` |
| **All tests** | `dotnet test school.sys.sln` |

Pass = tests passed. Fail = see the reported failing test and message.

---

## 5. Summary: test code only

| Test type | Where you write (under `school.sys/tests/`) | What you write |
|-----------|--------------------------------------------|----------------|
| **Unit** | `School.UnitTests/Application/Services/`, `Mappers/` | Test classes with `[Fact]`, mocks, Arrange/Act/Assert |
| **Integration** | `School.IntegrationTests/Api/` | Factory + test classes that call HTTP API |
| **Architecture** | `School.ArchitectureTests/School/` | Test classes with NetArchTest rules |

**Do not put application/domain/infrastructure/API implementation in `tests/`.**  
For **where to write main (production) code**, see **01-MAIN-CODE-WHERE-TO-WRITE.md**.
