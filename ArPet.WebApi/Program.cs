using System.Net;
using ArPet.Storage;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.Configure<ScalarOptions>(options => options.HiddenClients = true);
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

builder.Services.AddDbContext<PetContext>();
builder.WebHost.ConfigureKestrel((httpClient, options) =>
{
    options.Listen(IPAddress.Any, 5008);
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<PetContext>();
    db.Database.Migrate();
}

app.MapControllers();
app.MapOpenApi();
app.MapScalarApiReference();

app.UseHttpsRedirection();
app.Run();