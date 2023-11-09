using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using LostArkOffice.Models.ViewModels;
using LostArkOffice.Models.DataModels;
using System.ComponentModel.DataAnnotations;

namespace LostArkOffice.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<Usuario> _userManager;
        private readonly SignInManager<Usuario> _signInManager;
        private readonly ILogger<AccountController> _logger;
        public AccountController(UserManager<Usuario> userManager, SignInManager<Usuario> signInManager, ILogger<AccountController> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }
        [HttpGet]
        public  IActionResult Login(string returnUrl = null)
        {
            ViewBag.Title = "Login";
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;

            if (ModelState.IsValid)
            {
                var userName = model.UsernameOrEmail;
                if (new EmailAddressAttribute().IsValid(model.UsernameOrEmail))
                {
                    // Si es un email, buscar el nombre de usuario correspondiente
                    var user = await _userManager.FindByEmailAsync(model.UsernameOrEmail);
                    if (user != null)
                    {
                        userName = user.UserName;
                    }
                }
                var result = await _signInManager.PasswordSignInAsync(userName, model.Password, model.RememberMe, lockoutOnFailure: false);

                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                        return RedirectToAction("index", "home");
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Intento de inicio de sesión inválido.");
                }
            }

            return View(model);
        }
        [HttpGet]
        public IActionResult Register()
        {
            ViewBag.Title = "Register";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new Usuario { UserName = model.Username, Email = model.Email, Nombre = model.Username };
                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("index", "home");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            _logger.LogInformation("User logged out.");
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> IsEmailInUse(string email)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(email);
                if (user == null)
                {
                    return Json(true);
                }
                else
                {
                    return Json($"Email {email} is already in use.");
                }
            }
            catch (Exception ex)
            {
                // Log the exception
                _logger.LogError(ex, "Error checking email");

                // Return a generic error message or a detailed one based on your error handling policy
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        [HttpGet]
        public async Task<IActionResult> IsUserInUse(string username)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(username);
                if (user == null)
                {
                    return Json(true);
                }
                else
                {
                    return Json($"Usuario {username} Está en uso.");
                }
            }
            catch (Exception ex)
            {
                // Log the exception
                _logger.LogError(ex, "Error checking User");

                // Return a generic error message or a detailed one based on your error handling policy
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
    }
}
