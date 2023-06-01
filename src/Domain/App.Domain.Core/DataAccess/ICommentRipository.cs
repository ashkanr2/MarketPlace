using App.Domain.Core.DtoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.DataAccess
{
    public interface ICommentRipository
    {
        
        Task<List<CommentDto>> GetAll(CancellationToken cancellationToken);
        Task<CommentDto> GetDatail(int commentId, CancellationToken cancellationToken);
        Task Create(CommentDto comment, CancellationToken cancellationToken);
        Task Update(CommentDto comment, CancellationToken cancellationToken);
        Task SoftDelete(int commentId, CancellationToken cancellationToken);
        Task HardDelted(int commentId, CancellationToken cancellationToken);
    }
}
