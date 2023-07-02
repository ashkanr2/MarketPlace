using App.Domain.Core.DtoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.DataAccess
{
    public interface IImageRipository
    {
        Task <ImageDto> Getdetail(int imageId, CancellationToken cancellationToken);
        Task <List<ImageDto>> GetProductImages(int pId, CancellationToken cancellationToken);
        Task<int> Upload(string path, bool isProfile, CancellationToken cancellationToken);
        Task Update(ImageDto imageFile, CancellationToken cancellationToken);

    }
}
