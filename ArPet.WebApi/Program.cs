using ArPet.Storage;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddOpenApi();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

builder.Services.AddDbContext<PetContext>();

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