using MyBlog.Application;
using MyBlog.Persistence;
using MyBlog.Mapper;
using MyBlog.Application.Exceptions;
using MyBlog.Infrastructure;
using Asp.Versioning;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging;
using MyBlog.API.Controllers;
using Asp.Versioning.ApiExplorer;
using Microsoft.AspNetCore.HttpLogging;
using MyBlog.Application.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
	options.SwaggerDoc("v1", new OpenApiInfo
	{
		Version = "v1",
		Title = "BLOG API",
		Description = "CQRS - Mediatr Blog API"
	});
	options.AddSecurityDefinition("Bearer", new()
	{
		 BearerFormat = "JWT",
		 Description = "JWT Authorization header using the Bearer scheme",
		 Name = "Authorization",
		 In = ParameterLocation.Header,
		 Type = SecuritySchemeType.ApiKey,
		 Scheme = "Bearer"
	});
	options.AddSecurityRequirement(new()
	{
		{
			new OpenApiSecurityScheme
			{
				Reference = new OpenApiReference
				{
					Type = ReferenceType.SecurityScheme,
					Id = "Bearer"
				}
			},
			Array.Empty<string>()
		}
	});

});

builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
builder.Configuration.AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true);

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddMapperLayer();
builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddApplicationLayer();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddLogging();

builder.Services.AddApiVersioning(config =>
{
	config.DefaultApiVersion = new ApiVersion(1, 0);
	config.AssumeDefaultVersionWhenUnspecified = true;
	config.ReportApiVersions = true;
	config.ApiVersionReader = ApiVersionReader.Combine(
		new UrlSegmentApiVersionReader(),
		new HeaderApiVersionReader("api-version")
	);
}).AddApiExplorer(options =>
{
	options.GroupNameFormat = "'v'V";
	options.SubstituteApiVersionInUrl = true;

});


var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI(options =>
	{
		options.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
	});
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.ConfigureMiddlewares();
app.UseAuthorization();

app.MapControllers();

app.Run();
