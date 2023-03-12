using Microsoft.EntityFrameworkCore;
using DripChipProject.Data;
using DripChipProject.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.OpenApi.Models;
using DripChipProject.Services.ServiceInterfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication("BasicAuthentication").AddScheme<AuthenticationSchemeOptions, BasicAuthorisation>("BasicAuthentication", null);
builder.Services.AddDbContextFactory<APIDbContext>(o => o.UseSqlite());
builder.Services.AddScoped<IAccountService, AccountsService>();
builder.Services.AddScoped<IAnimalsService, AnimalsService>();
builder.Services.AddScoped<IAnimalTypesService, AnimalTypesService>();
builder.Services.AddScoped<ILocationService, LocationService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });

    // Add a security definition for basic authentication
    c.AddSecurityDefinition("basic", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "basic",
        In = ParameterLocation.Header,
        Description = "Basic Authorization header using the Bearer scheme."
    });

    // Add a security requirement for basic authentication
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "basic"
                }
            },
            new string[] {}
        }
    });
});

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
