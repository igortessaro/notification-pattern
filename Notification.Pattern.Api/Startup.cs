using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Notification.Pattern.Api.Filters;
using Swashbuckle.AspNetCore.Swagger;
using System;

namespace Notification.Pattern.Api
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
            services.AddMvc()
                .AddMvcOptions(setup => setup.Filters.Add<NotificationFilterAttribute>())
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddSwaggerGen(setup => setup
                .SwaggerDoc(
                    "v1",
                    new Info
                    {
                        Title = "API Doc",
                        Version = "v1",
                    }));

            var assembly = AppDomain.CurrentDomain.Load("Notification.Pattern.Api");
            services.AddMediatR(assembly);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUI(setup => setup.SwaggerEndpoint("v1/swagger.json", "API Doc v1"));
        }
    }
}
