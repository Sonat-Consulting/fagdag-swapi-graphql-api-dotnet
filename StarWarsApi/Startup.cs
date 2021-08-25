using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using GraphQL.Server.Ui.Voyager;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StarWarsApi.Data;
using StarWarsApi.SchemaDefinition;

namespace StarWarsApi
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<StarWarsQuery>();
            services.AddScoped<IReviewService, ReviewService>();
            services.AddMemoryCache();
            services.AddHttpClient<IFilmService, FilmService>();

            services.AddScoped<StarWarsSchema>();

            services
                .AddGraphQL(options => options.EnableMetrics = true)
                .AddGraphTypes(ServiceLifetime.Scoped)
                .AddErrorInfoProvider(opt => opt.ExposeExceptionStackTrace = true)
                .AddSystemTextJson();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseGraphQL<StarWarsSchema>();
            app.UseGraphQLPlayground(new PlaygroundOptions());
            app.UseGraphQLVoyager(new VoyagerOptions());
        }
    }
}
