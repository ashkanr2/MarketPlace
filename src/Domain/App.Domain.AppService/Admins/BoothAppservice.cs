using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core.AppServices.Admins;
using App.Domain.Core.DataAccess;
using App.Domain.Core.DtoModels;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace App.Domain.AppService.Admins
{
    public class BoothAppservice : IBoothAppservice
    {
        private readonly IBoothRipository _boothRipository;
        private readonly IMapper _mapper;

        public BoothAppservice(IBoothRipository boothRipository, IMapper mapper)
        {
            _boothRipository = boothRipository;
            _mapper = mapper;
        }

        public async Task Active(int boothId, CancellationToken cancellationToken)
        {
            var booth = await _boothRipository.GetDatail(boothId,cancellationToken);
            booth.IsCreated = true;
             await _boothRipository.Update( booth, cancellationToken);
        }

        public async Task Create(BoothDto booth, CancellationToken cancellationToken)
        {
           await _boothRipository.Create(booth, cancellationToken);
        }

        public async Task DiActive(int boothId, CancellationToken cancellationToken)
        {
            var booth = await _boothRipository.GetDatail(boothId, cancellationToken);
            booth.IsCreated = false;
            await Update(booth, cancellationToken);
        }

        public async Task<List<BoothDto>> GetAll( CancellationToken cancellationToken)
        {
           return await _boothRipository.GetAll(cancellationToken);
        }

        public async Task<BoothDto> Getbooth(int userId, CancellationToken CancellationToken)
        {
            var result = (await _boothRipository.GetAll(CancellationToken)).Where(a => a.OwnerUserId == userId).FirstOrDefault();
           var Booth =_mapper.Map<BoothDto>(result);
            return Booth;
        }

        public async Task<List<BoothDto>> GetCitiesBooth(int cityId, CancellationToken cancellationToken)
        {
            var allBooth = await _boothRipository.GetAll(cancellationToken);
            return await allBooth.Where(c => c.CityId == cityId).AsQueryable().ToListAsync(cancellationToken);

        }

        public async Task<BoothDto> GetDatail(int boothId, CancellationToken cancellationToken)
        {
           return await _boothRipository.GetDatail(boothId, cancellationToken);
        }

        public async Task<AppUserDto> GetOwnerbooth(int BoothId, CancellationToken CancellationToken)
        {
            var booth = await _boothRipository.GetDatail(BoothId, CancellationToken);
            var user = _mapper.Map<AppUserDto>(booth.OwnerUser);
            return user;
        }

        public async Task<BoothDto> GetUserBooth(int userId, CancellationToken cancellationToken)
        {
           var booths = await _boothRipository.GetAll(cancellationToken);
           return _mapper.Map<BoothDto>(booths.Where(x=>x.OwnerUserId == userId).FirstOrDefault());
            
        }

        public async Task HardDelted(int boothId, CancellationToken cancellationToken)
        {
            await _boothRipository.HardDelted(boothId, cancellationToken);
        }

        public async Task SoftDelete(int boothId, CancellationToken cancellationToken)
        {
            await _boothRipository.SoftDelete(boothId, cancellationToken);
        }

        public async Task Update(BoothDto booth, CancellationToken cancellationToken)
        {
            await _boothRipository.Update(booth, cancellationToken);
        }
    }
}
