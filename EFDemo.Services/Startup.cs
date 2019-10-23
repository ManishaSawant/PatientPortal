using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using AutoMapper;
using EFDemo.Domain.DataAccess;
using EFDemo.Domain.DataAccess.Interfaces;
using EFDemoBusiness.Interfaces;
using EFDemoBusiness;
using EFDemo.Services.Profile;

namespace EFDemo.Services
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
            services.AddCors();
            services.AddScoped(_ => new EFDemoContext());
            services.AddTransient<IPatientRepository, PatientRepository>();
            services.AddTransient<IPatientRetriever, PatientRetriever>();
            services.AddTransient<IPatientInserter, PatientInserter>();
            services.AddTransient<IPatientUpdater, PatientUpdater>();
            services.AddTransient<IPatientRemover, PatientRemover>();
            var config = new AutoMapper.MapperConfiguration(c =>
              {
                  c.AddProfile(new ApplicationProfile()) ;
  
              }
           );
            var mapper = config.CreateMapper();
            services.AddSingleton(mapper);

            //services.AddAutoMapper(typeof(Startup));
            services.AddControllers();
          

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseCors(Options =>
           Options.WithOrigins("http://localhost:4200").
           AllowAnyMethod().AllowAnyHeader()
           );

            app.UseRouting();

            app.UseAuthorization();
            

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
          
        }
    }
}
