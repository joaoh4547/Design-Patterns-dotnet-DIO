using Frotas.Domain;
using Frotas.Infra.EF;
using Frotas.Infra.Facade;
using Frotas.Infra.Repository;
using Frotas.Infra.Singleton;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.IO;

namespace Frotas
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Frotas", Description = "API - Frotas ", Version = "v1" });
                c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "Frotas.xml"));
            });
            services.AddControllers();
            services.AddSingleton<SingletonContainer>();

            services.AddDbContext<FrotaContext>(opt => opt.UseInMemoryDatabase("Frota"));
            services.AddScoped<IVeiculoRepository, FrotaRepository>();
            services.AddScoped<IVeiculoDetran, VeiculoDetranFacade>();
            services.Configure<DetranOptions>(Configuration.GetSection("DetranOption"));
            services.AddHttpClient();
        
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
           
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api frotas");
                
            });
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
