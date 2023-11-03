using AplicacaoApi;
using DominioApi.Interfaces;
using InfraApi.Contexto;
using InfraApi.Repositorio;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();


builder.Services.AddEntityFrameworkNpgsql()
    .AddDbContext<DbContexto>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("Postgres")));

builder.Services.AddScoped<IRepositorioBase, RepositorioBase>();
builder.Services.AddScoped<IBancoRepositorio, BancoRepositorio>();
builder.Services.AddScoped<IBoletoRepositorio, BoletoRepositorio>();
builder.Services.AddScoped<IBoletoAplicacao, BoletoAplicacao>();
builder.Services.AddScoped<IBancoAplicacao, BancoAplicacao>();
builder.Services.AddAutoMapper(typeof(BoletoAplicacao));
builder.Services.AddAutoMapper(typeof(BancoAplicacao));


builder.Services.AddAuthentication(x =>
    {
        x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    }).AddJwtBearer(options =>
        {
            options.RequireHttpsMetadata = false;
            options.SaveToken = true;
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration["Secret"])),
                ValidateIssuer = false,
                ValidateAudience = false
            };
        });


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
    x =>
    {
        x.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            Name = "Authorization",
            In = ParameterLocation.Header,
            Type = SecuritySchemeType.ApiKey,
            Scheme = "Bearer"
        });

        x.AddSecurityRequirement(new OpenApiSecurityRequirement()
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    },
                        Scheme = "oauth2",
                        Name = "Bearer",
                        In = ParameterLocation.Header,
                },
                new List<string>()
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

app.UseAuthentication();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
