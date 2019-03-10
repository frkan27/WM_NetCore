using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreIdentity.Data;
using CoreIdentity.Data.IndetityModels;
using CoreIdentity.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CoreIdentity.Controllers
{
    public class AccountController : Controller
    {
        //dependency ınjection olan şeyleri startapa service.add diyerek eklemememiz lazım.
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationDbContext _dbContext;
        //ınject edince constructorda eşlemek lazım.ctrl. ilegelmesi lazım ama gelmedi ???? 
        //Dependency Injection
        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ApplicationDbContext dbContext, RoleManager<ApplicationRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _dbContext = dbContext;
            _roleManager = roleManager;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = new ApplicationUser()
            {
                Email = model.Email,
                Name = model.Name,
                Surname = model.Surname,
                UserName = model.UserName
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                return RedirectToAction(nameof(Login));
            }
            else
            {
                var errMsg = "";
                foreach (var identityError in result.Errors)
                {
                    errMsg += identityError.Description;
                }
                ModelState.AddModelError(String.Empty, errMsg);
                return View(model);
            }

        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }

            var result =await _signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, true);
            if (result.Succeeded)//succeeded await yazmadan gelmiyor.
            {
                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError(String.Empty, "Kullanıcı adı veya sifre hatalı");
            return View(model);
        }

        [Authorize]//Giriş yapmışlar görsğn diye yaptık.
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}