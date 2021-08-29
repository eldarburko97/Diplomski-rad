using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using eDentalClinic.Model.Requests;
using eDentalClinicWebAPI.Database;
using eDentalClinicWebAPI.Filters;
using eDentalClinicWebAPI.Security;
using eDentalClinicWebAPI.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;

namespace eDentalClinicWebAPI
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
            services.AddCors();
            services.AddMvc(x => x.Filters.Add<ErrorFilter>()).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddDbContext<eDentalClinicContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddMvc()
    .AddJsonOptions(options => {
        options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
    });
            services.AddAutoMapper(typeof(Startup));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            });
            services.AddAuthentication("BasicAuthentication")
              .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IDentalClinicService, DentalClinicService>();
            services.AddScoped<IRecommendationService, RecommendationService>();
            services.AddScoped<ICRUDService<eDentalClinic.Model.Branch, BranchSearchRequest, BranchInsertRequest, BranchInsertRequest>, BranchService>();
            services.AddScoped<ICRUDService<eDentalClinic.Model.Dentist, DentistSearchRequest, DentistInsertRequest, DentistInsertRequest>, DentistService>();          
            services.AddScoped<ICRUDService<eDentalClinic.Model.Treatment, TreatmentSearchRequest, TreatmentInsertRequest, TreatmentInsertRequest>, TreatmentService>();
            services.AddScoped<ICRUDService<eDentalClinic.Model.BranchTreatment, BranchTreatmentSearchRequest, BranchTreatmentInsertRequest, BranchTreatmentInsertRequest>, BranchTreatmentService>();
            services.AddScoped<ICRUDService<eDentalClinic.Model.City, CitySearchRequest, CityInsertRequest, CityInsertRequest>, CityService>();
            services.AddScoped<ICRUDService<eDentalClinic.Model.Gender, GenderSearchRequest, GenderInsertRequest, GenderInsertRequest>, GenderService>();
            services.AddScoped<ICRUDService<eDentalClinic.Model.UserRole, object, UserRoleInsertRequest, UserRoleInsertRequest>, UserRoleService>();
            services.AddScoped<ICRUDService<eDentalClinic.Model.Topic, object, TopicInsertRequest, TopicInsertRequest>, TopicService>();
            services.AddScoped<ICRUDService<eDentalClinic.Model.Comment, CommentSearchRequest, CommentInsertRequest, CommentInsertRequest>, CommentService>();
            services.AddScoped<ICRUDService<eDentalClinic.Model.Appointment, AppointmentSearchRequest, AppointmentInsertRequest, AppointmentInsertRequest>, AppointmentService>();
            services.AddScoped<ICRUDService<eDentalClinic.Model.Rating, RatingSearchRequest, RatingInsertRequest, RatingInsertRequest>, RatingService>();
            services.AddScoped<ICRUDService<eDentalClinic.Model.Payment, PaymentSearchRequest, PaymentInsertRequest, PaymentInsertRequest>, PaymentService>();
            services.AddScoped<ICRUDService<eDentalClinic.Model.Notification, NotificationSearchRequest, NotificationInsertRequest, NotificationInsertRequest>, NotificationService>();
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseAuthentication();
            //  app.UseHttpsRedirection();
            
            app.UseCors(options =>
           options.WithOrigins("http://localhost:62292")
           .AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader());
            //app.UseMiddleware<BasicAuthenticationHandler>();
            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
        }
    }
}
