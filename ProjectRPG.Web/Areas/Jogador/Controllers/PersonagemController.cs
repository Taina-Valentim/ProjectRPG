using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectRPG.DataAccess.Repository.IRepository;
using ProjectRPG.Utilitarios;

namespace ProjectRPG.Web.Areas.Jogador.Controllers
{
    [Area("Jogador")]
    //[Authorize(Roles = SD.Role_Jogador)]
    public class PersonagemController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public PersonagemController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var personagem = _unitOfWork.Personagem.Buscar(x => x.Id == 1);
            return View(personagem);
        }
    }
}
