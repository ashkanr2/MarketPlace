using App.Domain.Core.AppServices.Admin;
using App.Domain.Core.DataAccess;
using App.Domain.Core.DtoModels;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppService.Admins
{
    public class ImageAppservice : IImageAppservice
    {
        private readonly IImageRipository _imageRipository;

        public ImageAppservice(IImageRipository imageRipository)
        {
            _imageRipository = imageRipository;
        }

        public async Task Active(int imageId, CancellationToken cancellationToken)
        {
            ImageDto image = await _imageRipository.Getdetail(imageId, cancellationToken);
            image.IsAccepted=true;
           await _imageRipository.Update(image, cancellationToken);
        }

        public async Task Diactivate(int imageId, CancellationToken cancellationToken)
        {
            ImageDto image = await _imageRipository.Getdetail(imageId, cancellationToken);
            image.IsAccepted = false;
            await _imageRipository.Update(image, cancellationToken);
        }

        public async Task<ImageDto> Getdetail(int imageId, CancellationToken cancellationToken)
        {
           return await _imageRipository.Getdetail(imageId, cancellationToken);
        }

        public async Task SoftDelete(int imageId, CancellationToken cancellationToken)
        {
            ImageDto image = await _imageRipository.Getdetail(imageId, cancellationToken);
            image.Isdeleted = true;
            await _imageRipository.Update(image, cancellationToken);
        }

        public async Task UndoDelete(int imageId, CancellationToken cancellationToken)
        {
            ImageDto image = await _imageRipository.Getdetail(imageId, cancellationToken);
            image.Isdeleted = false;
            await _imageRipository.Update(image, cancellationToken);
        }

        public async Task Update(ImageDto image, CancellationToken cancellationToken)
        {
            await _imageRipository.Update(image, cancellationToken);
        }

        public async Task<int> Upload(string path,bool isProfile, CancellationToken cancellationToken)
        {
           return await _imageRipository.Upload( path,isProfile , cancellationToken);
        }

        public async Task UploadProductImage(ProductImageDto image, CancellationToken cancellationToken)
        =>await _imageRipository.UploadProductImage( image, cancellationToken);
    }
}
