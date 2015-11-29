using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PhotoSafe.ViewModels;
using PhotoSafe.Data;
using Microsoft.AspNet.Http;
using PhotoSafe.Utility;
using Microsoft.Data.Entity;
using AutoMapper;

namespace PhotoSafe.Services
{
    public class DepositService : IDepositService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IPhotoFileService _photoFileService;

        public DepositService(
            ApplicationDbContext dbContext,
            IPhotoFileService photoFileService)
        {
            _dbContext = dbContext;
            _photoFileService = photoFileService;
        }

        public async Task<DepositViewModel> Get(int depositId)
        {
            var deposit = _dbContext.Deposits
                .Where(d => d.Id == depositId)
                .Include(d => d.Photos).ThenInclude(p => p.ImageUpload)
                .FirstOrDefault();

            Mapper.CreateMap<Deposit, DepositViewModel>();
            var result = Mapper.Map<Deposit, DepositViewModel>(deposit);
            result.ImageUrls = await Task.WhenAll(deposit.Photos
                .Select(p => _photoFileService.GetFileUrl(p)));
            return result;
        }

        public async Task<int> Create(CreateDepositViewModel model)
        {
            Mapper.CreateMap<CreateDepositViewModel, Deposit>();
            var deposit = Mapper.Map<CreateDepositViewModel, Deposit>(model);
            _dbContext.Deposits.Add(deposit);
            await _dbContext.SaveChangesAsync();
            await AddPhotos(deposit.Id, model.PhotoFormFiles.ToArray());
            return deposit.Id;
        }

        public async Task AddPhotos(int depositId, params IFormFile[] photoFiles)
        {
            photoFiles.ToList().ForEach(pf =>
            {
                var content = pf.ToByteArray();
                var photo = new Photo()
                {
                    DepositId = depositId,
                    ImageUploadFileName = pf.GetFileName(),
                    ImageUpload = new ImageUpload()
                    {
                        Content = content,
                        ContentType = pf.ContentType,
                        Length = content.Length
                    }
                };
                _dbContext.Photos.Add(photo);
                _dbContext.ImageUploads.Add(photo.ImageUpload);
            });
            await _dbContext.SaveChangesAsync();
        }
    }
}
