using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using GraphQL;
using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using Library.Api.Data;
using Library.Api.Repositories;
using Library.Api.GraphQL;
using GraphQL.Types;

namespace Library.Api
{
    public class Startup
    {
        public IConfiguration configuration { get; }

        public Startup(IConfiguration config) 
        {
            configuration = config;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddDbContext<LibraryDemoContext>(options =>
                options.UseSqlServer(configuration["ConnectionStrings:LibraryUniversity"]));

            services.AddScoped<BookRepository>();

            //services.AddSingleton(s => new LibraryUniversitySchema(new FuncDependencyResolver(type => (IGraphType)s.GetRequiredService(type))));

            //services.AddScoped<IDependencyResolver>(s => new FuncDependencyResolver(s.GetRequiredService));
            //services.AddScoped<LibraryUniversitySchema>();


            services.AddSingleton<LibraryUniversityQuery>();
            services.AddSingleton<ISchema, LibraryUniversitySchema>();

            services.AddGraphQL().AddGraphTypes(ServiceLifetime.Scoped);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
        }
    }
}
