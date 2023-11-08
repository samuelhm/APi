using LostArkOffice.Models.DataModels;
using Microsoft.AspNetCore.Identity;

namespace LostArkOffice.Models.ViewModels.SuperAdmin
{
    public class UsuariosViewModel
    {
        public string NombreUsuario {  get; set; }
        public List<Usuario> Usuarios { get; set; }
        public int? GremioID { get; set; }
        
        public UsuariosViewModel() 
        {
            NombreUsuario = string.Empty;
            Usuarios = new List<Usuario>();
        }
    }
}
