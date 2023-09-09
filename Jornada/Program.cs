using Jornada.Commands.Declaracoes;
using Jornada.Handlers.Declaracoes;
using Jornada.Handlers.Interfaces;
using Jornada.Infra;
using Jornada.Infra.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

ConfigureServices(builder);
GetServiceCollection(builder);

var app = builder.Build();

app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

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
    var services = builder.Services;
    services.AddScoped<IHandler<CreateDeclaracaoCommand>, CreateDeclaracaoHandler>();
    services.AddScoped<IHandler<UpdateDeclaracaoCommand>, UpdateDeclaracaoHandler>();
    services.AddScoped<IHandler<DeleteDeclaracaoCommand>, DeleteDeclaracaoHandler>();
    services.AddScoped<UnitOfWork>();

    return services;
}

void ConfigureServices(WebApplicationBuilder builder)
{
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
}