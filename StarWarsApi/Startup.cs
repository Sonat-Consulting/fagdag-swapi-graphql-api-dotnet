using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StarWarsApi.Data;
using StarWarsApi.SchemaDefinition;

namespace StarWarsApi
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<StarWarsQuery>();
            services.AddScoped<IFilmsReposity, FilmsRepository>();
            services.AddHttpClient<IFilmService, FilmService>();

            services.AddScoped<StarWarsSchema>();

            services
                .AddGraphQL(options => options.EnableMetrics = true)
                .AddGraphTypes(ServiceLifetime.Scoped)
                .AddErrorInfoProvider(opt => opt.ExposeExceptionStackTrace = true)
                .AddSystemTextJson();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseGraphQL<StarWarsSchema>();

            app.UseGraphQLPlayground(new PlaygroundOptions());

            // app.UseRouting();
            //
            // app.UseEndpoints(endpoints =>
            // {
            //     endpoints.MapGet("/", async context => { await context.Response.WriteAsync("Hello World!"); });
            // });
        }
    }
}
