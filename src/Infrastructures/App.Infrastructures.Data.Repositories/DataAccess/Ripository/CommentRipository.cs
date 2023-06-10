using App.Domain.Core.DataAccess;
using App.Domain.Core.DtoModels;
using App.Domain.Core.Entities;
using App.Infrastructures.Db.SqlServer.Ef.DataBase;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructures.Data.Repositories.DataAccess.Ripository
{
    public class CommentRipository : ICommentRipository
    {
        private readonly IMapper _mapper;
        private readonly MarketPlaceDb _context;

        public CommentRipository(IMapper mapper, MarketPlaceDb context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task Create(CommentDto comment, CancellationToken cancellationToken)
        {
            var record = _mapper.Map<Comment>(comment);
            record.CreatedAt = DateTime.Now;
            record.IsAccepted = false;
            try
            {
                await _context.Comments.AddAsync(record);
                await _context.SaveChangesAsync(cancellationToken);

            }
            catch (Exception ex)
            {
                //_loger.LogError("Error in add new Comment {exception}", ex);
            }
        }

        public async Task<List<CommentDto>> GetAll(CancellationToken cancellationToken)
          => _mapper.Map<List<CommentDto>>(await _context.Comments.
            ToListAsync(cancellationToken));

        public async Task<CommentDto> GetDatail(int commentId, CancellationToken cancellationToken)
         => await Task.FromResult(_mapper.Map<CommentDto>(await _context.Comments
             .AsNoTracking()
             .Where(x => x.Id == commentId)
              .FirstOrDefaultAsync(cancellationToken)));

        public async Task HardDelted(int commentId, CancellationToken cancellationToken)
        {
            var comment = await _context.Comments
             .Where(x => x.Id == commentId)
             .FirstOrDefaultAsync(cancellationToken);
            if (comment != null) 
            {
                _context.Remove<Comment>(comment); 
                try
                {
                    await _context.SaveChangesAsync(cancellationToken);

                }
                catch (Exception ex)
                {
                    //_loger.LogError("Error in HardDelete order {exception}", ex);
                }
            }
        }

        public async Task SoftDelete(int commentId, CancellationToken cancellationToken)
        {
            var comment = await _context.Comments
             .Where(x => x.Id == commentId)
             .FirstOrDefaultAsync();
            comment.IsDeleted = true;
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task Update(CommentDto comment, CancellationToken cancellationToken)
        {
            var record =  await _context.Comments
                  .Where(x => x.Id == comment.Id).FirstOrDefaultAsync(cancellationToken);
        
            if (record != null)
            {
                record.Comment1 = comment.Comment1;
                record.IsDeleted=comment.IsDeleted;
                record.IsAccepted= comment.IsAccepted;

            }
            await _context.SaveChangesAsync();
        }
    }
}
