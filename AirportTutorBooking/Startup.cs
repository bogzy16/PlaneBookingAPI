using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirportTutorBooking.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using AirportTutorBooking.Controllers;
using AirportTutorBooking.IRepository;
using AirportTutorBooking.Repository;
using Swashbuckle.AspNetCore.Swagger;
using System.Reflection;
using System.IO;

namespace AirportTutorBooking
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddDbContext<AppDBContext>(options =>
            {
                options.UseSqlServer(Configuration["AppSettings:ConnectionString"]);
            });

            // Set up dependency injection for controller's logger
            services.AddScoped<ILogger, Logger<AdministratorController>>();
            services.AddScoped<ILogger, Logger<AirportController>>();
            services.AddScoped<ILogger, Logger<PlanesController>>();
            services.AddScoped<ILogger, Logger<TutorsController>>();
            services.AddScoped<ILogger, Logger<StudentsController>>();

            // Set up Repository Dependency Injections
            services.AddScoped<IAdministrator, Administrator>();
            services.AddScoped<IAirports, Airport>();
            services.AddScoped<IPlanes, Planes>();
            services.AddScoped<ITutors, Tutors>();
            services.AddScoped<IStudents, Students>();

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Info { Title = "Planes tutorial API", Version = "v1" });

                // Get xml comments path
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

                // Set xml path
                options.IncludeXmlComments(xmlPath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, AppDBContext db)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            // Make sure that DB will be created.
            db.Database.EnsureCreated();

            app.UseHttpsRedirection();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Planes tutorial API V1");
            });

            app.UseMvc();
        }
    }
}
