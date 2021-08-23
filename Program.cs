using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Domain;

namespace CompanyProject
{
    public class Program
    {
        public static void Main(string[] args)
        {

            //var db = new CompanyDBContext();
            //db.Companies.AddRange(new List<Company>()
            //{
            //    new Company(){
            //    Name="CCC",
            //        Employees =
            //        {
            //            new Employee(){
            //             Name = "Ibrahim",
            //             Age = 23,
            //             Salary=7000,
            //             Address="Mansoura"
            //            },
            //            new Employee(){
            //             Name = "Islam",
            //             Age = 25,
            //             Salary=8000,
            //             Address="Giza"
            //            },
            //        }
            //    },
            //    new Company(){
            //    Name="ECG",
            //        Employees =
            //        {
            //            new Employee(){
            //             Name = "Eslam",
            //             Age = 36,
            //             Salary=20000,
            //             Address="Cairo"
            //            },
            //            new Employee(){
            //             Name = "Ayman",
            //             Age = 26,
            //             Salary=10000,
            //             Address="Giza"
            //            },
            //        }
            //    },
            //    new Company(){
            //    Name="Dar Elhandasa",
            //        Employees =
            //        {
            //            new Employee(){
            //             Name = "Fathy",
            //             Age = 36,
            //             Salary=12000,
            //             Address="Alex"
            //            },
            //            new Employee(){
            //             Name = "Rohayem",
            //             Age = 30,
            //             Salary=15000,
            //             Address="Mansoura"
            //            },
            //        }
            //    },
            //});
            //db.SaveChanges();

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
