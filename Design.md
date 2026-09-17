# Design

## Approach

- Split the integer part into billion/million/thousand/hundred groups so the same grouping logic can be reused, and the decimal part (cents) is handled the same way. Dollars and cents are used as the currency units per the example. Certain numbers (1 to 20, and multiples of ten) map to a unique word that is reused wherever that number appears.
- Validation assumes the primary use case is converting a valid money amount to words. As a result, it rejects negative numbers, allows at most 2 decimal places, and caps the maximum at 999,999,999,999.99. That ceiling could be raised further if a larger range were needed.
- A single ASP.NET Core minimal API endpoint is used instead of an MVC controller, for simplicity, performance, and minimal configuration.
- Conversion and validation logic is implemented as static, stateless, pure functions, avoiding the added complexity of interfaces or dependency injection, since each has only one implementation.

## Reason

- Matches the requirement to implement the algorithm independently, without any third-party libraries or NuGet packages.
- Grouping and using unique words is simple to write, read, and test.

## Alternatives Considered & Rejected

- A multi-currency design is not implemented, since the specification only requires USD (i.e. dollars and cents), so building it would add complexity with no corresponding need.
- No interfaces or dependency injection are used for the converter or validator, since both are pure functions, so adding them would add complexity without a corresponding benefit.
- No UI testing like Playwright is implemented for this at this stage as there is only a single input and a submit button.