// ReSharper disable Mvc.ViewNotResolved
namespace SuLnu.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using SuLnu.BLL.Interfaces;
    using SuLnu.DAL.Entities;
    using SuLnu.Models;
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    public class LoginController : Controller
    {
        private readonly ISignInService _signInService;
        private readonly ILogger<LoginController> _logger;
        private readonly UserManager<AppUser> _userManager;


        public LoginController(ISignInService signInService, ILogger<LoginController> logger, UserManager<AppUser> userManager)
        {
            this._signInService = signInService;
            this._logger = logger;
            this._userManager = userManager;

        }

        public async Task<IActionResult> Index()
        {
            await this.HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            return this.View();
        }

        public async Task<IActionResult> Login(LoginViewModel loginInputModel)
        {
            if (this.ModelState.IsValid)
            {
                var user = this._userManager.FindByNameAsync(loginInputModel.UserName);
                //if (user.Result != null && user.Result.IsBlocked)
                //{
                //    this.ModelState.AddModelError("RememberMe", "You are blocked.");
                //    return this.View("Index");
                //}

                var result = await this._signInService.PasswordSignInAsync(loginInputModel.UserName, loginInputModel.Password, loginInputModel.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    this._logger.LogInformation("User logged in.");
                    return this.RedirectToAction("Index", "Home");
                }

                if (result.IsLockedOut)
                {
                    this._logger.LogWarning("User account locked out.");
                    return this.RedirectToPage("./Lockout");
                }
                else
                {
                    this.ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return this.View("Index");
                }
            }

            return this.View("Index");
        }
    }
}