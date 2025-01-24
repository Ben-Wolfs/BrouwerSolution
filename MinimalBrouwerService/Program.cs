using MinimalBrouwerService.Repositories;
using Microsoft.EntityFrameworkCore;
using MinimalBrouwerService.Repositories;
using MinimalBrouwerService.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<BierlandContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("bierland")));
builder.Services.AddScoped<IBrouwerRepository, BrouwerRepository>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options => options.SwaggerEndpoint("/openapi/v1.json", "Brouwers"));
}

app.MapGet("geluk", () => 7);
app.MapGet("kwadraat/{getal}", (int getal) => getal * getal);

var groep = app.MapGroup("/brouwers"); 
groep.MapGet("", async (IBrouwerRepository repository) => 
 await repository.FindAllAsync());
groep.MapGet("{id}", async (int id, IBrouwerRepository repository) => 
 await repository.FindByIdAsync(id) is Brouwer brouwer ? Results.Ok(brouwer) :
 Results.NotFound());
groep.MapGet("naam", async (string begin, IBrouwerRepository repository) => 
 await repository.FindByBeginNaamAsync(begin));
groep.MapDelete("{id}", VerwijderBrouwer); 
groep.MapPost("", VoegBrouwerToe).WithParameterValidation(); 
groep.MapPut("{id}", WijzigBrouwer).WithParameterValidation();



app.Run();

async Task<IResult> VerwijderBrouwer(int id, IBrouwerRepository repository)
{
    var brouwer = await repository.FindByIdAsync(id);
    if (brouwer == null)
    {
        return Results.NotFound();
    }
    await repository.DeleteAsync(brouwer);
    return Results.Ok();
}

async Task<IResult> VoegBrouwerToe(Brouwer brouwer, IBrouwerRepository repository)
{
    await repository.InsertAsync(brouwer);
    return Results.Created($"brouwers/{brouwer.Id}", null);
}

async Task<IResult> WijzigBrouwer(int id,Brouwer brouwer,IBrouwerRepository repository)
{
    try
    {
        brouwer.Id = id;
        await repository.UpdateAsync(brouwer);
        return Results.Ok();
    } catch (DbUpdateConcurrencyException)
    {
        return Results.NotFound();
    } catch
    {
        return Results.Problem();
    }
}
