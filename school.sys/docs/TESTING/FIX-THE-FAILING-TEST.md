# Fix the Failing Test — Practice

A **CreateSchool** unit test is currently failing on purpose so you can practice fixing it and running the test.

---

## 1. Run the test (see it fail)

From the **school.sys** folder in a terminal:

```bash
cd school.sys
dotnet test tests/School.UnitTests/School.UnitTests.csproj --filter "FullyQualifiedName~CreateAsync_WhenEmailExists_ReturnsConflict"
```

You should see something like:

- **Failed** – one test failed.
- Error message similar to:  
  `Expected result.Errors[0].Message to contain "existing@test.com", but the message was "The operation could not be completed due to a conflict."`

So the test expects the **conflict message to include the duplicate email** (`existing@test.com`), but the code is returning a generic message without it.

---

## 2. What to fix

The bug is in the **main code**, not in the test.

- **File:** `Src/Modules/School/Modules.School.Domain/Common/StaticError/UserErrors.cs`
- **Method:** `ConflictMessage`
- **When** `ExistsEmail` is not null, the method should return a message **that includes the email** (so the API/client can show which email caused the conflict).
- **Right now** it returns a generic string: `"The operation could not be completed due to a conflict."` with **no** email in it.

**Fix:** In the `ExistsEmail` branch, return a message that **includes** `ExistsEmail` in the string, for example:

- `$"The operation could not be completed due to a conflict with entity with email '{ExistsEmail}'"`

(Or any message that contains the email so the test’s `.Contain("existing@test.com")` passes.)

---

## 3. How to test your fix

**Option A – Command line (only this test)**

```bash
cd school.sys
dotnet test tests/School.UnitTests/School.UnitTests.csproj --filter "FullyQualifiedName~CreateAsync_WhenEmailExists_ReturnsConflict"
```

- If you see **Passed!** and **Failed: 0**, the fix is correct.

**Option B – Command line (all CreateSchool unit tests)**

```bash
cd school.sys
dotnet test tests/School.UnitTests/School.UnitTests.csproj --filter "FullyQualifiedName~CreateAsync"
```

- All 4 CreateAsync tests should pass.

**Option C – Command line (all unit tests)**

```bash
cd school.sys
dotnet test tests/School.UnitTests/School.UnitTests.csproj
```

- Every unit test in the project should pass.

**Option D – In the IDE**

- Open Test Explorer / Test view.
- Find **CreateAsync_WhenEmailExists_ReturnsConflict** (under School.UnitTests → Application → Services → SchoolServiceTests).
- Run that test (or run all tests).
- Before fix: test is red (failed). After fix: test is green (passed).

---

## 4. Summary

| Step | What to do |
|------|------------|
| **See the failure** | Run the test with the filter above; you should see one failed test and the message about `"existing@test.com"`. |
| **Fix** | In `UserErrors.cs`, in `ConflictMessage`, when `ExistsEmail != null`, return a string that **includes** `ExistsEmail` (e.g. the original message with the email). |
| **Verify** | Run the same test again (or all CreateAsync / all unit tests); it should pass. |

Once the test passes, you’ve fixed the bug. You can remove the `// BUG (for practice)` comment in `UserErrors.cs` if you want.
