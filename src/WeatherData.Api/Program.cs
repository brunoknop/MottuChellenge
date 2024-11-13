using WeatherData.Api.Filters;
using WeatherData.Application;
using WeatherData.Domain.Entities;
using WeatherData.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<ExternalApiSettings>(
    builder.Configuration.GetSection("ExternalApiSettings"));

var externalApiSettings = builder.Configuration
                                 .GetSection("ExternalApiSettings")
                                 .Get<ExternalApiSettings>();

builder.Services.AddSingleton(externalApiSettings);

builder.Services.AddHttpClient();

builder.Services.AddMvc(option => option.Filters.Add(typeof(ExceptionFilter)));
builder.Services.AddRouting(option => option.LowercaseUrls = true);

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
