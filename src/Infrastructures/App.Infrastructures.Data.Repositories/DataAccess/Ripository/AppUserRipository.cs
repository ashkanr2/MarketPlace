using App.Domain.Core.DataAccess;
using App.Domain.Core.DtoModels;
using App.Domain.Core.Entities;
using App.Infrastructures.Db.SqlServer.Ef.DataBase;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructures.Data.Repositories.DataAccess.Ripository
{
    public class AppUserRipository:IAppUserRipositry
    {
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;
        private readonly MarketPlaceDb _marketPlaceDb;
        public AppUserRipository(UserManager<AppUser> userManager, MarketPlaceDb marketPlaceDb, IMapper mapper)
        {
            _userManager = userManager;
            _marketPlaceDb = marketPlaceDb;
            _mapper = mapper;
        }
        public async Task<IdentityResult> SignUpAsync(AppUserDto userDto)
        {
            var user = new AppUser() { 
            
              Address=userDto.Address,
              CreatAt=DateTime.Now,
              IsDeleted=false,
              IsCreated=false,
              IsSeller=false,
              Wallet=0
            };
            await _userManager.CreateAsync(user);
            await _marketPlaceDb.SaveChangesAsync();
            return null;
        }
        public async Task <List<AppUser>> GetAll(CancellationToken cancellation)
        {
            var users = await _marketPlaceDb
            .AppUsers
           .ToListAsync(cancellation);
            return users;
        }
        public async Task<AppUserDto>GetDetail(int userId,CancellationToken cancellation)
        {
            var user = _mapper.Map < AppUserDto > (await _marketPlaceDb.AppUsers.Where(x=>x.Id == userId).FirstOrDefaultAsync(cancellation));
            return user;
        }
    }
}
