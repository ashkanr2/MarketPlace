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
        Task<IdentityResult> SignUpAsync(AppUserDto userDto, CancellationToken CancellationToken);

        Task<List<AppUserDto>> GetAll(CancellationToken CancellationToken);

        Task<AppUserDto> GetDetail(int userId, CancellationToken CancellationToken);
        Task Update(AppUserDto appuser, CancellationToken CancellationToken);
        Task<bool> Exists(string email, CancellationToken CancellationToken);
        Task<List<string>> GetRoles(int userId, CancellationToken cancellationToken);

    }
}
