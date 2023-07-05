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
        public async Task<IdentityResult> SignUpAsync(AppUserDto userDto, CancellationToken CancellationToken)
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
        public async Task <List<AppUserDto>> GetAll(CancellationToken CancellationToken)
        {
            try
            {
                var users = await _context.AppUsers.ToListAsync(CancellationToken);
                var userDtos = _mapper.Map<List<AppUserDto>>(users);
                return userDtos;
            }
            catch (Exception ex)
            {
                // Log the exception here using your preferred logging framework
                // For example, using Serilog:
                //Log.Error(ex, "Error getting all users");
                throw;
            }
        }
        public async Task<AppUserDto>GetDetail(int userId,CancellationToken CancellationToken)
        {
            var user = _mapper.Map < AppUserDto > (await _context.AppUsers.Include(i=>i.UserProfileImage).Where(x=>x.Id == userId).FirstOrDefaultAsync(CancellationToken));
            string[] parts = user.UserProfileImage.Path.Split("_+_");
            string filename = parts[0];
            user.UserProfileImage.Path = filename;
            return user;
        }

        public async Task Update(AppUserDto appuser, CancellationToken CancellationToken)
        {
            var record = await _context.AppUsers
               .Where(x => x.Id == appuser.Id)
               .FirstOrDefaultAsync();
            if(record != null)
            {
                record.Name=appuser.Name;
                record.LastName=appuser.LastName;
                record.Address=appuser.Address;
                record.IsCreated= appuser.IsCreated;
                record.IsDeleted= appuser.IsDeleted;
                record.BuyerMedalId= appuser.BuyerMedalId;
                record.CountOfBuy= appuser.CountOfBuy;
                record.UserProfileImageId= appuser.UserProfileImageId;
                record.IsSeller= appuser.IsSeller;
                record.Wallet= appuser.Wallet;

            }
            
            try
            {
                    await _context.SaveChangesAsync(CancellationToken);
            }
            catch (Exception ex)
            {
                //_loger.LogError("Error in update user {exception}", ex);
            }
        }

        public async Task<bool> Exists(string email, CancellationToken cancellationToken)
        {
          var user = await _context.AppUsers.Where(x=>x.Email == email).FirstOrDefaultAsync();
            if (user == null) return false;
            else return true;
        }

        public async Task<List<string>> GetRoles(int userId, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FindAsync(userId);

            if (user == null)
            {
                // You can throw an exception or return null as appropriate
                throw new ArgumentException($"User with ID {userId} not found");
            }


            var roles = (await _userManager.GetRolesAsync(user)).ToList();

            return roles;
        }

        public async Task IncreaseWallet(int userId, int amount, CancellationToken CancellationToken)
        {
            var user = _mapper.Map<AppUserDto>(await _context.Users.AsNoTracking().Where(a=>a.Id==userId).FirstOrDefaultAsync());
            user.Wallet= user.Wallet + amount;
            
            await Update(user, CancellationToken);
        }

        public async Task DecreaseWallet(int userId, int amount, CancellationToken CancellationToken)
        {
            var user = _mapper.Map<AppUserDto>(await _context.Users.AsNoTracking().Where(a => a.Id == userId).FirstOrDefaultAsync());
            user.Wallet = user.Wallet - amount;

            await Update(user, CancellationToken);
        }
    }
}
