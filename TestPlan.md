# Test Plan

## Scope

- Automated unit tests for the conversion algorithm and validation rules (`NumberToWords.Tests`).
- Manual testing of the web UI, Swagger UI, the API endpoint directly. No UI testing like Playwright is automated at this stage.

## How to run
- Automated testing: 
  - `dotnet test` from the repository root.
- Manual testing: 
  - `dotnet run --project NumberToWords/NumberToWords.csproj --launch-profile https`, then work through the testing scenarios below.

## Automated Coverage (`dotnet test`)

- `WordConverterTests.Convert_ValidNumber_ReturnsCorrectWords` - the specification's own example, singular and plural `DOLLAR` and `CENT`, large mixed numbers.
- `WordConverterTests.Convert_InvalidNumber_ReturnsErrorMessage` - negative, above maximum amount allowed, too many decimal places.
- `WordConverterTests.ConvertIntegerPart_*` / `ConvertDecimalPart_*` - exact multiples of thousand/million/billion and regression cases.
- `WordConverterValidatorTests.*` - every validation rule at both edges of the valid range.
- `IntegerWordConverterTests.*` - direct word lookups and the tens and units boundary.

## Manual Testing Scenarios (Web UI at `https://localhost:7230`)

### Scenario 1 - Convert a typical amount (Happy Path)
1. Enter `123.45`.
2. Click **Convert**.
3. Check
   - Result is `ONE HUNDRED AND TWENTY-THREE DOLLARS AND FORTY-FIVE CENTS`.

### Scenario 2 - Zero amount (Edge Case)
1. Enter `0`
2. Click **Convert**.
3. Check
   - Result is `ZERO DOLLAR`.

### Scenario 3 - Singular dollar, no cents (Edge Case)
1. Enter `1`
2. Click **Convert**.
3. Check
   - Result is `ONE DOLLAR`.

### Scenario 4 - Singular cent, no dollars (Edge Case)
1. Enter `0.01`
2. Click **Convert**.
3. Check
   - Result is `ONE CENT`.

### Scenario 5 - Exact multiple of 1,000 (Regression)
1. Enter `1000`
2. Click **Convert**.
3. Check
   - Result is `ONE THOUSAND DOLLARS`.

### Scenario 6 - Maximum boundary 999,999,999,999.99 (Edge Case)
1. Enter `999999999999.99`
2. Click **Convert**.
3. Check
   - Result is returned correctly, and no validation error message showing.

### Scenario 7 - Negative number (Negative)
1. Enter `-1`
2. Click **Convert**.
3. Check
   - Result is validation error shown, no words returned.

### Scenario 8 - More than 2 decimal places (Negative)
1. Enter `1.234`
2. Click **Convert**.
3. Check
   - Result is validation error shown, no words returned.

### Scenario 9 - Above maximum 999,999,999,999.99 (Negative)
1. Enter `1000000000000`
2. Click **Convert**.
3. Check
   - Result is validation error shown, no words returned.

### Scenario 10 - Empty input (Negative)
1. Leave the field empty
2. Click **Convert**.
3. Check
   - Result is validation error shown, no words returned.

### Scenario 11 - Non-numeric input (Negative)
1. Enter `abc`
2. Check
   - Result is validation error shown, no words returned.

## Swagger UI and direct API checks
- Navigate to `https://localhost:7230/swagger`, and **Try it out** successfully calls `POST /convertNumberToWords`.
- `POST /convertNumberToWords` via `NumberToWords.http`, with a valid and an invalid body, confirms the response shape (`words`, `errorMessage`).

## Out of scope
- Automated UI testing like Playwright is not covered, only automated unit tests and manual testing.