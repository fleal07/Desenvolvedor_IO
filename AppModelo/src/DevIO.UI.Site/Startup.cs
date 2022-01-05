using DevIO.UI.Site.Data;
using DevIO.UI.Site.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DevIO.UI.Site
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
            //Muda a convenção do nome Areas do Mvc para Modulos
            services.Configure<RazorViewEngineOptions>(options => 
            {
                options.AreaViewLocationFormats.Clear();
                options.AreaViewLocationFormats.Add(item:"/Modulos/{2}/Views/{1}/{0}.cshtml");
                options.AreaViewLocationFormats.Add(item:"/Modulos/{2}/Views/Shared/{0}.cshtml");
                options.AreaViewLocationFormats.Add(item:"/Views/Shared/{0}.cshtml");
            });

            services.AddControllersWithViews();

            services.AddTransient<IPedidoRepository, PedidoRepository>();

            services.AddTransient<IOperacaoTransient, Operacao>();
            services.AddScoped<IOperacaoScoped, Operacao>();
            services.AddSingleton<IOperacaoSingleton, Operacao>();
            services.AddSingleton<IOperacaoSingletonInstace>(new Operacao(System.Guid.Empty));

            services.AddTransient<OperacaoService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                //Desta forma eu não consigo navegar pelo link, por nao ter uma controller Home
                //Mas é a forma mais genérica
                // endpoints.MapControllerRoute(
                //     name: "areas",
                //     pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                //Com o MapAreaControllerRoute consigo navegar pelo link, pois consigo apontar as controllers conforme a area
                endpoints.MapAreaControllerRoute("AreaProduto","Produtos","Produtos/{controller=Cadastro}/{action=Index}/{id?}");
                endpoints.MapAreaControllerRoute("AreaVendas","Vendas","Vendas/{controller=Pedidos}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
