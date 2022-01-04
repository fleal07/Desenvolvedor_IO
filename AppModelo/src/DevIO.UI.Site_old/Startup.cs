using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DevIO.UI.Site
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //Maneira velha de chamarv o MVC
            // services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Latest);
            // services.AddMvc(options => options.EnableEndpointRouting = false);

            //Maneira atual de chamar o MVC
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

             app.UseRouting();

            //Maneira antiga de configurar a rota
            // app.UseMvc(routes =>
            // {
            //     routes.MapRoute(
            //         name: "default",
            //         template: "{controller=Home}/{action=Index}/{id?}");
            // });

            //Maneira Atual
            app.UseEndpoints(endpoints =>
            {
                 endpoints.MapControllerRoute(
                     name:"default",
                     pattern:"{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
