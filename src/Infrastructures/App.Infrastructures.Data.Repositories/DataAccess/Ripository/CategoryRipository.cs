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
    public class CategoryRipository : ICategoryRipository
    {
        private readonly IMapper _mapper;
        private readonly MarketPlaceDb _context;

        public CategoryRipository(IMapper imapper, MarketPlaceDb context)
        {
            _mapper = imapper;
            _context = context;
        }

        public async Task Create(CategoryDto category, CancellationToken cancellationToken)
        {
            var record = _mapper.Map<Category>(category);

            try
            {
                await _context.Categorys.AddAsync(record);
                await _context.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                //_loger.LogError("Error in add new Booth {exception}", ex);
            }
        }

        public async Task<List<CategoryDto>> GetAll( CancellationToken cancellationToken)
        => _mapper.Map<List<CategoryDto>>(await _context.Categorys.AsNoTracking()
            .ToListAsync());

        public async Task<CategoryDto> GetDatail(int categoryId, CancellationToken cancellationToken)
        => _mapper.Map<CategoryDto>(await _context.Categorys.AsNoTracking().
            Where(x => x.Id == categoryId).FirstOrDefaultAsync());


        public async Task HardDelted(int categoryId, CancellationToken cancellationToken)
        {
            var category = await _context.Categorys.FindAsync(categoryId);
            if (category != null)
            {
                _context.Categorys.Remove(category);
                await _context.SaveChangesAsync(cancellationToken);
            }
        }


        public async Task Update(CategoryDto categor, CancellationToken cancellationToken)
        {
            var item = await _context.Categorys.AsNoTracking().Where(a => a.Id == categor.Id).FirstOrDefaultAsync();
            if (item != null)
            {
                item.Id = categor.Id;
                item.Title = categor.Title;
                item.MotherCategoryId = categor.MotherCategoryId;

            };
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
