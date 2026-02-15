# Unit Testing Guide — What Happens & How to Write Your Own

This guide explains **what unit testing is** in this project, **what happens** when tests run, and **how to write and run your own tests** so you (or another developer) can see clearly if they **pass** or **fail**.

---

## 1. What is a unit test?

A **unit test** checks **one small piece of behavior** of your code (e.g. one method) in **isolation**. We do **not** use the real database, real HTTP, or real external services. We **mock** (fake) those dependencies so the test only verifies the logic you care about.

- **Pass** = the code behaved as the test expected.  
- **Fail** = the code did something different (bug or the test expectation is wrong).

---

## 2. What happens when you run unit tests?

When you run unit tests, this is what happens step by step:

1. **Test runner starts** (e.g. xUnit).
2. **It finds all test methods** (methods marked with `[Fact]` or `[Theory]`).
3. **For each test:**
   - It creates a **fresh** test class instance (so each test is independent).
   - It runs the **constructor** (e.g. creates mocks and the class under test).
   - It runs the **test method** (Arrange → Act → Assert).
   - If any **assertion fails** or an **exception** is thrown → test **fails**.
   - If all assertions pass and no exception → test **passes**.
4. **At the end** you see a summary: how many **Passed**, how many **Failed**, and for failures you get the **error message and stack trace**.

So: **“Developer checks if it’s passed or failed”** = run the tests and look at that summary and at any failure details.

---

## 3. The three steps in every unit test: Arrange, Act, Assert

Every good unit test has three clear parts:

| Step      | What you do |
|----------|--------------|
| **Arrange** | Set up the input data and configure mocks (what the dependencies return). |
| **Act**     | Call the one method you are testing. |
| **Assert**  | Check that the result (or side effects) are what you expect. |

If the **Act** step does what you expect, your **Assert** steps pass and the test **passes**. If not, one of the asserts fails and the test **fails**.

---

## 4. Example from this project: what the test is doing

Here is one of the existing tests, with comments showing **Arrange / Act / Assert** and what “pass/fail” means.

```csharp
[Fact]
public async Task CreateAsync_WhenEmailExists_ReturnsConflict()
{
    // ========== ARRANGE ==========
    // 1. Input: a DTO that would create a school
    var dto = new SchoolAddDTO
    {
        Name = "Test School",
        Email = "existing@test.com",
        Phone = "+1234567890",
        LanguageId = Guid.NewGuid(),
        PolicyTitle = "P",
        PolicyDescription = "D",
        PolicyType = "T"
    };

    // 2. Mock: when the service checks "does this email exist?", we say YES
    _repositoryMock
        .Setup(r => r.AnyAsync(It.IsAny<Expression<Func<SchoolEntity, bool>>>()))
        .ReturnsAsync(true);

    // ========== ACT ==========
    // 3. Call the real method we are testing
    var result = await _sut.CreateAsync(dto);

    // ========== ASSERT ==========
    // 4. We expect: failure, with exactly one error, type Conflict, message contains the email
    result.IsSuccess.Should().BeFalse();
    result.Errors.Should().ContainSingle(e => e.ErrorType == ErrorType.Conflict);
    result.Errors[0].Message.Should().Contain("existing@test.com");
}
```

- **If** `CreateAsync` correctly returns a failure with Conflict and that message → all `Should()` checks pass → **test passes**.  
- **If** `CreateAsync` returns success, or a different error type, or a different message → one of the `Should()` calls throws → **test fails** and the runner shows which assertion failed.

So when a developer runs this test, they are literally checking: “When the repository says email exists, does `CreateAsync` return Conflict and the right message?” Pass/fail answers that.

---

## 5. How to write your own unit test

### Step 1: Decide what you are testing

- **What class?** (e.g. `SchoolService`, `SchoolMapper`, a new service).  
- **What method?** (e.g. `CreateAsync`, `GetByIdAsync`).  
- **What situation?** (e.g. “when email already exists”, “when id not found”).

The test method name should reflect that, e.g.  
`CreateAsync_WhenEmailExists_ReturnsConflict`  
→ “When I call CreateAsync and email exists, it returns Conflict.”

### Step 2: Create or open a test class

- **Place:** under `tests/School.UnitTests/Application/` (e.g. `Services/` or `Mappers/`).
- **Class:** one test class per “unit” (e.g. `SchoolServiceTests` for `SchoolService`).
- **Constructor:** create mocks and the instance under test (the “system under test”, often named `_sut`).

Example skeleton:

```csharp
using FluentAssertions;
using Moq;
using Xunit;
// ... your project and domain usings

namespace School.UnitTests.Application.Services;

public class MyServiceTests
{
    private readonly Mock<IMyRepository> _repoMock;
    private readonly MyService _sut;

    public MyServiceTests()
    {
        _repoMock = new Mock<IMyRepository>();
        _sut = new MyService(_repoMock.Object);
    }

    [Fact]
    public async Task MyMethod_WhenSomething_DoesSomething()
    {
        // Arrange
        // Act
        // Assert
    }
}
```

### Step 3: Arrange

- Build the **input** (DTOs, IDs, etc.).
- **Setup mocks** so that when your method calls a dependency, the mock returns what you need for this scenario.

Example:

```csharp
var id = Guid.NewGuid();
_repoMock.Setup(r => r.GetByIdAsync(id)).ReturnsAsync((MyEntity?)null);
```

### Step 4: Act

- Call **only** the method you are testing.
- Store the result if you need to assert on it.

```csharp
var result = await _sut.GetByIdAsync(id);
```

### Step 5: Assert

- Use **FluentAssertions** (`result.Should()....`) to state what must be true.
- If any `Should()` fails, the test **fails** and the runner shows the message.

Examples:

```csharp
result.IsSuccess.Should().BeFalse();
result.Errors.Should().ContainSingle(e => e.ErrorType == ErrorType.NotFound);

// Or for a successful result:
result.IsSuccess.Should().BeTrue();
result.Value.Name.Should().Be("Expected Name");
```

### Step 6: Run the test

- From repo root (e.g. `school.sys`):
  - All unit tests:  
    `dotnet test tests/School.UnitTests/School.UnitTests.csproj`
  - One test by name (filter):  
    `dotnet test tests/School.UnitTests/School.UnitTests.csproj --filter "FullyQualifiedName~CreateAsync_WhenEmailExists_ReturnsConflict"`
- In the IDE: run the test (e.g. green play) or “Run All Tests” and check the test list for ✅ pass / ❌ fail.

So: **you write the test, then you (or the developer) run it and check pass/fail in the runner or IDE.**

---

## 6. How do developers check if tests passed or failed?

### Option A: Command line

```bash
cd school.sys
dotnet test tests/School.UnitTests/School.UnitTests.csproj
```

You get output like:

- **All pass:**  
  `Passed!  - Failed: 0, Passed: 13, Skipped: 0, Total: 13`
- **Some fail:**  
  `Failed!  - Failed: 2, Passed: 11, ...`  
  plus for each failed test:
  - Test name
  - Error message (e.g. which `Should()` failed)
  - Stack trace (file and line)

So “developer checks” = run this and look at **Failed** count and the failure messages.

### Option B: IDE (Visual Studio / Rider / VS Code)

- Open Test Explorer / Test view.
- Run all tests or a single test.
- **Green (passed)** vs **Red (failed)**.
- Click a failed test to see the same error message and stack trace.

### Option C: Pull request / CI

- Pipeline runs `dotnet test ...` on every push or PR.
- If any test fails, the build/report shows **failed** and usually lists failed tests.
- So “check if passed or failed” = look at the pipeline status and the test report.

---

## 7. Pass vs fail: what it means

| Result | Meaning |
|--------|--------|
| **Pass** | For the inputs and mocks you set up, the method did what you asserted. The test is satisfied. |
| **Fail** | Either (1) the code has a bug, or (2) the test expectation is wrong or outdated. You fix code or test until the test passes. |

So when you write your own test:

1. You describe the **expected behavior** in Arrange/Act/Assert.
2. You run the test.
3. **Pass** = behavior matches. **Fail** = you get a clear message and line number to fix either the code or the test.

---

## 8. Quick reference: where things live

| What | Where |
|------|--------|
| Unit test project | `school.sys/tests/School.UnitTests/` |
| Test classes for services | `School.UnitTests/Application/Services/` |
| Test classes for mappers | `School.UnitTests/Application/Mappers/` |
| Run all unit tests | `dotnet test tests/School.UnitTests/School.UnitTests.csproj` |
| Assertions | Use `FluentAssertions`: `result.Should().BeTrue()`, `.ContainSingle()`, etc. |
| Mocks | Use `Moq`: `_mock.Setup(...).ReturnsAsync(...)` |

---

## 9. Summary

- A **unit test** checks one behavior in isolation using mocks.
- **What happens when you run tests:** the runner runs each test (Arrange → Act → Assert); if every assertion passes, the test **passes**; if one fails, the test **fails** and you see why.
- **Writing your own:** pick class/method/scenario → Arrange (input + mocks) → Act (call the method) → Assert (`Should()....`).
- **Checking pass/fail:** run `dotnet test` or use the IDE test runner; **Passed** / **Failed** and the failure output tell you if the behavior is correct or needs a fix.

This is how you and other developers can write unit tests and clearly see whether they pass or fail.
