using Microsoft.AspNet.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PhotoSafe.Data.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoSafe.Data.Initializers
{
    public class DebugInitializer
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly ILogger _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;

        public DebugInitializer(
            ILoggerFactory logger,
            IServiceProvider serviceProvider,
            UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager)
        {
            _logger = logger.CreateLogger(nameof(DebugInitializer));
            _serviceProvider = serviceProvider;
            _scopeFactory = _serviceProvider.GetRequiredService<IServiceScopeFactory>();
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public void Run()
        {
            _logger.LogVerbose("Started seeding data");

            EnsureDatabaseCreated();

            _logger.LogVerbose("Completed seeding data");
        }

        private void EnsureDatabaseCreated()
        {
            UsingContext(context =>
            {
                context.Database.EnsureCreated();
            });
        }

        private void UsingContext(Action<ApplicationDbContext> action)
        {
            using (var serviceScope = _scopeFactory.CreateScope())
            using (var context = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>())
            {
                action(context);
            }
        }
    }
}
