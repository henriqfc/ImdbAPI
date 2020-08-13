using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.IdentityModel.Tokens;
using WebAPI.Infra.Cross.IOC;
using WebAPI.Util.Token;
using WepAPI.Infra.Data;

namespace WebAPI.Presentation
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void ConfigureContainer(ContainerBuilder builder)
        {

            builder.RegisterModule(new ModuleIOC());
        }
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<SqlContext>(options => options.UseLazyLoadingProxies().UseSqlServer(Configuration.GetConnectionString("IMDBConnection")));
            services.AddCors();
            services.AddMemoryCache();
            services.AddControllers();
            services.AddSwaggerGen(options =>
            {
                string caminhoAplicacao = PlatformServices.Default.Application.ApplicationBasePath;
                string nomeAplicacao = PlatformServices.Default.Application.ApplicationName;
                string caminhoDocumentacao = Path.Combine(caminhoAplicacao, $"{ nomeAplicacao}.xml");
                options.IncludeXmlComments(caminhoDocumentacao);
                options.SwaggerDoc("beta", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "Documentação API IMDB",
                    Version = "beta",
                    Description = "Projeto Teste IMDB para ioasys",
                    Contact = new Microsoft.OpenApi.Models.OpenApiContact
                    {
                        Name = "Henrique Castro",
                        Email = "henriq_182@hotmail.com",
                        Url = new Uri("https://github.com/henriqfc/")
                    }
                });
            });
            var key = Encoding.ASCII.GetBytes(Settings.secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors(builder => builder
                                     .AllowAnyOrigin()
                                     .AllowAnyMethod()
                                     .AllowAnyHeader());
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(setup =>
            {
                setup.RoutePrefix = "swagger";
                setup.SwaggerEndpoint("/swagger/beta/swagger.json", "Documentação API IMDB");
            });
        }
    }
}
