using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeorgeSite.Models.Data;
using GeorgeSite.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace GeorgeSite.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private UserManager<IdentityUser> _userManager;
        private SignInManager<IdentityUser> _signInManager;
        private RoleManager<IdentityRole> _roleManager;
        private IRepositoryWrapper context;
        private string _role;
        private IConfiguration _configuration;
        public AccountController(IRepositoryWrapper dBcontext, UserManager<IdentityUser> userManager,
        SignInManager<IdentityUser> signInManager,
        RoleManager<IdentityRole> roleManager, IConfiguration _configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            context = dBcontext;
            this._configuration = _configuration;
        }
        [AllowAnonymous]
        public IActionResult Index()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }
            else
                return RedirectToAction("Index", "Home");
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginModel)
        {
            if (ModelState.IsValid)
            {
                IdentityUser user =
                await _userManager.FindByEmailAsync(loginModel.Email);

                if (user != null)
                {
                    var result = await _signInManager.PasswordSignInAsync(user,
                    loginModel.Password, false, false);
                    if (result.Succeeded)
                    {
                        return Redirect(loginModel?.ReturnUrl ?? "/Home/Index");
                    }
                }
            }
            ModelState.AddModelError("", "Invalid username or password");
            return  View(loginModel);
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Register()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerModel )
        {

            //get reCAPTHCA key from appsettings.json
           // ViewData["ReCaptchaKey"] = _configuration.GetSection("GoogleReCaptcha:key").Value;

            if (ModelState.IsValid)
            {
                var uemail = context.UserRepository.FindByCondition(s => s.Email == registerModel.Email || s.Phone == registerModel.Phone);
                if (uemail.Count() > 0)
                {
                    ModelState.AddModelError("", "email has already been used or phone number already used");
                    return View(registerModel);
                }
                registerModel.Role = "standard user";
                if (await _roleManager.FindByNameAsync(registerModel.Role) == null)  //must check if role exists every time
                {
                    await _roleManager.CreateAsync(new IdentityRole(registerModel.Role));
                }
                var user = new IdentityUser
                {

                    Email = registerModel.Email,
                    UserName = registerModel.Email,
                    PhoneNumber = registerModel.Phone
                };

                var result = await _userManager.CreateAsync(user, registerModel.Password);
                if (result.Succeeded)
                {
                    Models.Entities.User user1 = new Models.Entities.User
                    {
                        Email = registerModel.Email,
                        Phone = registerModel.Phone,
                        address = registerModel.address,
                        Name = registerModel.Name,
                        Surname = registerModel.Surname,
                    };
                    context.UserRepository.Create(user1);
                    context.UserRepository.Save();
                    await _userManager.AddToRoleAsync(user, registerModel.Role);
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    string s = " ";
                    foreach (var err in result.Errors)
                    {
                        s += err.Code + " " + err.Description + "\n";
                    }
                    ModelState.AddModelError(string.Empty, "Unable to register new user " + s);
                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Unable to register new user");
            }

            return View(registerModel);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }
    }
}