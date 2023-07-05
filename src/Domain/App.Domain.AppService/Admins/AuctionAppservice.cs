using App.Domain.Core.AppServices.Admin;
using App.Domain.Core.AppServices.Admins;
using App.Domain.Core.DataAccess;
using App.Domain.Core.DtoModels;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppService.Admins
{
    public class AuctionAppservice : IAuctionAppservice
    {
        private readonly IAuctionRipository _auctionRipository;
        private readonly IMapper _mapper;
        private readonly IProductAppservice _productAppservice;
        public AuctionAppservice(IAuctionRipository auctionRipository, IMapper mapper)
        {
            _auctionRipository = auctionRipository;
            _mapper = mapper;
        }

        public async Task Create(AuctionDto auction, CancellationToken cancellationToken)
        {

            await _auctionRipository.Create(auction, cancellationToken);
            var product = await _productAppservice.GetDetail(auction.ProductId, cancellationToken);
            product.IsAvailable = false;
            await _productAppservice.Update(product, cancellationToken);
        }

        public async Task<List<AuctionDto>> GetAll(int BoothId, CancellationToken cancellationToken)
        => await _auctionRipository.GetAll(BoothId, cancellationToken);

        public async Task<List<AuctionDto>> GetAllAllActions(CancellationToken cancellationToken)
       => await _auctionRipository.GetAllAllActions(cancellationToken);

        public async Task<List<ProductDto>> GetAllProductsAuction(CancellationToken cancellationToken)
        {
            var allAuctions = await _auctionRipository.GetAllAllActions(cancellationToken);
            var currentDate = DateTime.Now;

            var productsInAuction = allAuctions
               .Where(a => a.StartTime <= currentDate && a.EndTime > currentDate)
                .Select(a => a.Product)
                .ToList();

            return productsInAuction;

        }

        public async Task<AuctionDto> GetDatail(int auctionId, CancellationToken cancellationToken)
         => await _auctionRipository.GetDatail(auctionId, cancellationToken);
        

        public async Task Update(AuctionDto auction, CancellationToken cancellationToken)
        =>await _auctionRipository.Update(auction, cancellationToken);

    }
}
