using BrouwerService.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<BierlandContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("bierland")));
builder.Services.AddScoped<IBrouwerRepository, BrouwerRepository>();
builder.Services.AddScoped<IFiliaalRepository, FiliaalRepository>();

builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options => options.SwaggerEndpoint("/openapi/v1.json", "Brouwers"));
}

app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyHeader());

app.UseAuthorization();

app.MapControllers();

app.Run();
