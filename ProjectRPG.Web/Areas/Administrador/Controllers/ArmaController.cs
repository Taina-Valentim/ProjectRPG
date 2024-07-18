using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectRPG.DataAccess.Repository.IRepository;
using ProjectRPG.Models;
using ProjectRPG.Utilitarios;

namespace ProjectRPG.Web.Areas.Administrador.Controllers
{
    [Area("Administrador")]
    [Authorize(Roles = SD.Role_Administrador)]
    public class ArmaController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ArmaController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            var lista = _unitOfWork.Arma.BuscarTodos().ToList();
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
                Arma arma = _unitOfWork.Arma.Buscar(u => u.Id == id);
                return View(arma);
            }
        }

        [HttpPost]
        public IActionResult AdicionarOuEditar(Arma arma)
        {
            if (ModelState.IsValid)
            {
                if (arma.Id == null || arma.Id == 0)
                {
                    arma.Equipado = false;
                    _unitOfWork.Arma.Adicionar(arma);
                    _unitOfWork.Salvar();
                    TempData["success"] = "Arma adicionada!";
                }
                else
                {
                    _unitOfWork.Arma.Alterar(arma);
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

            Arma? arma = _unitOfWork.Arma.Buscar(u => u.Id == id);

            if (arma == null)
            {
                return NotFound();
            }
            return View(arma);
        }


        [HttpPost, ActionName("Excluir")]
        public IActionResult ExcluirPOST(int? id)
        {
            Arma? arma = _unitOfWork.Arma.Buscar(u => u.Id == id);
            if (arma == null)
            {
                return NotFound();
            }
            _unitOfWork.Arma.Excluir(arma);
            _unitOfWork.Salvar();
            TempData["success"] = "Arma excluída!";
            return RedirectToAction("Index");
        }
    }
}
