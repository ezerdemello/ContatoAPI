using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace ContatoAPI.Service
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
            services.AddMvc();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = "Jwt";  
                options.DefaultChallengeScheme = "Jwt";              
            }).AddJwtBearer("Jwt", options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = false,
                    //ValidAudience = "the audience you want to validate",
                    ValidateIssuer = false,
                    //ValidIssuer = "the isser you want to validate",
                    
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("the secret that needs to be at least 16 characeters long for HmacSha256")), 
                    
                    ValidateLifetime = true, //validate the expiration and not before values in the token

                    ClockSkew = TimeSpan.FromMinutes(5) //5 minute tolerance for the expiration date
                };
            });

            services.Configure<ContatoAPI.Persistence.Shared.Settings>(Configuration.GetSection("Settings"));
            services.AddTransient<ContatoAPI.Persistence.Shared.IDatabaseContext, ContatoAPI.Persistence.Shared.DatabaseContext>();
            services.AddTransient<ContatoAPI.Application.Interfaces.IContatoRepository, ContatoAPI.Persistence.Contatos.ContatoRepository>();

            services.AddTransient<ContatoAPI.Application.Contatos.Queries.GetContatoList.IGetContatoListQuery, ContatoAPI.Application.Contatos.Queries.GetContatoList.GetContatoListQuery>();
            services.AddTransient<ContatoAPI.Application.Contatos.Queries.GetContatoDetail.IGetContatoDetailQuery, ContatoAPI.Application.Contatos.Queries.GetContatoDetail.GetContatoDetailQuery>();

            services.AddTransient<ContatoAPI.Application.Contatos.Commands.CreateContato.Factory.IContatoFactory, ContatoAPI.Application.Contatos.Commands.CreateContato.Factory.ContatoFactory>();
            services.AddTransient<ContatoAPI.Application.Contatos.Commands.CreateContato.Rules.ICreateContatoRule, ContatoAPI.Application.Contatos.Commands.CreateContato.Rules.CheckIfValorIsAnEmailRule>();
            services.AddTransient<ContatoAPI.Application.Contatos.Commands.CreateContato.Rules.ICreateContatoRule, ContatoAPI.Application.Contatos.Commands.CreateContato.Rules.CheckIfValorIsAnTelefoneOrCelularRule>();
            services.AddTransient<ContatoAPI.Application.Contatos.Commands.CreateContato.Rules.ICreateContatoRule, ContatoAPI.Application.Contatos.Commands.CreateContato.Rules.CheckIfCanalIsValidRule>();
            services.AddTransient<ContatoAPI.Application.Contatos.Commands.CreateContato.ICreateContatoCommand, ContatoAPI.Application.Contatos.Commands.CreateContato.CreateContatoCommand>();


            services.AddTransient<ContatoAPI.Application.Contatos.Commands.UpdateContato.Rules.IUpdateContatoRule, ContatoAPI.Application.Contatos.Commands.UpdateContato.Rules.CheckIfCanalIsValidRule> ();
            services.AddTransient<ContatoAPI.Application.Contatos.Commands.UpdateContato.Rules.IUpdateContatoRule, ContatoAPI.Application.Contatos.Commands.UpdateContato.Rules.CheckIfContatoExistRule>();
            services.AddTransient<ContatoAPI.Application.Contatos.Commands.UpdateContato.Rules.IUpdateContatoRule, ContatoAPI.Application.Contatos.Commands.UpdateContato.Rules.CheckIfValorIsAnEmailRule>();
            services.AddTransient<ContatoAPI.Application.Contatos.Commands.UpdateContato.Rules.IUpdateContatoRule, ContatoAPI.Application.Contatos.Commands.UpdateContato.Rules.CheckIfValorIsAnTelefoneOrCelularRule>();
            services.AddTransient<ContatoAPI.Application.Contatos.Commands.UpdateContato.IUpdateContatoCommand, ContatoAPI.Application.Contatos.Commands.UpdateContato.UpdateContatoCommand>();
        
                            

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();
            
            app.UseMvcWithDefaultRoute();

            app.Run(async (context) =>
            {
                context.Response.StatusCode = 404;
                await context.Response.WriteAsync("Page not found");
            });

        }
    }
}
