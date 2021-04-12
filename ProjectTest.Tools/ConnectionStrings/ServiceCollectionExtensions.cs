using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjectTest.Infrastracture.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectTest.Tools.ConnectionStrings
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TestContext>(options =>
            {
                options
                    .UseSqlServer(configuration.GetConnectionString("TestProject"));
             
                    
            });
        }
    }
}

