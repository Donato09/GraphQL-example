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

            //register the repository and context
            services.AddTransient(typeof(DbContext), typeof(TrulliContext));
            services.AddTransient<IPropertyRepository, PropertyRepository>();
            services.AddTransient<ITrulloRepository, TrulloRepository>();

            services.AddInMemorySubscriptions();

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
                .AddQueryType<Query>()
                .AddMutationType<Mutation>()
                .AddSubscriptionType<Subscription>()
                .AddFiltering()
                .AddSorting();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, TrulliContext db)
        {
            if (env.IsDevelopment())
            {
                app.UsePlayground();
            }

            //preload db
            db.EnsureSeedData();

            app.UseWebSockets();

            app.UseRouting();

            // routing area
            app.UseEndpoints(endpoints => 
            {
                endpoints.MapGraphQL();
            });
        }
    }
}
