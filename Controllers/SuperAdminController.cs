using LostArkOffice.Models.DataModels;
using LostArkOffice.Models.ViewModels.SuperAdmin;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LostArkOffice.Controllers
{
    public class SuperAdminController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<Usuario> _userManager;
        
        public SuperAdminController(RoleManager<IdentityRole> roleManager,UserManager<Usuario> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            ViewBag.Title = "Lista Super Administrador";
            return View();
        }
        public IActionResult ClasesDePersonaje()
        {
            ViewBag.Title = "ClasesDePersonaje";
            return View();
        }
        public IActionResult Disponibilidades()
        {
            ViewBag.Title = "Disponibilidades";
            return View();
        }
        public IActionResult Gremios()
        {
            ViewBag.Title = "Gremios";
            return View();
        }
        public IActionResult Personajes()
        {
            ViewBag.Title = "Personajes";
            return View();
        }
        public IActionResult Raids()
        {
            ViewBag.Title = "Raids";
            return View();
        }
        public async Task<IActionResult> Roles()
        {
            var model = new RolesViewModel
            {
                Roles = await _roleManager.Roles.ToListAsync()
            };
            ViewBag.Title = "Roles";
            return View(model);
        }
        public IActionResult TiposDeRaid()
        {
            ViewBag.Title = "Tipos de Raid";
            return View();
        }
        public async Task<IActionResult> Usuarios()
        {
            var model = new UsuariosViewModel
            {
                Usuarios = await _userManager.Users.Include(u => u.Gremio).ToListAsync()
            };
            ViewBag.Title = "Usuarios";
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CrearRol(RolesViewModel modelo)
        {
            if (ModelState.IsValid) 
            { 
                IdentityRole nuevoRol = new IdentityRole(modelo.NombreRol);
                IdentityResult resultado = await _roleManager.CreateAsync(nuevoRol);
                if (resultado.Succeeded)
                {
                    return RedirectToAction("Roles");
                }
                foreach (var error in resultado.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return RedirectToAction("Roles");
        }

    }
}
