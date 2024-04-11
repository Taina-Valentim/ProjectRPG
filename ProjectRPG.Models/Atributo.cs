using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectRPG.Models
{
    public class Atributo
    {
        [Key]
        public int Id { get; set; }


        [Required]
        [Range(1, 10)]
        public int Corpo { get; set; }

        [Required]
        [Range(1, 10)]
        public int Foco { get; set; }

        [Required]
        [Range(1, 10)]
        public int Mente { get; set; }

        [Required]
        [Range(1, 10)]
        public int Reacao { get; set; }


        public int PersonagemId { get; set; }
        [ForeignKey("PersonagemId")]
        [ValidateNever]
        public Personagem? Personagem { get; set; }
    }
}
