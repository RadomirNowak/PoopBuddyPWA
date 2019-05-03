using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.DependencyInjection;
using WebEssentials.AspNetCore.Pwa;

namespace PoopBuddy.Web
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddProgressiveWebApp(new PwaOptions
            {

            });
            services.AddCors(options =>
            {
                options.AddPolicy("InternalApiPolicy", builder=> builder.AllowAnyOrigin());
            });


            services.AddSpaStaticFiles(configuration => { configuration.RootPath = "ClientApp/dist"; });
            services.AddWebAppServices();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment() || env.IsStaging())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            
            app.UseCors("InternalApiPolicy");
            app.UseMvc();

            app.UseSpa(config =>
            {
                config.Options.SourcePath = "ClientApp";
                if (env.IsDevelopment())
                {
                    config.UseAngularCliServer(npmScript: "start");
                }
            });

        }
    }
}
