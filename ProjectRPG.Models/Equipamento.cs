using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace ProjectRPG.Models
{
	public class Equipamento
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public required string Nome { get; set; }

        [MaxLength(5000)]
        [Display(Name = "Descrição")]
        public required string Descricao { get; set; }

        [Required]
        public bool Equipado { get; set; }

        [ValidateNever]
		public ICollection<Personagem>? Personagens { get; set; }
	}
}
