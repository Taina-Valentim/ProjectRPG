using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectRPG.Models
{
    public class Condicao
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public bool Desnutrido { get; set; }

        [Required]
        public bool Aterrorizado { get; set; }

        [Required]
        public bool Paralisado { get; set; }

        [Required]
        public bool Envenenado { get; set; }

        [Required]
        public bool Sangrando { get; set; }

        [Required]
        public bool Queimado { get; set; }

        public int PersonagemId { get; set; }
        [ForeignKey("PersonagemId")]
        [ValidateNever]
        public Personagem? Personagem { get; set; }
    }
}
