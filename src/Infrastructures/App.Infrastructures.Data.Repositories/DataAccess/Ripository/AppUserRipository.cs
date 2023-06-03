using App.Domain.Core.DataAccess;
using App.Domain.Core.DtoModels;
using App.Domain.Core.Entities;
using App.Infrastructures.Db.SqlServer.Ef.DataBase;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructures.Data.Repositories.DataAccess.Ripository
{
    public class AppUserRipository:IAppUserRipositry
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly MarketPlaceDb _marketPlaceDb;
        public AppUserRipository(UserManager<AppUser> userManager, MarketPlaceDb marketPlaceDb)
        {
            _userManager = userManager;
            _marketPlaceDb = marketPlaceDb;
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
       
    }
}
