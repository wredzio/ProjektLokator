using ProjectLocator.Database.Models.Applications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectLocator.Web.Areas.Appliaction.Users
{
    public interface IUserMapper
    {
        ApplicationUser MapToApplicationUser(RegisterDto registerDto);
    }
}
