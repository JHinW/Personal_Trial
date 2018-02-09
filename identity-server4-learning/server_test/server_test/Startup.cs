using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using server_test.Server;
using System.IdentityModel.Tokens.Jwt;
using IdentityServer4;

namespace server_test
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddIdentityServer()
               .AddTemporarySigningCredential()
               .AddInMemoryIdentityResources(Config.GetIdentityResources())
               .AddInMemoryApiResources(Config.GetApiResources())
               .AddInMemoryClients(Config.GetClients())
               .AddTestUsers(Config.GetUsers());

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseIdentityServer();

            app.UseMicrosoftAccountAuthentication(new MicrosoftAccountOptions
            {
                ClientId = "83b568df-b395-4d11-a9c0-39efc42ba44f",
                ClientSecret = "7cMJkDDS1CQCkAmjqBLeoJV",
                SignInScheme = IdentityServerConstants.ExternalCookieAuthenticationScheme
            });

            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
        }
    }
}
