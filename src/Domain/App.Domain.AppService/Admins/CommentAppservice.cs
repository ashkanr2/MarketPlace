using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core.AppServices.Admins;
using App.Domain.Core.DataAccess;
using App.Domain.Core.DtoModels;

namespace App.Domain.AppService.Admins
{
    public class CommentAppservice : ICommentAppservice
    {
        private readonly ICommentRipository _commentRipository;
    public CommentAppservice(ICommentRipository commentRipository)
        {
            _commentRipository = commentRipository;
        }

        public async Task Active(int commentId, CancellationToken cancellationToken)
        {
            var booth = await _commentRipository.GetDatail(commentId, cancellationToken);
            booth.IsAccepted = true;
            await _commentRipository.Update(booth, cancellationToken);
        }

        public async Task Create(CommentDto comment, CancellationToken cancellationToken)
        {
            await _commentRipository.Create(comment, cancellationToken);
        }

        public async Task DiActive(int commentId, CancellationToken cancellationToken)
        {
            var booth = await _commentRipository.GetDatail(commentId, cancellationToken);
            booth.IsAccepted = false;
            await _commentRipository.Update(booth, cancellationToken);
        }
       public async Task<List<CommentDto>> GetAll(CancellationToken cancellationToken)
        {
            return await _commentRipository.GetAll(cancellationToken);
        }

        public async Task<List<CommentDto>> GetAllBoothComments(int boothId, CancellationToken cancellationToken)
        => (await _commentRipository.GetAll(cancellationToken)).Where(x=>x.BoothId == boothId).ToList();



        public async Task<List<CommentDto>> GetAllOrder(int orderId, CancellationToken cancellationToken)
        => (await _commentRipository.GetAll(cancellationToken)).Where(x => x.OrderId == orderId).ToList();
        
        public async Task<List<CommentDto>> GetAllUser(int userId, CancellationToken cancellationToken)
        => (await _commentRipository.GetAll(cancellationToken)).Where(x => x.UserId == userId).ToList();

        public async Task<CommentDto> GetDatail(int commentId, CancellationToken cancellationToken)
        {
           return await _commentRipository.GetDatail(commentId, cancellationToken);
        }

        public async Task HardDelted(int commentId, CancellationToken cancellationToken)
        {
            await _commentRipository.HardDelted(commentId, cancellationToken);
        }

        public async Task SoftDelete(int commentId, CancellationToken cancellationToken)
        {
            await _commentRipository.SoftDelete(commentId, cancellationToken);
        }

        public async Task Update(CommentDto comment, CancellationToken cancellationToken)
        {
            await _commentRipository.Update(comment, cancellationToken);
        }
    }
}
