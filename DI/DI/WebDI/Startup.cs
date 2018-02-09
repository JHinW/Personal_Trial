using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using WebDI.source;

namespace WebDI
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
            services.AddTransient<Test2>(provider => {
                var ret = new Test2();
                var mid = provider.GetService<Test3>();
                ret.ID = mid.ID;
                return ret;
            });
            services.AddScoped<Test1, Test1>();
            services.AddScoped<Test, Test>();
            services.AddTransient<Test3, Test3>();
            services.AddSingleton<Test3, Test3>();
            services.AddScoped<Test3, Test3>();
            services.AddTransient<Test3, Test3>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, Test test)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            
            Console.WriteLine(test.ID);
            app.UseMvc();
        }
    }
}
