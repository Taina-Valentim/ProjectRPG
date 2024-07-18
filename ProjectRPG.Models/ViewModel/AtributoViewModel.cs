using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ProjectRPG.Models.ViewModel
{
    public class AtributoViewModel
    {
        public Atributo? Atributo { get; set; }
        [ValidateNever]
        public Personagem? Personagem { get; set; }
        public IEnumerable<SelectListItem>? PersonagensSelectList { get; set; }
    }
}
