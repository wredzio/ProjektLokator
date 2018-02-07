using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectLocator.Database.Models.Applications;

namespace ProjectLocator.Web.Areas.Appliaction.Users
{
    public class UserMapper : IUserMapper
    {
        public ApplicationUser MapToApplicationUser(RegisterDto registerDto)
        {
            return new ApplicationUser()
            {
                Email = registerDto.Email,
                UserName = registerDto.Username
            };
        }
    }
}
