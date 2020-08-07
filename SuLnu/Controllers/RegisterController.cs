using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using SuLnu.DAL.Entities;
using SuLnu.BLL.Interfaces;

namespace SuLnu.Controllers
{
    public class RegisterController : Controller
    {
        private readonly IUserService _userService;
        private readonly ISignInService _signInService;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;

        public RegisterController(
            //IUserService userService,
            //ISignInService signInService,
            SignInManager<AppUser> signInManager,
            UserManager<AppUser> userManager)
        {
            this._userManager = userManager;//works
            //this._userService = userService; //doesnt work
            //this._signInService = signInService; //doesnt work
            this._signInManager = signInManager;//works
        }


        public IActionResult Register()
        {
            return View();
        }
    }
}