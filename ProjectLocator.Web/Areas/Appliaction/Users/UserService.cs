﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using ProjectLocator.Database.Models.Applications;
using ProjectLocator.Web.Emails.EmailBuilders;
using ProjectLocator.Web.Emails.EmailBuilders.ConfirmAccount;
using ProjectLocator.Web.Emails.Model;
using ProjectLocator.Web.Emails.PostBoxs;
using ProjectLocator.Web.Exceptions;
using ProjectLocator.Web.Utils;
using Hangfire;
using Microsoft.AspNetCore.Identity;

namespace ProjectLocator.Web.Areas.Appliaction.Users
{
    public class UserService : IUserService
    {
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;
        private IEmailBuilderFactory _emailBuilderFactory;
        private IPostBox _postBox;

        public UserService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, 
             IEmailBuilderFactory emailBuilderFactory, IPostBox postBox)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailBuilderFactory = emailBuilderFactory;
            _postBox = postBox;
        }

        public async Task<SignInResult> Login(LoginDto loginDto)
        {
            var user = await _userManager.FindByNameAsync(loginDto.Username);
            if (user == null)
            {
                throw new UnauthorizedException("Bad Login Or Password", null, loginDto);
            }

            return await _signInManager.PasswordSignInAsync(user, loginDto.Password, loginDto.RememberMe, lockoutOnFailure: false);
        }

        public async Task<IdentityResult> Register(RegisterDto registerDto, ApplicationUser applicationUser)
        {
            var result = await _userManager.CreateAsync(applicationUser, registerDto.Password);

            if (result.Succeeded)
            {
                var mailMessage = await CreateConfirmEmail(registerDto, applicationUser);
                BackgroundJob.Enqueue<IPostBox>(o => o.Send(mailMessage));

                await _userManager.AddToRoleAsync(applicationUser, Roles.Headmaster.ToString());
            }

            return result;
        }

        private async Task<Email> CreateConfirmEmail (RegisterDto registerDto, ApplicationUser applicationUser)
        {
            var emailBuilder = _emailBuilderFactory.Create<ConfirmAccountTemplateModel>(EmailBuilderType.ConfirmAccount);
            emailBuilder.AddRecipient(registerDto.Email);
            emailBuilder.SetTemplateModel(new ConfirmAccountTemplateModel { UserFullName = registerDto.FirstName + registerDto.SecondName });

            return await emailBuilder.Build();
        }
    }
}
