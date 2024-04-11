using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace ProjectRPG.Models.ViewModel
{
    public class UsuarioViewModel
    {
        public RPGUser? Usuario { get; set; }
        [Display(Name = "Perfil")]
        public string? Role { get; set; }
        [Display(Name = "Perfil")]
        public IEnumerable<SelectListItem>? RoleList { get; set; }
    }
}
