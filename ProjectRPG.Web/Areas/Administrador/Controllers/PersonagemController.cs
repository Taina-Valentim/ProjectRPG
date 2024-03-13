using Microsoft.AspNetCore.Mvc;
using ProjectRPG.DataAccess.Repository.IRepository;
using ProjectRPG.Models;

namespace ProjectRPG.Web.Areas.Administrador.Controllers
{
    [Area("Administrador")]
    public class PersonagemController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public PersonagemController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var lista = _unitOfWork.Personagem.BuscarTodos().ToList();
            return View(lista);
        }

        public IActionResult Teste()
        {
            return View();
        }

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Criar(Personagem personagem)
        {

            if(ModelState.IsValid)
            {
                _unitOfWork.Personagem.Adicionar(personagem);
                _unitOfWork.Salvar();
                TempData["success"] = "Seu personagem foi criado!";
                return RedirectToAction("Index");

            }
            TempData["error"] = "Seu personagem não foi criado!";
            return View();
        }
    }
}
