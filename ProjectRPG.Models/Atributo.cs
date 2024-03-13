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
        [MaxLength(50)]
        public required string Nome { get; set; }

        [Required]
        [Range(1, 20)]
        public int Valor { get; set; }

        [Required]
        [Range(-2, 5)]
        public int Modificador { get; set; }
        

        public int PersonagemId { get; set; }
        [ForeignKey("PersonagemId")]
        [ValidateNever]
        public Personagem? Personagem { get; set; }
    }
}
