using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CS20.FW.WorkSchedule.Core.IService;
using CS20.FW.WorkSchedule.Database;
using CS20.FW.WorkSchedule.Database.Repository;
using CS20.FW.WorkSchedule.Domain.IRepository;
using CS20.FW.WorkSchedule.Domain.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

namespace CS20.FW.WorkSchedule.WebApi
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
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CS20.FW.WorkSchedule.WebApi", Version = "v1" });
            });

            // 1. Set up DI
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();

            // 2. Set up DB
            services.AddDbContext<ScheduleApplicationContext>(builder =>
            {
                builder.UseSqlite(("Data Source=User.db"));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(
            IApplicationBuilder app, 
            IWebHostEnvironment env, 
            ScheduleApplicationContext scheduleApplicationContext
            )
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CS20.FW.WorkSchedule.WebApi v1"));
                new DbSeeder(scheduleApplicationContext).SeedDevelopment();
                
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}