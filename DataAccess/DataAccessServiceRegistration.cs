using DataAccess.Abstracts;
using DataAccess.Concretes.EntityFramework;
using DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public static class DataAccessServiceRegistration
    {
        public static IServiceCollection AddDataAccessServices(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddDbContext<TobetoContext>(options => options.UseInMemoryDatabase("nArchitecture"));

            //services.AddDbContext<BaseDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("RentACar")));

            services.AddDbContext<TobetoContext>(options => options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=TobetoCourseAcademyDb;Trusted_Connection=true"));
            services.AddScoped<ICategoryDal, EfCategoryDal>();
            services.AddScoped<ICourseDal, EfCourseDal>();

            return services;
        }
    }
}
