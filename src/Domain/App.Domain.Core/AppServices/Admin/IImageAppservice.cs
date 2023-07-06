using App.Domain.Core.DtoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.AppServices.Admin
{
    public interface IImageAppservice
    {
        Task Update(ImageDto image, CancellationToken cancellationToken);
        Task UploadProductImage(ProductImageDto image, CancellationToken cancellationToken);
        Task<int> Upload(string path, bool isProfile, CancellationToken cancellationToken);
        Task Active(int imageId, CancellationToken cancellationToken);
        Task Diactivate(int imageId, CancellationToken cancellationToken);
        Task SoftDelete(int imageId, CancellationToken cancellationToken);
        Task UndoDelete(int imageId, CancellationToken cancellationToken);
        Task<ImageDto> Getdetail(int imageId, CancellationToken cancellationToken);
    }
}
