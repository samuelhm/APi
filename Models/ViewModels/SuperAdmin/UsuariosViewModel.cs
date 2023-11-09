using LostArkOffice.Models.DataModels;
using Microsoft.AspNetCore.Identity;

namespace LostArkOffice.Models.ViewModels.SuperAdmin
{
    public class UsuariosViewModel
    {
        public string NombreUsuario {  get; set; }
        public string? Gremio { get; set; }
        public string? Roles { get; set; }
        public string Email { get; set; }
    }
}
