using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using Sofisa.Desafio.API.Models;

namespace Sofisa.Desafio.API
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
            services.AddDbContext<RepositorioContext>(op => op.UseInMemoryDatabase("FavoritoBD"));

            services.AddCors();
            services.AddControllers();

            //Descrição do Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "Versão 1.0.0.1",
                    Title = "Desafio Sofisa API",
                    Description = "API de Controle dos Repositorios Favoritos",
                    Contact = new OpenApiContact
                    {
                        Name = "Banco Sofisa Direto",
                        Url = new Uri("https://www.sofisadireto.com.br/"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Banco Sofisa Direto",
                        Url = new Uri("https://www.sofisadireto.com.br/"),
                    }
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            //Habilitar o Swagger
            app.UseStaticFiles();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Products V1");
            });
            //Fim Habilitar o Swagger

            app.UseCors(option => option
                        .AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod());

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
