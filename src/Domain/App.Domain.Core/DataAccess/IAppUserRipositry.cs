using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core.Entities;
using App.Domain.Core.DtoModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace App.Domain.Core.DataAccess
{
    public interface IAppUserRipositry
    {
        Task<IdentityResult> SignUpAsync(AppUserDto userDto);

        Task<List<AppUser>> GetAll(CancellationToken cancellation);

        Task<AppUserDto> GetDetail(int userId, CancellationToken cancellation);


    }
}
