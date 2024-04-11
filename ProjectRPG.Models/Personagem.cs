using System.ComponentModel.DataAnnotations;

namespace ProjectRPG.Models
{
    public class Personagem
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [MaxLength(150, ErrorMessage = "O nome deve ter entre 1 e 150 caracteres")]
        public required string Nome { get; set; }

        [Required]
        [MaxLength(30)]
        [Display(Name = "Espécie")]
        public required string Especie { get; set; }

        [Required]
        [MaxLength(1000)]
        [Display(Name = "Aparência")]
        public required string Aparencia { get; set; }

        [Required]
        [Display(Name = "PV total")]
        [Range (0, int.MaxValue)]
        public int PvTotal { get; set; }

        [Required]
        [Range (0, int.MaxValue)]
        [Display(Name = "PV atual")]
        public int PvAtual { get; set; }

        [Required]
        [Range (0, int.MaxValue)]
        public int Deslocamento { get; set; }

        [Required]
        [Range (0, int.MaxValue)]
        [Display(Name = "Evasão")]
        public int Evasao { get; set; }
    }
}
