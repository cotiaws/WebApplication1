using Azure.Identity;
using WebApplication1.Controllers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

try
{
    builder.Configuration.AddAzureKeyVault(
        new Uri("https://coti.vault.azure.net/"),
        new DefaultAzureCredential()
    );
}
catch (Exception ex)
{
    Console.WriteLine("Erro ao acessar o Key Vault: " + ex.Message);
}


string connectionString = builder.Configuration["DbConnection"];

builder.Services.AddScoped<Teste>(map => new Teste(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
