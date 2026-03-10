using GastosResidenciais.Domain.Repositories;
using GastosResidenciais.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GastosResidenciais.Infrastructure
{
    public static class InfrastructureModule
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddData(configuration)
                .AddRepositories();

            return services; 
        }

        private static IServiceCollection AddData(this IServiceCollection services, IConfiguration configuration)
        {
            // PostgreSQL - EF Core
            services.AddDbContext<AppDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

            return services;
        }

        private static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IPessoaRepository, PessoaRepository>();
            services.AddScoped<ICategoriaRepository, CategoriaRepository>();
            services.AddScoped<ITransacaoRepository, TransacaoRepository>();

            return services;
        }
    }
}
