using GenericController.Appliction.API.Context;
using GenericController.Appliction.API.Services.Application;
using GenericController.Appliction.API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<SQLServerContext>
    (options => options.UseSqlServer(builder.Configuration.GetConnectionString("SQLServerConnection")));

// Dependency Injection
builder.Services.AddScoped<IUserService, UserService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
