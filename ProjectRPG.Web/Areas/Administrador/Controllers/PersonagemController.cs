using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectRPG.DataAccess.Repository.IRepository;
using ProjectRPG.Models;
using ProjectRPG.Utilitarios;

namespace ProjectRPG.Web.Areas.Administrador.Controllers
{
    [Area("Administrador")]
    [Authorize(Roles = SD.Role_Administrador)]
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

        public IActionResult AdicionarOuEditar(int? id)
        {
            if (id == null || id == 0)
            {
                //create
                return View();
            }
            else
            {
                //update
                Personagem personagem = _unitOfWork.Personagem.Buscar(u => u.Id == id);
                return View(personagem);
            }
        }

        [HttpPost]
        public IActionResult AdicionarOuEditar(Personagem personagem)
        {
            if (ModelState.IsValid)
            {
                if (personagem.Id == null || personagem.Id == 0)
                {
                    _unitOfWork.Personagem.Adicionar(personagem);
                    _unitOfWork.Salvar();
                    TempData["success"] = "Arma adicionada!";
                }
                else
                {
                    _unitOfWork.Personagem.Alterar(personagem);
                    _unitOfWork.Salvar();
                    TempData["success"] = "Arma editada!";
                }

                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Excluir(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Personagem? personagem = _unitOfWork.Personagem.Buscar(u => u.Id == id);

            if (personagem == null)
            {
                return NotFound();
            }
            return View(personagem);
        }


        [HttpPost, ActionName("Excluir")]
        public IActionResult ExcluirPOST(int? id)
        {
            Personagem? personagem = _unitOfWork.Personagem.Buscar(u => u.Id == id);
            if (personagem == null)
            {
                return NotFound();
            }
            _unitOfWork.Personagem.Excluir(personagem);
            _unitOfWork.Salvar();
            TempData["success"] = "Arma excluída!";
            return RedirectToAction("Index");
        }
    }
}
