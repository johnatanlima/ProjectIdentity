using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using new1.Models;

namespace new1.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<Usuario> _gerenciaUsuarios;
        private readonly SignInManager<Usuario> _gerenciaLogins;

        public HomeController(UserManager gerenciaUsuarios, SignInManager gerenciaLogins)
        {
            _gerenciaUsuarios = gerenciaUsuarios;
            _gerenciaLogins = gerenciaLogins;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Registro()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registro(UsuarioViewModel registro)
        {
          if(ModelState.IsValid)
          {
            var usuarioTemp = new Usuario
            {
                Nome = registro.Nome,
                Sobrenome = registro.Sobrenome,
                UserName = registro.NomeUsuario,
                Idade = registro.Idade,
                Email = registro.Email             
            };
            
          }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
