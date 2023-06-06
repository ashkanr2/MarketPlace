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
using System.Threading;
using System.Threading.Tasks;

namespace App.Infrastructures.Data.Repositories.DataAccess.Ripository
{
    public class AppUserRipository:IAppUserRipositry
    {
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;
        private readonly MarketPlaceDb _context;
        public AppUserRipository(UserManager<AppUser> userManager, MarketPlaceDb marketPlaceDb, IMapper mapper)
        {
            _userManager = userManager;
            _context = marketPlaceDb;
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
            await _context.SaveChangesAsync();
            return null;
        }
        public async Task <List<AppUser>> GetAll(CancellationToken cancellation)
        {
            var users = await _context
            .AppUsers
           .ToListAsync(cancellation);
            return users;
        }
        public async Task<AppUserDto>GetDetail(int userId,CancellationToken cancellation)
        {
            var user = _mapper.Map < AppUserDto > (await _context.AppUsers.Where(x=>x.Id == userId).FirstOrDefaultAsync(cancellation));
            return user;
        }

        public async Task Update(AppUserDto appuser, CancellationToken cancellation)
        {
            var record = await _mapper.ProjectTo<AppUserDto>(_context.Set<AppUserDto>())
                 .Where(x => x.Id == appuser.Id).FirstOrDefaultAsync();
            await _context.SaveChangesAsync(cancellation);
        }
    }
}
