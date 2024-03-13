using Microsoft.AspNetCore.Mvc;
using ProjectRPG.DataAccess.Repository.IRepository;

namespace ProjectRPG.Web.Areas.Jogador.Controllers
{
    [Area("Jogador")]
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
