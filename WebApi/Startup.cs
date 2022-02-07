using Aplicacao.Aplicacao;
using Aplicacao.Interfaces;
using Dominio.Interfaces;
using Dominio.Interfaces.InterfaceCrud;
using Dominio.Interfaces.InterfaceServico;
using Dominio.Servico;
using Infraestrutura.Configuracao;
using Infraestrutura.Repositorio;
using Infraestrutura.Repositorio.Crud;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace WebApi
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
            services.AddDbContext<ApiContext>(opt => opt
                        .UseLazyLoadingProxies()
                        .UseNpgsql(ObterStringConexaoBanco())
            );

            //Utilizado esse servico pois ao cancelar uma movimentacao estava retornando erro
            services.AddDbContext<ApiContext>(ServiceLifetime.Transient);


            //INTERFACE E REPOSITORIO
            services.AddScoped<IMunicipio, RepositorioMunicipio>();
            services.AddScoped<IEndereco, RepositorioEndereco>();
            services.AddScoped<IProdutor, RepositorioProdutor>();
            services.AddScoped<IPropriedade, RepositorioPropriedade>();
            services.AddScoped<IRebanho, RepositorioRebanho>();
            services.AddScoped<IHistorico, RepositorioHistorico>();
            services.AddScoped<IUtilAutoIncrementaHistorico, RepositorioUtilAutoIncrementaHistorico>();

            //INTERFACE E SERVICO
            services.AddScoped<IServicoProdutor, ServicoProdutor>();
            services.AddScoped<IServicoPropriedade, ServicoPropriedade>();
            services.AddScoped<IServicoRebanho, ServicoRebanho>();
            services.AddScoped<IServicoHistorico, ServicoHistorico>();
            services.AddScoped<IServicoVenda, ServicoVenda>();

            // INTERFACE E APLICACAO
            services.AddScoped<IAplicacaoMunicipio, AplicacaoMunicipio>();
            services.AddScoped<IAplicacaoProdutor, AplicacaoProdutor>();
            services.AddScoped<IAplicacaoPropriedade, AplicacaoPropriedade>();
            services.AddScoped<IAplicacaoRebanho, AplicacaoRebanho>();
            services.AddScoped<IAplicacaoMovimentacao, AplicacaoMovimentacao>();
            services.AddTransient<IAplicacaoVenda, AplicacaoVenda>();


            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "IagroApi", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "IagroApi v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
        public static string ObterStringConexaoBanco()
        {
            return "Host=localhost;Port=5432;Pooling=true;Database=IagroDB;User Id=postgres;Password=123;";
        }
    }
}
