using Microsoft.Data.Entity;
using Microsoft.Extensions.DependencyInjection;
using PhotoSafe.Data.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoSafe.Data
{
    public static class PhotoSafeDataIServiceCollectionUtility
    {
        public static IServiceCollection AddPhotoSafeData(
            this IServiceCollection services,
            string connectionString,
            IDataInitializer dataInitializer = null)
        {
            services.AddEntityFramework()
                .AddSqlServer()
                .AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(connectionString));

            services.AddIdentity<ApplicationUser, ApplicationRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            if (dataInitializer != null)
            {
                dataInitializer.Run();
            }

            return services;
        }
    }

    public class PhotoSafeDataServicesBuilder
    {
        private IServiceProvider _serviceProvider;

        public PhotoSafeDataServicesBuilder(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }


        public PhotoSafeDataServicesBuilder AddDataInitializer<TDataInitializer>() where TDataInitializer : IDataInitializer
        {
            ActivatorUtilities.CreateInstance<TDataInitializer>(_serviceProvider, typeof(TDataInitializer)).Run();
            return this;
        }
    }

    public interface IDataInitializer
    {
        void Run();
    }
}
