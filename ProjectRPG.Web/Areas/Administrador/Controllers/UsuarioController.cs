using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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
    public class UsuarioController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public UsuarioController(IUnitOfWork unitOfWork, RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var listaVM = new List<UsuarioViewModel>();
            var lista = _unitOfWork.RPGUser.BuscarTodos();
            foreach (var item in lista)
            {
                var rolesDoUsuario = await _userManager.GetRolesAsync(item);
                var vm = new UsuarioViewModel();
                vm.Usuario = item;
                vm.Role = rolesDoUsuario.FirstOrDefault().ToString();
                listaVM.Add(vm);
            }
            return View(listaVM);
        }


        public async Task<IActionResult> AlterarPerfil(string id)
        {
            if (id == null) return NotFound();
            else
            {
                RPGUser? usuario = _unitOfWork.RPGUser.Buscar(u => u.Id == id);
                if (usuario == null)  return NotFound();
                else
                {
                    var rolesDoUsuario = await _userManager.GetRolesAsync(usuario);
                    var roleList = _roleManager.Roles.Select(x => x.Name).Select(i => new SelectListItem
                    {
                        Text = i,
                        Value = i
                    });

                    var vm = new UsuarioViewModel();
                    vm.Usuario = usuario;
                    vm.Role = rolesDoUsuario.FirstOrDefault().ToString();
                    vm.RoleList = roleList;
                    return View(vm);
                }
            }
        }

        [HttpPost]
        public async Task<IActionResult> AlterarPerfil(UsuarioViewModel vm)
        {
            if (vm == null) return NotFound();
            if(vm.Role != "Administrador" &&  vm.Role != "Jogador") ModelState.AddModelError("role", "O usuário só pode ser Administrador ou Jogador");
            if (ModelState.IsValid)
            {
                RPGUser usuario = _unitOfWork.RPGUser.Buscar(u => u.Id == vm.Usuario.Id);
                if (usuario == null) return NotFound();

                var rolesDoUsuario = await _userManager.GetRolesAsync(usuario);
                await _userManager.RemoveFromRolesAsync(usuario, rolesDoUsuario);
                await _userManager.AddToRoleAsync(usuario, vm.Role);
                TempData["success"] = "Perfil alterado com sucesso!";
                return RedirectToAction("Index");
            }
			TempData["error"] = "Perfil não pode ser alterado!";
			return View();
        }


        public async Task<IActionResult> Excluir(string id)
        {
            if (id == null) return NotFound();
            else
            {
                RPGUser? usuario = _unitOfWork.RPGUser.Buscar(u => u.Id == id);
                if (usuario == null) return NotFound();
                else
                {
                    var rolesDoUsuario = await _userManager.GetRolesAsync(usuario);
                    var vm = new UsuarioViewModel();
                    vm.Usuario = usuario;
                    vm.Role = rolesDoUsuario.FirstOrDefault().ToString();
                    return View(vm);
                }
            }
        }

        [HttpPost]
        public async Task<IActionResult> Excluir(UsuarioViewModel vm)
        {
            if (vm == null) return NotFound();
            else
            {
                RPGUser? usuario = _unitOfWork.RPGUser.Buscar(u => u.Id == vm.Usuario.Id);
                if (usuario == null) return NotFound();
                else
                {
                    var rolesDoUsuario = await _userManager.GetRolesAsync(usuario);
                    await _userManager.RemoveFromRolesAsync(usuario, rolesDoUsuario);

                    _unitOfWork.RPGUser.Excluir(usuario);
                    _unitOfWork.Salvar();

                    return RedirectToAction("Index");
                }
            }
        }
    }
}
