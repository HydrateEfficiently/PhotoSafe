using Microsoft.Data.Entity;
using Microsoft.Extensions.DependencyInjection;
using PhotoSafe.Data.Identity;
using PhotoSafe.Data.Initializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoSafe.Data.Utilities
{
    public static class ServiceCollectionUtility
    {

        public static IServiceCollection AddPhotoSafeDataServices(this IServiceCollection services, string connectionString)
        {
            services.AddEntityFramework()
                .AddSqlServer()
                .AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(connectionString));

            services.AddIdentity<ApplicationUser, ApplicationRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();
            services.AddTransient<DebugInitializer>();

            return services;
        }

    }
}
