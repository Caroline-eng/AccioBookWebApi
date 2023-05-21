using AccioBook.CrossCutting.IoC.Bootstrappers;
using AccioBook.CrossCutting.IoC.Logging;
using AccioBook.Data.Repositories;
using AccioBook.Domain.Interfaces.Repositories;
using AccioBook.Domain.Interfaces.Services;
using AccioBook.Domain.Services;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text.Json.Serialization;

namespace AccioBook.WepApi
{
    public class Startup
    {
        public IConfiguration ConfigRoot { get; }

        public Startup(IConfiguration configuration)
        {
            ConfigRoot = configuration;
        }

        public void ConfigureServices(IServiceCollection services) 
        {                      
        

            string connectionString = ConfigRoot.GetConnectionString("ClearDBConnection");

            // Configurar o serviço de banco de dados usando a string de conexão
            services.AddDbContext<DbContext>(options =>
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));


            SerilogExtension.AddLogging(ConfigRoot);
            services.AddControllers()
                    .AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);             

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen( c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "AccioBookWepApi", Version = "v1" });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            services.AddDependencies(ConfigRoot);

            services.AddTransient<IAuthorService, AuthorService>();
            services.AddTransient<IGenreService, GenreService>();
            services.AddTransient<IEditionService, EditionService>();
            services.AddTransient<ILanguageService, LanguageService>();
            services.AddTransient<IPublisherService, PublisherService>();
            services.AddTransient<IUserService, UserService>();

            services.AddTransient<IAuthorRepository, AuthorRepository>();           
            services.AddTransient<IGenreRepository, GenreRepository>();
            services.AddTransient<IEditionRepository, EditionRepository>();
            services.AddTransient<ILanguageRepository, LanguageRepository>();
            services.AddTransient<IPublisherRepository, PublisherRepository>();
            services.AddTransient<IUserRepository, UserRepository> ();

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.WithOrigins("*")
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
            });

        }

        public void Configure(WebApplication app, IWebHostEnvironment env) 
        {           
            app.UseSwagger();
            app.UseSwaggerUI(opt =>
            {
                opt.SwaggerEndpoint("/swagger/v1/swagger.json", "AccioBookWepApi V1");
            });

            app.UseRewriter(new RewriteOptions().AddRedirect("^$", "swagger"));
            app.UseHttpsRedirection();
            app.UseCors("CorsPolicy");
            app.UseAuthorization();
            app.MapControllers();
            app.Run();          
        }
    }
}
