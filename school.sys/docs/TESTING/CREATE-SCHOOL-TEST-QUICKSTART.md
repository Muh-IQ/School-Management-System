# Create School — Where to Write Tests & How to Run Them

**Split of responsibilities:**
- **Main (production) code** → see **01-MAIN-CODE-WHERE-TO-WRITE.md** (where to write services, controllers, entities, etc.).
- **Test code** → see **02-TEST-CODE-WHERE-TO-WRITE.md** (where to write tests and how to run them).

This quickstart focuses on **create-school tests** (test code only).

---

## 1. Where the test code lives (create-school)

**Test file:**  
`school.sys/tests/School.UnitTests/Application/Services/SchoolServiceTests.cs`

**Test class:** `SchoolServiceTests`  
**Method under test (main code):** `SchoolService.CreateAsync(SchoolAddDTO)` in `Src/Modules/School/Modules.School.Application/Services/SchoolService.cs`.

---

## 2. Create-school tests that already exist

| Test method name | What it checks |
|------------------|----------------|
| `CreateAsync_WhenContactIsUnique_ReturnsSuccess` | Create succeeds when email/phone are not taken. |
| `CreateAsync_WhenEmailExists_ReturnsConflict` | Create returns Conflict when email already exists. |
| `CreateAsync_WhenPhoneExists_ReturnsConflict` | Create returns Conflict when phone already exists. |
| `CreateAsync_WhenAddFails_ReturnsInternalServerError` | Create returns 500 when repository Add fails. |

They are in the same file, around **lines 25–121**.

---

## 3. How to run the tests

Open a terminal and go to the solution folder, then run one of these.

**Run all unit tests (including all create-school tests):**
```bash
cd school.sys
dotnet test tests/School.UnitTests/School.UnitTests.csproj
```

**Run only the create-school tests (by name filter):**
```bash
cd school.sys
dotnet test tests/School.UnitTests/School.UnitTests.csproj --filter "FullyQualifiedName~CreateAsync"
```

You should see something like:
- `Passed!  - Failed: 0, Passed: 4, ...` for the create-school tests if they all pass.
- If any fail, the output will show which test failed and why.

---

## 4. Adding your own create-school test

If you want to add another case (e.g. “when name is empty” or “when LanguageId is invalid”):

1. Open:  
   `tests/School.UnitTests/Application/Services/SchoolServiceTests.cs`
2. Add a new method like this (same pattern as the existing ones):

```csharp
[Fact]
public async Task CreateAsync_WhenYourScenario_ExpectedResult()
{
    // Arrange: build SchoolAddDTO and setup mocks
    var dto = new SchoolAddDTO
    {
        Name = "My School",
        Email = "me@school.com",
        Phone = "+1111111111",
        LanguageId = Guid.NewGuid(),
        PolicyTitle = "P",
        PolicyDescription = "D",
        PolicyType = "T"
    };

    _repositoryMock
        .Setup(r => r.AnyAsync(It.IsAny<System.Linq.Expressions.Expression<Func<SchoolEntity, bool>>>()))
        .ReturnsAsync(false);  // or true to simulate email/phone exists
    _repositoryMock
        .Setup(r => r.AddAsync(It.IsAny<SchoolEntity>()))
        .ReturnsAsync(true);   // or false to simulate DB failure

    // Act: call create
    var result = await _sut.CreateAsync(dto);

    // Assert: what you expect
    result.IsSuccess.Should().BeTrue();  // or BeFalse() and check result.Errors
}
```

3. Save the file and run again:
   ```bash
   dotnet test tests/School.UnitTests/School.UnitTests.csproj --filter "FullyQualifiedName~CreateAsync"
   ```

---

## 5. Summary

| What | Where / How |
|------|-------------|
| **Where to write** create-school tests | `tests/School.UnitTests/Application/Services/SchoolServiceTests.cs` |
| **Run all unit tests** | `dotnet test tests/School.UnitTests/School.UnitTests.csproj` |
| **Run only create-school tests** | `dotnet test tests/School.UnitTests/School.UnitTests.csproj --filter "FullyQualifiedName~CreateAsync"` |

Run from the `school.sys` folder (the folder that contains `school.sys.sln` and the `tests` folder).
