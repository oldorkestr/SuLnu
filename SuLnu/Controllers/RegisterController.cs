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
using SuLnu.BLL.DTO;
using SuLnu.Models;
using System.Text;

namespace SuLnu.Controllers
{
    public class RegisterController : Controller
    {
        private readonly IUserService _userService;
        private readonly ISignInService _signInService;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;

        public RegisterController(
            IUserService userService,
            ISignInService signInService,
            SignInManager<AppUser> signInManager,
            UserManager<AppUser> userManager)
        {
            this._userManager = userManager;
            this._userService = userService; 
            this._signInService = signInService; 
            this._signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterInputModel registerInputModel)
        {
            if (ModelState.IsValid)
            {
                var user = new UserDTO
                {
                    Email = registerInputModel.Email,
                    FirstName = registerInputModel.FirstName,
                    LastName = registerInputModel.LastName,
                    Course = registerInputModel.Course,
                    Faculty = registerInputModel.Faculty
                };

                var result = await _userService.CreateUserAsync(user, registerInputModel.Password);
                if (result.Succeeded)
                {
                    user = await _userService.GetByEmailAsync(user.Email);

                    //var code = await _userService.GenerateEmailConfirmationTokenAsync(user);
                    //code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    //var callbackUrl = Url.Page(
                    //    "/Account/ConfirmEmail",
                    //    pageHandler: null,
                    //    values: new { area = "Identity", userId = user.Id, code = code },
                    //    protocol: Request.Scheme);

                    //await _emailSender.SendEmailAsync(registerInputModel.Email, "Confirm your email",
                    //    $"Please confirm your account in askLNU website by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    if (_userService.RequireConfirmedAccount())
                    {
                        return RedirectToAction("Confirmation", new { email = registerInputModel.Email });
                    }
                    else
                    {
                        await _signInService.SignInAsync(user, false);
                        return RedirectToAction("Register");
                    }
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View("Register");
        }

        public async Task<IActionResult> Confirmation(string email)
        {
            if (email == null)
            {
                return RedirectToAction("Register");
            }

            var user = await _userService.GetByEmailAsync(email);
            if (user == null)
            {
                return NotFound($"Unable to load user with email '{email}'.");
            }

            // Once you add a real email sender, you should remove this code that lets you confirm the account

            var viewModel = new RegisterConfirmationViewModel();

            viewModel.DisplayConfirmAccountLink = true;
            if (viewModel.DisplayConfirmAccountLink)
            {
                var code = await _userService.GenerateEmailConfirmationTokenAsync(user.Id);
                code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));

                viewModel.EmailConfirmationUrl = Url.Action(
                    "ConfirmEmail",
                    "Register",
                    new { area = "Identity", userId = user.Id, code = code },
                    Request.Scheme);
            }

            return View(viewModel);
        }

        public async Task<IActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return RedirectToPage("/Register");
            }

            var user = await _userService.GetByIdAsync(userId);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{userId}'.");
            }

            code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));
            var result = await _userService.ConfirmEmailAsync(userId, code);

            var viewModel = new ConfirmEmailViewModel
            {
                StatusMessage = result.Succeeded ? "Thank you for confirming your email." : "Error confirming your email."
            };

            return View(viewModel);
        }

    }
}