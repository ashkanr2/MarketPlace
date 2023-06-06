﻿using App.Domain.Core.DataAccess;
using App.Domain.Core.Entities;
using App.Domain.Core.DtoModels;
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
    public class BoothRipository : IBoothRipository
    {
        private readonly IMapper _mapper;
        private readonly MarketPlaceDb _context;

        public BoothRipository(IMapper mapper, MarketPlaceDb context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task Create(BoothDto booth, CancellationToken cancellationToken)
        {
            var record = _mapper.Map<Booth>(booth);
            record.CreatedAt = DateTime.Now;
            record.IsCreated = false;
            try
            {
                await _context.Booths.AddAsync(record);
                await _context.SaveChangesAsync(cancellationToken);

            }
            catch (Exception ex)
            {
                //_loger.LogError("Error in add new Order {exception}", ex);
            }

        }

        public async Task<List<BoothDto>> GetAll(CancellationToken cancellationToken)
         => _mapper.Map<List<BoothDto>>(await _context.Booths.ToListAsync(cancellationToken));

        public async Task<BoothDto> GetDatail(int boothId, CancellationToken cancellationToken)
        { var booth = await _context.Booths.AsNoTracking()
             .Where(x => x.Id == boothId).FirstOrDefaultAsync(cancellationToken);
            return _mapper.Map<BoothDto>(booth);
           
        }     

        public async Task HardDelted(int boothId, CancellationToken cancellationToken)
        {
            var comment = await _context.Booths
              .Where(x => x.Id == boothId)
              .FirstOrDefaultAsync(cancellationToken);
            _context.Remove(comment);
            try
            {
                await _context.SaveChangesAsync(cancellationToken);

            }
            catch (Exception ex)
            {
                //_loger.LogError("Error in HardDelete order {exception}", ex);
            }

        }

        public async Task SoftDelete(int boothId, CancellationToken cancellationToken)
        {
            var record = await _context.Booths
                .Where(x => x.Id == boothId)
                .FirstOrDefaultAsync();
            record.IsDeleted = true;
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task Update(BoothDto booth, CancellationToken cancellationToken)
        {
            //var record = await _mapper.ProjectTo<BoothDto>(_context.Set<BoothDto>())
            //      .Where(x => x.Id == booth.Id).FirstOrDefaultAsync();
            //_mapper.Map(booth, record);
            //await _context.SaveChangesAsync(cancellationToken);

            var record = await _context.Booths
                .Where(x => x.Id == booth.Id)
                .FirstOrDefaultAsync();
            record.IsCreated = booth.IsCreated;
            try
            {
                await _context.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                //_loger.LogError("Error in update Booth {exception}", ex);
            }
        }
    }
}
