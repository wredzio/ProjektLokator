using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ProjectLocator.Database.Models.Applications;
using Microsoft.AspNetCore.Identity;
using ProjectLocator.Web.Controllers;
using Microsoft.Extensions.Logging;
using ProjectLocator.Web.Utils;
using ProjectLocator.Web.Exceptions;
using ProjectLocator.Web.Emails.PostBoxs;
using ProjectLocator.Web.Emails.EmailBuilders.ConfirmAccount;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectLocator.Web.Areas.Appliaction.Users
{
    [Route("api/[controller]/[action]")]
    [Authorize]
    public class UserController : Controller
    {
        private IUserService _userService;
        private IUserMapper _mapper;

        public UserController(IUserService userService, IUserMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] RegisterDto model)
        {
            if (ModelState.IsValid)
            {
                var user = _mapper.MapToApplicationUser(model);

                var result = await _userService.Register(model, user);

                if (result.Succeeded)
                {
                    return Ok(model);
                }

                return NotFound(result);
            }

            return BadRequest(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginDto model)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.Login(model);
                if (result.Succeeded)
                {
                    return Ok(model);
                }
                if (result.IsLockedOut)
                {
                    return BadRequest("Lockout");
                }
                else
                {
                    throw new UnauthorizedException("Bad Login Or Password", null, model);
                }
            }

            throw new BadRequestException("Bad Login Or Password", null, model);
        }
    }
}
