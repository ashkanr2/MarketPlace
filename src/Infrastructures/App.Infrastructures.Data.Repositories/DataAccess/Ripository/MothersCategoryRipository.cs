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
    public class MothersCategoryRipository : IMothersCategoryRipository
    {
        private readonly MarketPlaceDb _context;
        private readonly IMapper _mapper;
        public MothersCategoryRipository(MarketPlaceDb context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task Create(string title, CancellationToken cancellationToken)
        {
            MothersCategory item = new MothersCategory()
            {
                Title = title,
                IsDeleted = false,
            };
            try
            {
                await _context.MothersCategorys.AddAsync(item);
                await _context.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                //_loger.LogError("Error in add new Booth {exception}", ex);
            }
        }

        public async Task<List<MothersCategoryDto>> GetAll(CancellationToken cancellationToken)
        =>_mapper.Map<List<MothersCategoryDto>> (await _context.MothersCategorys.AsNoTracking().ToListAsync());

        public async Task<MothersCategoryDto> GetDatail(int motherCategoryId, CancellationToken cancellationToken)
        =>_mapper.Map<MothersCategoryDto>(await _context.MothersCategorys.AsNoTracking().Where(a=>a.Id == motherCategoryId).ToListAsync());    

        public async Task HardDelted(int motherCategoryId, CancellationToken cancellationToken)
        {
            var motherCategory = await _context.MothersCategorys.FindAsync(motherCategoryId);
            if (motherCategory != null)
            {
                _context.MothersCategorys.Remove(motherCategory);
                await _context.SaveChangesAsync(cancellationToken);
            }
        }
        public async Task SoftDelete(int motherCategoryId, CancellationToken cancellationToken)
        {
           var item = await GetDatail(motherCategoryId, cancellationToken);
            item.IsDeleted=true;
            await _context.SaveChangesAsync();
        }

        public Task Update(MothersCategoryDto motherCategory, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
