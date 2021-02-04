using HotChocolate;
using HotChocolate.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TrulliManager.Database;
using TrulliManager.Repository.Abstract;
using TrulliManager.Repository.Concrete;
using TrulliManager.Types.Property;
using TrulliManager.Types.Trullo;

namespace TrulliManager
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<TrulliContext>(options => options.UseSqlServer(Configuration.GetConnectionString("TrulliContext")));

            //services.AddSingleton<IPropertyRepository, PropertyRepository>();
            //services.AddSingleton<ITrulloRepository, TrulloRepository>();

            //register the repository and context
            services.AddTransient<IPropertyRepository, PropertyRepository>();
            services.AddTransient<ITrulloRepository, TrulloRepository>();
            services.AddTransient(typeof(DbContext), typeof(TrulliContext));

            services.AddScoped<IPropertyRepository, PropertyRepository>();
            services.AddScoped<ITrulloRepository, TrulloRepository>();

            services.AddScoped<TrulliContext>();
            services.AddScoped<TrulloType>();
            services.AddScoped<PropertyType>();
            services.AddScoped<Query>();
            services.AddScoped<Mutation>();

            services
                .AddRouting()
                .AddGraphQLServer()
                .AddQueryType<QueryType>()
                .AddMutationType<Mutation>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, TrulliContext db)
        {
            if (env.IsDevelopment())
            {
                app.UsePlayground();
            }

            app.UseRouting();

            // routing area
            app.UseEndpoints(endpoints => 
            {
                endpoints.MapGraphQL();
            });

            //preload db
            db.EnsureSeedData();
        }
    }
}
