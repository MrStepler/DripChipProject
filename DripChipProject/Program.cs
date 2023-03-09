using Microsoft.EntityFrameworkCore;
using DripChipProject.Data;
using DripChipProject.Services;

var builder = WebApplication.CreateBuilder(args);





builder.Services.AddDbContextFactory<APIDbContext>(o => o.UseSqlite());
builder.Services.AddScoped<IAccountService, AccountsService>();
builder.Services.AddScoped<IAnimalsService, AnimalsService>();
builder.Services.AddScoped<IAnimalTypesService, AnimalTypesService>();
builder.Services.AddScoped<ILocationService, LocationService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();
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
