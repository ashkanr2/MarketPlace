using App.Domain.Core.DataAccess;
using App.Domain.Core.DtoModels;
using App.Domain.Core.Entities;
using App.Infrastructures.Db.SqlServer.Ef.DataBase;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructures.Data.Repositories.DataAccess.Ripository
{
   
    public class ImageRipository : IImageRipository
    {
        private readonly MarketPlaceDb _context;
        private readonly IMapper _mapper;
        public ImageRipository(MarketPlaceDb context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ImageDto> Getdetail(int imageId, CancellationToken cancellationToken)
        {
         var image =   _mapper.Map<ImageDto>(await _context.Images
             .AsNoTracking()
             .Where(a => a.Id == imageId)
             .FirstOrDefaultAsync(cancellationToken));
            return image;
        }
        public async Task<List<ImageDto>> GetProductImages(int pId, CancellationToken cancellationToken)
        {
            var images = _mapper.Map<List<ImageDto>>(await _context.ProductImages
              .AsNoTracking()
              .Include(pi => pi.Image)
              .Where(pi => pi.ProductId == pId)
              .Select(pi => pi.Image)
              .ToListAsync());
            return images;
        }

        public async Task Update(ImageDto imageFile, CancellationToken cancellationToken)
        {
           var item = _context.Images
                .AsNoTracking()
                .Where(a =>a.Id == imageFile.Id)
                .FirstOrDefault();
            if (item != null)
            {
                item.Path = imageFile.Path;
                item.Isdeleted = imageFile.Isdeleted;
                item.IsProfileImage = imageFile.IsProfileImage;
                item.IsAccepted = imageFile.IsAccepted;
            }
           
            await _context.SaveChangesAsync();
        }

        public async Task<int> Upload(string path, bool isProfile, CancellationToken cancellationToken)
        {
            var image = new Image
            {
                Path = path,
                Isdeleted = false,
                IsProfileImage = isProfile,
                IsAccepted = false,
            };
            try
            {
                await _context.AddAsync(image);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                //_loger.LogError("Error in add new Order {exception}", ex);
                throw; // Rethrow the exception so it can be handled at a higher level if necessary.
            }

            // Retrieve the saved image from the database to get its ID.
            var savedImage = await _context.Images.AsNoTracking().FirstOrDefaultAsync(a => a.Path == path);

           
                return savedImage.Id;
            
        }

    }
}
