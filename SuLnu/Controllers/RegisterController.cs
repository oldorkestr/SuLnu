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
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SuLnu.Controllers
{
    public class RegisterController : Controller
    {
        private readonly IUserService _userService;
        private readonly ISignInService _signInService;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly IEmailSender _emailSender;

        public RegisterController(
            IEmailSender emailSender,
            IUserService userService,
            ISignInService signInService,
            SignInManager<AppUser> signInManager,
            UserManager<AppUser> userManager)
        {
            this._userManager = userManager;
            this._userService = userService;
            this._emailSender = emailSender;
            this._signInService = signInService; 
            this._signInManager = signInManager;
        }

        
        public IActionResult Register()
        {
            var nameFaculties = new SelectList(new List<string>()
            {
                  "Applied mathematics and computer science" ,
                 "Electronics" ,
                 "Philology" ,
                 "Mechanics and Mathematics" 
            });

            this.ViewBag.faculties = nameFaculties;

            var Courses = new SelectList(new List<int>()
            {
                  1,2,3,4,5,6
            });

            this.ViewBag.courses = Courses;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterInputModel registerInputModel, string faculties, int course)
        {
            var nameFaculties = new SelectList(new List<string>()
            {
                  "Applied mathematics and computer science" ,
                 "Electronics" ,
                 "Philology" ,
                 "Mechanics and Mathematics"
            });

            this.ViewBag.faculties = nameFaculties;

            var Courses = new SelectList(new List<int>()
            {
                  1,2,3,4,5,6
            });

            this.ViewBag.courses = Courses;
            if (ModelState.IsValid)
            {
                var user = new UserDTO
                {
                    Email = registerInputModel.Email,
                    FirstName = registerInputModel.FirstName,
                    LastName = registerInputModel.LastName,
                    Course = registerInputModel.Course
                };

                var result = await _userService.CreateUserAsync(user, registerInputModel.Password);
                if (result.Succeeded)
                {
                    user = await this._userService.GetByEmailAsync(user.Email);

                    var code = await this._userService.GenerateEmailConfirmationTokenAsync(user.Id);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = this.Url.Action(
                         "ConfirmEmail", "Register",
                         new { userId = user.Id, code = code },
                         protocol: this.Request.Scheme);

                    await this._emailSender.SendEmailAsync(registerInputModel.Email, "Confirm your email",
                        $"Please confirm your registration at SuLnu website by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    if (this._userService.RequireConfirmedAccount())
                    {
                        return this.RedirectToAction("Confirmation", new { email = registerInputModel.Email });
                    }
                    else
                    {
                        await this._signInService.SignInAsync(user, false);
                        return this.RedirectToAction("Register");
                    }
                }

                foreach (var error in result.Errors)
                {
                    this.ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View("Register");
        }

        public async Task<IActionResult> Confirmation(string email)
        {
            if (email == null)
            {
                return this.RedirectToAction("Index");
            }

            var user = await this._userService.GetByEmailAsync(email);
            if (user == null)
            {
                return this.NotFound($"Unable to load user with email '{email}'.");
            }

            var viewModel = new RegisterConfirmationViewModel();

            viewModel.DisplayConfirmAccountLink = false;

            return this.View(viewModel);
        }

        public async Task<IActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return this.RedirectToPage("/Index");
            }

            var user = await this._userService.GetByIdAsync(userId);
            if (user == null)
            {
                return this.NotFound($"Unable to load user with ID '{userId}'.");
            }

            code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));
            var result = await this._userService.ConfirmEmailAsync(userId, code);

            var viewModel = new ConfirmEmailViewModel
            {
                StatusMessage = result.Succeeded ? "Thank you for confirming your email" : "Error confirming your email.",
                Succeeded = result.Succeeded,
            };

            return this.View(viewModel);
        }

    }
}