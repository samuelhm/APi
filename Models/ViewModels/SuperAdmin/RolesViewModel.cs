using Microsoft.AspNetCore.Identity;

namespace LostArkOffice.Models.ViewModels.SuperAdmin
{
    public class RolesViewModel
    {
        public string NombreRol { get; set; }
        public List<IdentityRole> Roles { get; set; }
        public RolesViewModel()
        {
            Roles = new List<IdentityRole>();
        }
    }
}
