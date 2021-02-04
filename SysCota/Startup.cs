using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SysCota.DAL;
using SysCota.Data;

namespace SysCota
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
            services.AddEntityFrameworkNpgsql()
             .AddDbContext<DBCOTACAOContext>(options => options.UseNpgsql(Configuration.GetConnectionString("DBCOTACAOContext")));
            //services.AddDbContext<DBCOTACAOContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DBCOTACAOContext")));
            services.AddMvc();
            services.AddDistributedMemoryCache();
            services.AddAutoMapper(typeof(Startup));

            //Aqui vc esta adicioando ao serviço, fazendo a instancia.
            services.AddScoped<EmpresaDAL>();
            services.AddScoped<EnderecoDAL>();
            services.AddScoped<UnidadeDAL>();
            services.AddScoped<MarcaDAL>();
            services.AddScoped<ProdutoDAL>();

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(20); // Defini o tempo da sessão 
                options.Cookie.SecurePolicy = CookieSecurePolicy.None;//Desabilita autenticação session modo https
                options.Cookie.HttpOnly = true;//Não permite acesso a session via script
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/erro/500");
                app.UseStatusCodePagesWithRedirects("/erro/{0}");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession();

            //Aplica globalization - front end
            var defaultCulture = new CultureInfo("pt-br");

            var localizationOptions = new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture(defaultCulture),
                SupportedCultures = new List<CultureInfo> { defaultCulture },
                SupportedUICultures = new List<CultureInfo> { defaultCulture }
            };

            app.UseRequestLocalization(localizationOptions);

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
