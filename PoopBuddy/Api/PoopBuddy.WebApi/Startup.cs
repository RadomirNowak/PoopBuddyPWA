using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using PoopBuddy.Data;
using PoopBuddy.Shared;

namespace PoopBuddy.WebApi
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddCors(options =>
            {
                options.AddPolicy("InternalApiPolicy", builder=> builder.AllowAnyOrigin());
            });

            InitializeProjectsDependencies(services);
        }

        private void InitializeProjectsDependencies(IServiceCollection services)
        {
            services.AddDataServices();
            services.AddSharedServices();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            
            app.UseCors("InternalApiPolicy");
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
