# Main Code — Where the User/Developer Writes Application Code

This file describes **where you write the real application code** (the code that runs in production).  
**Do not write this code in the `tests/` folder.**  
Test code is in a separate file: **02-TEST-CODE-WHERE-TO-WRITE.md**.

---

## How it connects

**You write the main code here (in `Src/`).**  
The **test code** lives in `tests/` in a **separate file** — and that test **already calls** your main code. The test project has a reference to the Application/Domain projects, so when you run the test, it uses the real `SchoolService` (or whatever you wrote) and checks that it behaves correctly. So: **main code here → test there calls it.**

---

## Root folder: `Src/`

All **main (production) code** for the School module lives under:

```
school.sys/
└── Src/
    └── Modules/
        └── School/
            ├── Modules.School.Domain/        ← Domain layer
            ├── Modules.School.Application/  ← Application layer
            ├── Modules.School.Infrastructure/← Infrastructure layer
            └── Modules.School.WebAPI/       ← API layer
```

---

## 1. Domain layer — `Src/Modules/School/Modules.School.Domain/`

**What you write here:** Entities, DTOs, repository interfaces, result types, errors.

| You write in | File / folder | Purpose |
|--------------|----------------|---------|
| **Entities** | `Entities/` (e.g. `School.cs`, `Language.cs`, `Policy.cs`) | Domain models. |
| **DTOs** | `DTOs/` (e.g. `SchoolAddDTO.cs`, `SchoolUpdateDTO.cs`, `SchoolDTO.cs`) | Data transfer objects for API/service. |
| **Repository interfaces** | `IRepositories/` (e.g. `ISchoolRepository.cs`, `IGenericRepository.cs`) | Contracts for data access (no implementation here). |
| **Result pattern** | `Common/Results/` (`Result.cs`, `ResultOfT.cs`, `Error.cs`, `ErrorType.cs`) | Success/failure return types. |
| **Error messages** | `Common/StaticError/` (e.g. `UserErrors.cs`) | Static error messages. |

**Example file:** `Modules.School.Domain/Entities/School.cs` — the School entity.  
**Example file:** `Modules.School.Domain/DTOs/SchoolAddDTO.cs` — DTO for creating a school.

---

## 2. Application layer — `Src/Modules/School/Modules.School.Application/`

**What you write here:** Business logic, services, mappers, service interfaces.

| You write in | File / folder | Purpose |
|--------------|----------------|---------|
| **Service interfaces** | `IServices/` (e.g. `ISchoolService.cs`) | Contract for the service. |
| **Services** | `Services/` (e.g. `SchoolService.cs`) | **Main logic** (e.g. create school, validate, call repository). |
| **Mappers** | `Mappers/` (e.g. `SchoolMapper.cs`) | Map DTOs ↔ entities. |
| **Helpers** | `Helpers/` (e.g. `TextHelper.cs`) | Shared helpers (e.g. slug generation). |
| **DI registration** | `DependencyInjectionApplication.cs` | Register services in DI. |

**Example file:** `Modules.School.Application/Services/SchoolService.cs` — create/get/update/delete school logic.  
This is the **main code** that your unit tests will test.

---

## 3. Infrastructure layer — `Src/Modules/School/Modules.School.Infrastructure/`

**What you write here:** Database, repositories implementation, migrations.

| You write in | File / folder | Purpose |
|--------------|----------------|---------|
| **DbContext** | `Persistent/SchoolDbContext.cs` | EF Core context. |
| **Repository implementations** | `Repositories/` (e.g. `SchoolRepositories.cs`, `GenericRepository.cs`) | Implement `ISchoolRepository`, `IGenericRepository`. |
| **Migrations** | `Migrations/` | EF Core migrations (often generated). |
| **DI registration** | `DependencyInjectionInfrastructure.cs` | Register DbContext and repositories. |

**Example file:** `Modules.School.Infrastructure/Repositories/SchoolRepositories.cs` — real DB access for schools.

---

## 4. WebAPI layer — `Src/Modules/School/Modules.School.WebAPI/`

**What you write here:** Controllers, API contracts, extensions for HTTP responses.

| You write in | File / folder | Purpose |
|--------------|----------------|---------|
| **Controllers** | `Controllers/V1/` (e.g. `SchoolController.cs`) | HTTP endpoints (POST/GET/PUT/DELETE). |
| **API contracts** | `Contracts/` (e.g. `ApiResponse.cs`) | Response shape (success/errors). |
| **Extensions** | `Extensions/` (e.g. `ResultExtensions.cs`, `SchoolModuleSetup.cs`) | Map Result to HTTP status, register module. |

**Example file:** `Modules.School.WebAPI/Controllers/V1/SchoolController.cs` — e.g. `POST /api/v1/school` (create school).

---

## 5. Summary: main code only

| Layer | Path (under `school.sys/Src/Modules/School/`) | What you write |
|-------|------------------------------------------------|----------------|
| **Domain** | `Modules.School.Domain/` | Entities, DTOs, interfaces, Result, errors |
| **Application** | `Modules.School.Application/` | Services, mappers, `ISchoolService`, helpers |
| **Infrastructure** | `Modules.School.Infrastructure/` | DbContext, repositories, migrations, DI |
| **WebAPI** | `Modules.School.WebAPI/` | Controllers, API contracts, extensions |

**Do not put production code in `tests/`.**  
For **where to write test code** and how to run it, see **02-TEST-CODE-WHERE-TO-WRITE.md**.
