using Jornada.Commands.Declaracoes;
using Jornada.Commands.Destinos;
using Jornada.Handlers.Declaracoes;
using Jornada.Handlers.Destinos;
using Jornada.Handlers.Interfaces;
using Jornada.Infra.Data.Repositories;
using Jornada.Infra.Data;

namespace Jornada.Infra
{
    public static class Register
    {
        public static void RegisterApplication(this IServiceCollection services)
        {
            services.AddScoped(typeof(IApplicationRepository<>), typeof(ApplicationRepository<>));
            services.AddScoped(typeof(IDestinoRepository), typeof(DestinoRepository));
            services.AddScoped<IHandler<CreateDeclaracaoCommand>, CreateDeclaracaoHandler>();
            services.AddScoped<IHandler<UpdateDeclaracaoCommand>, UpdateDeclaracaoHandler>();
            services.AddScoped<IHandler<DeleteDeclaracaoCommand>, DeleteDeclaracaoHandler>();
            services.AddScoped<IHandler<CreateDestinoCommand>, CreateDestinoHandler>();
            services.AddScoped<IHandler<UpdateDestinoCommand>, UpdateDestinoHandler>();
            services.AddScoped<IHandler<DeleteDestinoCommand>, DeleteDestinoHandler>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
