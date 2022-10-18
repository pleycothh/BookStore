using ConsoleWebApi.Repo;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace ConsoleWebApi
{
    public class Startup
    {

        /// <summary>
        /// IServiceCollection -> DI
        /// </summary>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddTransient<CustomMiddleware>();

            services.TryAddSingleton<IProductRepository, ProductRepository>();
        }


        /// <summary>
        ///  middleware:
        /// </summary>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            /*

            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("Write from Use 1 \n");
                await next();
                await context.Response.WriteAsync("Write from Use 2 \n");
            });

            app.UseMiddleware<CustomMiddleware1>();

            app.Map("/init", CustCode);

            app.Run(async context =>
            {
                await context.Response.WriteAsync("Hello from Run 2 \n");
            });
            */

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseRouting();  //<< middleware

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void CustCode(IApplicationBuilder app)
        {
            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("Hello from init 1 \n");
            });
        }
    }
}
