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
        [Display(Name = "E-mail")]
        public override string? Email { get => base.Email; set => base.Email = value; }
        [Display(Name = "Número de Telefone")]
        public override string? PhoneNumber { get => base.PhoneNumber; set => base.PhoneNumber = value; }
    }
}
