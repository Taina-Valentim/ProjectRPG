using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ProjectRPG.Models
{
    public class RPGUser : IdentityUser
    {
        [Display(Name = "Nome de usuário")]
        public string? NomeUsuario { get; set; }
        [Display(Name = "Data de Nascimento")]
        public DateOnly DataNascimento { get; set; }
    }
}
