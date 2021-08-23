using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application;
using Data;
using Microsoft.EntityFrameworkCore;
using Application.ManageEmployee;
using Application.Manage_Question;
using Application.Manage_Subject;
using Application.Manage_Teacher;
using Application.Manage_StudentSubject;
using Application.Manage_ExamResult;

namespace CompanyProject
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
            services.AddDbContextPool<FacultyDBContext>(option =>
            option.UseSqlServer(Configuration.GetConnectionString("UniverstiesDataBase")));
            services.AddScoped<IManageFaculty, ManageFaculty>();
            services.AddScoped<IManageStudent, ManageStudent>();
            services.AddScoped<IManageQuestion, ManageQuestion>();
            services.AddScoped<IManageSubject, ManageSubject>();
            services.AddScoped<IManageTeacher, ManageTeacher>();
            services.AddScoped<IManageStudentSubject, ManageStudentSubject>();
            services.AddScoped<IManageExamResult, ManageExamResult>();
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
