using Compartilhado.Interfaces;
using Infraestrutura.Repositorio;
using Dominio.Contextos.Jogos.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using EntityFramework.Contextos.Jogos;
using Aplicacao.Contextos.Jogos;
using AplicacaoService.Contextos.Jogos;
using Dominio.Contextos.Jogos;
using Negocio.Contextos.Jogos;
using Newtonsoft.Json;
using EntityFramework.Configuracao;
using Aplicacao.Contextos.Usuarios;
using Dominio.Contextos.Usuarios.Interfaces;
using EntityFramework.Contextos.Usuarios;
using AplicacaoService.Contextos.Usuarios;
using Negocio.Contextos.Usuarios;
using AplicacaoService.Contextos.Home;
using Aplicacao.Contextos.Home;

namespace DesafioInvillia
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
            services.AddCors(options =>
            {
                options.AddPolicy(
                   name: "AllowOrigin",
                   builder => {
                       builder.AllowAnyOrigin()
                      .AllowAnyMethod()
                      .AllowAnyHeader();
                   });
            });

            services.AddControllers();
            services.AddDbContext<ContextoBase>();
            services.AddHttpClient();
            services.AddMvc().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Serialize;
                options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
            });

            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "Desafio Invillia - Sistema de Controle de Jogos",
                        Version = "v1",
                        Contact = new OpenApiContact
                        {
                            Name = "Valniria Bandeira",
                            Url = new System.Uri("https://github.com/valniria")
                        }
                    });
            });

            services.AddTransient(typeof(IRepositorioBase<>), typeof(RepositorioBase<>));

            services.AddTransient<IJogoRepositorio, JogoRepositorio>();
            services.AddTransient<IUsuarioRepositorio, UsuarioRepositorio>();

            services.AddTransient<IJogoService, JogoService>();
            services.AddTransient<IUsuarioService, UsuarioService>();
            services.AddTransient<IHomeService, HomeService>();

            services.AddTransient<IJogoNegocio, JogoNegocio>();
            services.AddTransient<IUsuarioNegocio, UsuarioNegocio>();



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors("AllowOrigin");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Desafio Invillia - Sistema de Controle de Jogos");
            });
        }
    }
}
