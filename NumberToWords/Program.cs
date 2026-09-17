using NumberToWords.Converters;
using NumberToWords.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseDefaultFiles();
app.UseStaticFiles();
app.UseHttpsRedirection();

app.MapPost("/convertNumberToWords", (WordConverterRequest request) => Results.Ok(WordConverter.Convert(request.Number)))
   .WithName("ConvertNumberToWords")
   .WithOpenApi();

await app.RunAsync();
