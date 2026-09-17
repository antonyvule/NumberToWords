# Number to Words

A web application that converts a decimal money amount into its English words spelling (e.g. `123.45` converted to `"ONE HUNDRED AND TWENTY-THREE DOLLARS AND FORTY-FIVE CENTS"`). The conversion algorithm and validation are designed and implemented without any third-party libraries or NuGet packages.

## Prerequisites

- .NET 8 SDK

## Project Structure

- **NumberToWords.sln**
  - Solution file (open in Visual Studio or Visual Studio Code or use the dotnet CLI)
- **NumberToWords/**
  - ASP.NET Core Minimal API + Static Web UI (Bootstrap and jQuery)
- **NumberToWords.Tests/**
  - xUnit Unit Tests
- **Design.md**
  - Design rationale and rejected alternatives
- **TestPlan.md**
  - Test plan including automated and manual testing

## Build & Run

- `dotnet build`
- `dotnet run --project NumberToWords/NumberToWords.csproj --launch-profile https`

Trust the local HTTPS development certificate (**First time only**):
`dotnet dev-certs https --trust`

The console output will print the URLs that the app is listening on by default `https://localhost:7230` and `http://localhost:5001` (see `NumberToWords/Properties/launchSettings.json`).

## Run Tests

`dotnet test`

## Using the Application

### Web UI
Open the printed URL in a browser (e.g. `https://localhost:7230`), enter a number between `0` and `999,999,999,999.99` with at most 2 decimal places, and click **Convert** or press the **Enter** key.

### Swagger UI
Navigate to `/swagger` (e.g. `https://localhost:7230/swagger`) for interactive API documentation with a **Try it out** form.

### Direct API Endpoint using NumberToWords.http

With the application running, open NumberToWords/NumberToWords.http in Visual Studio (built-in .http support) or Visual Studio Code (with the REST Client extension) and use the Send Request link above the request.

## Troubleshooting

### `dotnet dev-certs https --trust` fails (macOS)

If trusting the local HTTPS certificate fails, run the application on the `http` profile instead as functionally identical and no certificate required: `dotnet run --project NumberToWords/NumberToWords.csproj --launch-profile http`. Then open `http://localhost:5001` instead of the https URL.

## Further Documentation

- [Design.md](Design.md) - the chosen approach and alternatives considered.
- [TestPlan.md](TestPlan.md) - test scope and scenario list.