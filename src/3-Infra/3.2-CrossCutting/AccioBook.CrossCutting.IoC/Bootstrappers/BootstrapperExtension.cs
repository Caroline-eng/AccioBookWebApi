using AccioBook.Data.Contexts;
using AccioBook.Data.Repositories;
using AccioBook.Domain.Interfaces.Repositories;
using AccioBook.Domain.Interfaces.Services;
using AccioBook.Domain.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AccioBook.CrossCutting.IoC.Bootstrappers
{
    public static class BootstrapperExtension
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services, IConfiguration configuration)
        {

            var connStr = configuration.GetConnectionString("AccioBookDatabase");
            services.AddDbContext<AccioBookContext>(ops => ops.UseMySql(connStr, ServerVersion.AutoDetect(connStr)));

            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IBookService, BookService>();

            return services;
        }



    }
}
