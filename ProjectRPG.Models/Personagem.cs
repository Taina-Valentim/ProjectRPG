using System.ComponentModel.DataAnnotations;

namespace ProjectRPG.Models
{
    public class Personagem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(150)]
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
        public int PvTotal { get; set; }

        [Required]
        [Display(Name = "PV atual")]
        public int PvAtual { get; set; }

        [Required]
        public int Deslocamento { get; set; }

        [Required]
        [Display(Name = "Infecção")]
        public int Infeccao { get; set; }

        [Required]
        public int Defesa { get; set; }

        [Required]
        [Display(Name = "Regeneração diária")]
        public int RegeneracaoDiaria { get; set; }

        [Display(Name = "Bem-estar")]
        public int BemEstar { get; set; }
    }
}
