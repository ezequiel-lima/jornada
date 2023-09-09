using Jornada.Commands.Declaracoes;
using Jornada.Handlers.Declaracoes;
using Jornada.Handlers.Interfaces;
using Jornada.Infra;
using Jornada.Infra.Data;
using Jornada.Models;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(connectionString);
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

GetServiceCollection(builder);

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

IServiceCollection GetServiceCollection(WebApplicationBuilder builder)
{
    // Adicionando serviços
    var services = builder.Services;
    services.AddScoped<IHandler<CreateDeclaracaoCommand>, CreateDeclaracaoHandler>();
    services.AddScoped<UnitOfWork>();

    return services;
}
