using AlumniPortal.Shared;
using AlumniPortal.Shared.Models;
using AlumniPortal.Shared.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlumniPortal.API.Services
{
    public interface IUserService
    {
        Task<ResponseModel> RegisterUserAsync(RegisterModel model);
        Task<ResponseModel> LoginAsync(LoginModel model);
    }
}
