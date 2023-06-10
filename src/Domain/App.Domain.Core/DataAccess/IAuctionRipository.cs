﻿using App.Domain.Core.DtoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.DataAccess
{
    public interface IAuctionRipository
    {
        Task<AuctionDto> GetDatail(int auctionId, CancellationToken cancellationToken);
        Task Create(AuctionDto auction, CancellationToken cancellationToken);
        Task<List<AuctionDto>> GetAll(CancellationToken cancellationToken);
        Task Update(AuctionDto auction, CancellationToken cancellationToken);
        
    }
}
