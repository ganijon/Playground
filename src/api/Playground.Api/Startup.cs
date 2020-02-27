using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Server;
using GraphQL.Server.Ui.GraphiQL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Playground.Graph.Schema;
using Playground.Graph.Schema.Mutations;
using Playground.Graph.Schema.Queries;
using Playground.Graph.Schema.Subscriptions;
using Playground.Graph.Schema.Types;
using Playground.Graph.Services;
using Playground.Repository;

namespace Playground.Api
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
            // Enable any Cross-Origin Requests
            services.AddCors();

            // Repository of mock data
            services.AddSingleton<IRepository, MockRepository>();

            // Services
            services.AddSingleton<IAuthorService, AuthorService>();
            services.AddSingleton<IBookService, BookService>();

            // REST endpoints
            services.AddControllers()
                .AddNewtonsoftJson(options => 
                { 
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore; 
                });

            // GraphQL endpoints
            ConfigureGraphQL(services);
        }

        private void ConfigureGraphQL(IServiceCollection services)
        {
            #region Kestrel
            // If using Kestrel:
#if NETCOREAPP3_1
            // Workaround until GraphQL can swap off Newtonsoft.Json and onto the new MS one.
            // Depending on whether you're using IIS or Kestrel, the code required is different
            // See: https://github.com/graphql-dotnet/graphql-dotnet/issues/1116
            services.Configure<KestrelServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });
            services.Configure<IISServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });
#endif
            #endregion

            // Register DepedencyResolver; this will be used when a GraphQL type needs to resolve a dependency
            services.AddSingleton<IDependencyResolver>(x =>
                new FuncDependencyResolver(type => x.GetRequiredService(type)));

            // Schema
            services.AddSingleton<TheSchema>();

            // Query
            services.AddSingleton<TheQuery>();

            // Mutation
            services.AddSingleton<TheMutation>();
            services.AddSingleton<AuthorRequest>();
            services.AddSingleton<BookRequest>();

            // Subscription
            services.AddSingleton<TheSubscription>();

            // Types
            services.AddSingleton<AuthorType>();
            services.AddSingleton<BookType>();

            // Register GraphQL services
            services.AddGraphQL(options =>
            {
                options.EnableMetrics = true;
                options.ExposeExceptions = true;
            }).AddWebSockets();
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

            // This will enable WebSockets in Asp.Net core
            app.UseWebSockets();

            // Enable endpoint for websockets (subscriptions)
            app.UseGraphQLWebSockets<TheSchema>("/graphql");

            // Enable endpoint for querying
            app.UseGraphQL<TheSchema>("/graphql");

            // Enable developer UI
            app.UseGraphiQLServer(new GraphiQLOptions { GraphiQLPath = "/ui" });

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
