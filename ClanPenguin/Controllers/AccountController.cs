using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using ClanPenguin.ViewModels;
using ClanPenguin.Models;

namespace ClanPenguin.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            RegisterViewModel Register = new RegisterViewModel
            {
                Name = "Sign up",
                Navbar = false,
                Sidebar = false
            };
            return View(Register);
        }

        [HttpGet]
        public IActionResult Login()
        {
            LoginViewModel login = new LoginViewModel
            {
                Name = "Login",
                Navbar = false,
                Sidebar = false
            };
            return View(login);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            User user = new User
            {
                UserName = vm.UserName,
                Email = vm.EmailAddress
            };
            var identityResult = await _userManager.CreateAsync(user, vm.Password);
            if (identityResult.Succeeded)
            {
                await _signInManager.SignInAsync(user, false);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                foreach (var Error in identityResult.Errors)
                {
                    ModelState.AddModelError("", Error.Description);
                }
                return View(vm);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            var result = await _signInManager.PasswordSignInAsync(vm.Email, vm.Password, vm.RememberMe, false);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("", "Invalid Login");
            return View(vm);
        }
    }
}