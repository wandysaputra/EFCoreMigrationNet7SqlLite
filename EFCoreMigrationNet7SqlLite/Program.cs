using EFCoreMigrationNet7SqlLite.DbContexts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// register the DbContext on the Container, it's on Scope lifetime
// https://learn.microsoft.com/en-us/ef/core/dbcontext-configuration/

// To add migration script
// PM> add-migration InitialMigration
// PS> dotnet ef migrations add InitialMigration

// To update database
// PM> update-database
// PS> dotnet ef database update
builder.Services.AddDbContext<BooksContext>(options =>
    options.UseSqlite(
        builder.Configuration.GetConnectionString("BooksDBConnectionString"))
);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();