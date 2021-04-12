using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Server.Ui.Voyager;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Library.Api.Data;
using Library.Api.GraphQL;
using Library.Api.GraphQL.Books;

namespace Library.Api
{
    public class Startup
    {
        private readonly IConfiguration configuration;

        public Startup(IConfiguration config) 
        {
            configuration = config;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            //services.AddMvc();
            //services.AddDbContext<LibraryDemoContext>(options =>
            //    options.UseSqlServer(configuration["ConnectionStrings:LibraryUniversity"]));

            //services.AddScoped<BookRepository>();

            services.AddPooledDbContextFactory<LibraryDemoContext>(opt => opt.UseSqlServer(configuration["ConnectionStrings:LibraryUniversity"]));

            services
                .AddGraphQLServer()
                .AddQueryType<Query>()
                //.AddMutationType<Mutation>()
                //.AddSubscriptionType<Subscription>()
                .AddType<BookType>()
                .AddFiltering()
                .AddSorting()
                .AddInMemorySubscriptions();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseWebSockets();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGraphQL();
            });

            app.UseGraphQLVoyager(new GraphQLVoyagerOptions()
            {
                GraphQLEndPoint = "/graphql",
                Path = "/graphql-voyager"
            });
        }
    }
}
