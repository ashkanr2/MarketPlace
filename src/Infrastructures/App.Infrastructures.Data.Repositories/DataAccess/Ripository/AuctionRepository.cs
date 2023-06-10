﻿using App.Domain.Core.DataAccess;
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
    public class AuctionRepository : IAuctionRipository
    {
        private readonly MarketPlaceDb _context;
        private readonly IMapper _mapper;

        public AuctionRepository(MarketPlaceDb context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task Create(AuctionDto auction, CancellationToken cancellationToken)
        {
            var record = _mapper.Map<Auction>(auction);
          
            try
            {
                await _context.Auctions.AddAsync(record);
                await _context.SaveChangesAsync(cancellationToken);

            }
            catch (Exception ex)
            {
                //_loger.LogError("Error in add new Auction {exception}", ex);
            }

        }

        public async Task<List<AuctionDto>> GetAll(CancellationToken cancellationToken)
        =>_mapper.Map<List<AuctionDto>>( await _context.Auctions
            .AsNoTracking()
            .ToListAsync(cancellationToken));

        public async Task<AuctionDto> GetDatail(int auctionId, CancellationToken cancellationToken)
        =>_mapper.Map<AuctionDto>(await _context.Auctions
            .Where(A=>A.Id == auctionId)
            .FirstOrDefaultAsync(cancellationToken));

   
        public async Task Update(AuctionDto auction, CancellationToken cancellationToken)
        {
            var record = await _context.Auctions
                .Where(a=>a.Id == auction.Id)
                .FirstOrDefaultAsync(cancellationToken);
           
            if(record != null)
            {
               record.ProductId = auction.ProductId;


            }
        }
    }
}
