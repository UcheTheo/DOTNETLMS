using Asp.Versioning;
using FluentValidation;
using FluentValidation.AspNetCore;
using LMS_DATA_SERVICE.Data;
using LMS_DATA_SERVICE.IConfiguration;
using LMS_ENTITIES.Validators;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Configure serilog for logging
builder.Host.UseSerilog((context, loggerConfig) =>
	loggerConfig.ReadFrom.Configuration(context.Configuration));

// Add DbContext
builder.Services.AddDbContext<LMSDbContext>(options =>
{
	var lmsConn = builder.Configuration.GetConnectionString("LMSConn");
	options.UseSqlServer(lmsConn);
});

// Configure UnitOfWork
builder.Services.AddScoped<ILMSUnitOfWork, LMSUnitOfWork>();

// Configure the API versioning
builder.Services.AddApiVersioning(options =>
{
	// Provide to the client the different Api versions that we have
	options.ReportApiVersions = true;

	// This will allow the api to automatically provide a default version
	options.AssumeDefaultVersionWhenUnspecified = true;
	options.DefaultApiVersion = new ApiVersion(1, 0);
});

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();

builder.Services.AddValidatorsFromAssemblyContaining<UserValidator>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseSerilogRequestLogging();

app.UseAuthorization();

app.MapControllers();

app.Run();
