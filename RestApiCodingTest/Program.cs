using Microsoft.OpenApi.Models;
using RestApiCodingTest.Repository;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using RestApiCodingTest.Database.Setup;
using System.Text.Json;
using RestApiCodingTest.Validators;
using RestApiCodingTest.RequestBuilder;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "RestApiCodingTest", Version = "1" });
    c.EnableAnnotations();
});

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase; // Use camelCase for property names
    options.JsonSerializerOptions.PropertyNameCaseInsensitive = true; // Make property name comparison case-insensitive
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

builder.Services.AddDbContext<ActivityDBContext>(options =>
          options.UseSqlite("Data Source=" +
          Path.Combine(Directory.GetCurrentDirectory(), "Database\\Data\\test.db"))
);

builder.Services.AddScoped<IActivityRepository, ActivityRepository>();
builder.Services.AddScoped<IActivityValidator, ActivityValidator>();
builder.Services.AddScoped<IActivityBuilder, ActivityBuilder>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "RestApiCodingTest");
});

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();