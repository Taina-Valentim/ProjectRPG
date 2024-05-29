using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectRPG.Models
{
    public class Armamento
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public required string Nome { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Descrição")]
        public required string Descricao { get; set; }

        [Range(1, int.MaxValue)]
        public int Dano { get; set; }

        [Range(1, int.MaxValue)]
        public int Alcance { get; set; }

        [Display(Name = "Usa munição")]
        public bool UsaMunicao { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Tipo de munição")]
        public required string TipoMunicao { get; set; }

        [Range(1, int.MaxValue)]
        [Display(Name = "Munição máxima")]
        public int MunicaoMaxima { get; set; }

        [Range(1, int.MaxValue)]
        [Display(Name = "Munição atual")]
        public int MunicaoAtual { get; set; }

        [Required]
        public bool Equipado { get; set; }

        [ValidateNever]
        public ICollection<Personagem>? Personagens { get; set; }
    }
}
