using System;
using System.IO;
using System.Reflection;
using SocietyApi.BAL;
using SocietyApi.DATA;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Swagger;

namespace SocietyApi
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationContext>(opts => opts.UseSqlServer(Configuration["ConnectionString:DefaultConnection"]));
            services.AddTransient(typeof(IClientMasterRepository), typeof(ClientMasterRepository));
            services.AddTransient(typeof(ICommonDesignationRepository), typeof(CommonDesignationRepository));
            services.AddTransient(typeof(ICommonTableTypeRepository), typeof(CommonTableTypeRepository));
            services.AddTransient(typeof(IDesignationTypeRepository), typeof(DesignationTypeRepository));
            services.AddTransient(typeof(IDesignationTypeMappingRepository), typeof(DesignationTypeMappingRepository));
            services.AddTransient(typeof(IPersonMasterRepository), typeof(PersonMasterRepository));
            services.AddTransient(typeof(IDesignationMasterRepository), typeof(DesignationMasterRepository));
            services.AddTransient(typeof(IFlatMasterRepository), typeof(FlatMasterRepository));
            services.AddTransient(typeof(IFlatTypeMasterRepository), typeof(FlatTypeMasterRepository));
            services.AddTransient(typeof(IFloorMasterRepository), typeof(FloorMasterRepository));
            services.AddTransient(typeof(IProjectMasterRepository), typeof(ProjectMasterRepository));
            services.AddTransient(typeof(IWingMasterRepository), typeof(WingMasterRepository));
            services.AddTransient(typeof(ILookupRepository), typeof(LookupRepository));

            services.AddMvc().AddJsonOptions(options =>
            {
                options.SerializerSettings.ContractResolver
                    = new Newtonsoft.Json.Serialization.DefaultContractResolver();
            });

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "SocietyApi", Version = "v1" });
                c.OperationFilter<AddRequiredHeaderParameter>();

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);

            }); 

            MappingConfig.RegisterMaps();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                string swaggerJsonBasePath = string.IsNullOrWhiteSpace(c.RoutePrefix) ? "." : "..";
                c.SwaggerEndpoint($"{swaggerJsonBasePath}/swagger/v1/swagger.json", "SocietyApi");
            });

            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseCors(builder => builder
     .AllowAnyOrigin()
     .AllowAnyMethod()
     .AllowAnyHeader()
     .AllowCredentials());

            app.UseMvc();
        }
    }
}
