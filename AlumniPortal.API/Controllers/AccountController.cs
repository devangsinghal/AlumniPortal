using AlumniPortal.API.Services;
using AlumniPortal.Shared;
using AlumniPortal.Shared.Models;
using AlumniPortal.Shared.Models.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlumniPortal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AccountController : ControllerBase
    {
        private IUserService _userService;
        public AccountController(IUserService userService)
        {
            _userService = userService;
        }
       
        /// <summary>
        /// This endpoint registers an alumni 
        /// </summary>
        /// <param name="userModel">This will have user details for registering</param>
        /// <returns></returns>
        [HttpPost("CreateUser")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(ResponseModel),200)]
        [ProducesResponseType(typeof(ResponseModel), 400)]
        public async Task<IActionResult> CreateUserAsync([FromBody]RegisterModel userModel)
        {
            var result = await _userService.RegisterUserAsync(userModel);
            if (result.IsSuccess)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginModel loginModel)
        {
            var result = await _userService.LoginAsync(loginModel);
            if (result.IsSuccess)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [HttpGet]
        public string Get()
        {
            return "Test";
        }
    }
}
