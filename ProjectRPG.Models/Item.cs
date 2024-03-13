using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectRPG.Models
{
    public class Item
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public required string Nome { get; set; }

        [MaxLength(1000)]
        [Display(Name = "Descrição")]
        public required string Descricao { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int Unidades { get; set; }

        public int PersonagemId { get; set; }
        [ForeignKey("PersonagemId")]
        [ValidateNever]
        public Personagem? Personagem { get; set; }
    }
}
