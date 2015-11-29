using Microsoft.AspNet.Http;
using PhotoSafe.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoSafe.Services
{
    public interface IDepositService
    {
        Task<DepositViewModel> Get(int depositId);

        Task<int> Create(CreateDepositViewModel model);

        Task AddPhotos(int depositId, params IFormFile[] photoFiles);
    }
}
