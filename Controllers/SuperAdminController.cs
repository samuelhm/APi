using LostArkOffice.Models.DataModels;
using LostArkOffice.Models.ViewModels.SuperAdmin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LostArkOffice.Controllers
{
    [Authorize(Roles = "SuperAdmin")]
    public class SuperAdminController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<Usuario> _userManager;
        private readonly ILogger<SuperAdminController> _logger;

        public SuperAdminController(RoleManager<IdentityRole> roleManager,UserManager<Usuario> userManager, ILogger<SuperAdminController> logger)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _logger = logger;
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
            var usuariosimportados = await _userManager.Users.Include(u => u.Gremio).ToListAsync();

            var modelosvista = new List<UsuariosViewModel>();

            foreach ( var user in usuariosimportados ) //rellenar modelosvista con todos los usuarios
            {
                var roles = await _userManager.GetRolesAsync(user);
                var userviewmodel = new UsuariosViewModel
                {
                    NombreUsuario = user.UserName,
                    Gremio = user.Gremio?.Nombre,
                    Roles = string.Join(", ", roles), // Concatenar todos los roles en una cadena
                    Email = user.Email

                };
                modelosvista.Add(userviewmodel);
            }
            ViewBag.ListaRoles = _roleManager.Roles.ToList();
            ViewBag.Title = "Usuarios";
            return View(modelosvista);
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AsignarRol(string userID,string rolID)
        {

            var Usuario = await _userManager.FindByNameAsync(userID);
            if (Usuario == null) return Json(new { success = false, message = "Usuario no encontrado" });
            var Rol = await _roleManager.FindByIdAsync(rolID);
            if (Rol == null) return Json(new { success = false, message = "Rol no existe" });
            var rolesExistentes = await _userManager.GetRolesAsync(Usuario);
            if (rolesExistentes.Count == 0)
            {
                var result = await _userManager.AddToRoleAsync(Usuario,Rol.Name);
                return Json(new { success = result.Succeeded, message = result.Succeeded ? "Operación exitosa" : "Error en la operación" });
            }
            if (rolesExistentes.Contains(Rol.Name)) { var result = await _userManager.RemoveFromRoleAsync(Usuario, Rol.Name); return Json(result); }
            else { var result = await _userManager.AddToRoleAsync(Usuario, Rol.Name); return Json(new { success = result.Succeeded, message = result.Succeeded ? "Operación exitosa" : "Error en la operación" }); }

        }

    }
}
