using System.Text.Json.Serialization;
using HR.API.Extensions;
using HR.API.Filters;
using HR.API.Middlewares;
using HR.DAL.Data;
using HR.DAL.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(
	cofig => cofig.Filters.Add(typeof(ValidateModelAttribute))
	).AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseMiddleware<ExceptionHandlingMiddleware>();

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
	var services = scope.ServiceProvider;
	var context = services.GetRequiredService<ApplicationDbContext>();
	var logger = services.GetRequiredService<ILogger<Program>>();
	var userManager = services.GetRequiredService<UserManager<AppUser>>();
	var roleManager = services.GetRequiredService<RoleManager<AppRole>>();
	try
	{
		await context.Database.MigrateAsync();
		await ApplicationDbContextSeed.SeedUser(userManager, roleManager);
		await ApplicationDbContextSeed.SeedAsync(context);
	}
	catch (Exception e)
	{
		logger.LogError(e, "--------------error--------------");
	}
}

app.Run();