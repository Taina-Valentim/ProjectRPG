using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ProjectRPG.Models
{
    public class RPGUser : IdentityUser
    {
        [Display(Name = "Data de Nascimento")]
        public DateOnly DataNascimento { get; set; }
        [Display(Name = "E-mail")]
        public override string? Email { get => base.Email; set => base.Email = value; }
        [Display(Name = "Número de Telefone")]
        public override string? PhoneNumber { get => base.PhoneNumber; set => base.PhoneNumber = value; }
        [Display(Name = "Nome de Usuário")]
        public override string? UserName { get => base.UserName; set => base.UserName = value; }
    }
}
