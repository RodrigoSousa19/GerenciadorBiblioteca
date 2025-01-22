using GerenciadorBiblioteca.Application.Services;
using GerenciadorBiblioteca.Core.Interfaces.Repositories;
using GerenciadorBiblioteca.Core.Interfaces.Services;
using GerenciadorBiblioteca.Infrastructure.Data;
using GerenciadorBiblioteca.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorBiblioteca.API.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddApplicationDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("GerenciadorBiblioteca");
            services.AddDbContext<GerenciadorBibliotecaDbContext>(o => o.UseSqlServer(connectionString));
            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<ILoanService, LoanService>();
            services.AddScoped<IUserService, UserService>();

            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ILoanRepository, LoanRepository>();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
