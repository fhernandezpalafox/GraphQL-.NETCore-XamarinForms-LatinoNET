using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoGraphQL.GraphQL.Mutations;
using DemoGraphQL.GraphQL.Queries;
using DemoGraphQL.GraphQL.Repositories;
using DemoGraphQL.GraphQL.SchemasGraph;
using DemoGraphQL.GraphQL.Services;
using DemoGraphQL.GraphQL.Types;
using GraphiQl;
using GraphQL;
using GraphQL.NewtonsoftJson;
using GraphQL.Server;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace DemoGraphQL
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

            services.AddScoped<IDocumentExecuter, DocumentExecuter>();
            services.AddScoped<IDocumentWriter, DocumentWriter>();

            services.AddScoped<LugarService>();
            services.AddScoped<LugarRepository>();
            services.AddScoped<LugaresQuery>();
            services.AddScoped<LugarMutation>();
            services.AddScoped<LugaresType>();
            services.AddScoped<InputLugaresType>();

            services.AddScoped<ISchema, GraphQLDemoSchema>();


            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "DemoGraphQL", Version = "v1" });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DemoGraphQL v1"));
            }

            app.UseHttpsRedirection();

            //TODO Se agrega este codigo para activar GraphiQL
            app.UseGraphiQl("/graphql");


            app.UseRouting();

            app.UseAuthorization();

            

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
