using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PhotoSafe.Data;
using Microsoft.Extensions.Logging;
using Microsoft.Data.Entity;

namespace PhotoSafe.Services
{
    public class SafeService : ISafeService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IIdentityResolver _identityResolver;
        private readonly ILogger<SafeService> _logger;


        public SafeService(
            ApplicationDbContext dbContext,
            IIdentityResolver identityResolver,
            ILogger<SafeService> logger)
        {
            _dbContext = dbContext;
            _identityResolver = identityResolver;
            _logger = logger;
        }

        public async Task CreateSafe(NewSafeRequest safeRequest)
        {
            string userId = _identityResolver.GetCurrentUserId();
            var safe = new Safe()
            {
                SubjectName = safeRequest.SubjectName,
                AdministratorId = userId,
                CreatedById = userId
            };

            _dbContext.Safes.Add(safe);
            await _dbContext.SaveChangesAsync();
        }

        public Safe GetSafe(int id)
        {
            return _dbContext.Safes
                .Where(s => s.Id == id)
                .Include(s => s.Administrator)
                .Include(s => s.CreatedBy)
                .FirstOrDefault();
        }

        public IEnumerable<Safe> GetSafes()
        {
            return _dbContext.Safes.AsEnumerable();
        }
    }
}
