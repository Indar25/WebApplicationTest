using Microsoft.EntityFrameworkCore;
using UserManagement.Repository;
using UserManagement.Shared.Contracts;
using UserManagement.Shared.Implementation;

var builder = WebApplication.CreateBuilder(args);

var Configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddScoped<IUserManager, UserManager>();

builder.Services.AddDbContext<UserContext>(options =>
            options.UseNpgsql(Configuration.GetConnectionString("PostgresConnection")));

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    c.RoutePrefix = string.Empty; // This serves Swagger at the root URL
});


app.UseAuthorization();

app.MapControllers();

app.Run();
