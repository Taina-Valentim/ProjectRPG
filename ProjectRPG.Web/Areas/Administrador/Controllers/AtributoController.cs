using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjectRPG.DataAccess.Repository.IRepository;
using ProjectRPG.Models;
using ProjectRPG.Models.ViewModel;
using ProjectRPG.Utilitarios;

namespace ProjectRPG.Web.Areas.Administrador.Controllers
{
    [Area("Administrador")]
    [Authorize(Roles = SD.Role_Administrador)]
    public class AtributoController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public AtributoController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<AtributoViewModel> lista = new List<AtributoViewModel>();

            foreach (Atributo item in _unitOfWork.Atributo.BuscarTodos().ToList()){
                lista.Add(new AtributoViewModel()
                {
                    Atributo = item,
                    Personagem = _unitOfWork.Personagem.Buscar(x => x.Id == item.PersonagemId)
                }); 
            }
            return View(lista);
        }

        public IActionResult AdicionarOuEditar(int? id)
        {
            var personagens = _unitOfWork.Personagem.BuscarTodos().ToList();
            var viewModel = new AtributoViewModel();
            viewModel.PersonagensSelectList = personagens
                .Select(p => new SelectListItem
                {
                    Value = p.Id.ToString(),
                    Text = p.Nome
                });
            if (id == null || id == 0)
            {
                return View(viewModel);
            }
            else
            {
                viewModel.Atributo = _unitOfWork.Atributo.Buscar(u => u.Id == id);
                viewModel.Personagem = _unitOfWork.Personagem.Buscar(x => x.Id == viewModel.Atributo.PersonagemId);
                return View(viewModel);
            }
        }

        [HttpPost]
        public IActionResult AdicionarOuEditar(AtributoViewModel viewModel)
        {
            viewModel.PersonagensSelectList = _unitOfWork.Personagem.BuscarTodos().ToList()
                .Select(p => new SelectListItem
                {
                    Value = p.Id.ToString(),
                    Text = p.Nome
                });
            var personagem = _unitOfWork.Personagem.Buscar(x => x.Id == viewModel.Personagem.Id);
            if (ModelState.IsValid)
            {
                var atributo = new Atributo()
                {
                    Corpo = viewModel.Atributo.Corpo,
                    Foco = viewModel.Atributo.Foco,
                    Mente = viewModel.Atributo.Mente,
                    Reacao = viewModel.Atributo.Reacao,
                    PersonagemId = personagem.Id,
                    Personagem = viewModel.Personagem
                };

                if (viewModel.Atributo.Id == null || viewModel.Atributo.Id == 0)
                {
                    _unitOfWork.Atributo.Adicionar(atributo);
                    _unitOfWork.Salvar();
                    TempData["success"] = "Atributo adicionado!";
                }
                else
                {
                    _unitOfWork.Atributo.Alterar(atributo);
                    _unitOfWork.Salvar();
                    TempData["success"] = "Atributo editado!";
                }

                return RedirectToAction("Index");
            }
            return View(viewModel);
        }

        public IActionResult Excluir(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Atributo? atributo = _unitOfWork.Atributo.Buscar(u => u.Id == id);

            if (atributo == null)
            {
                return NotFound();
            }
            return View(atributo);
        }


        [HttpPost, ActionName("Excluir")]
        public IActionResult ExcluirPOST(int? id)
        {
            Atributo? atributo = _unitOfWork.Atributo.Buscar(u => u.Id == id);
            if (atributo == null)
            {
                return NotFound();
            }
            _unitOfWork.Atributo.Excluir(atributo);
            _unitOfWork.Salvar();
            TempData["success"] = "Atributo excluído!";
            return RedirectToAction("Index");
        }
    }
}
