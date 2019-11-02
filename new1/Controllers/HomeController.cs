using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using new1.Data;
using new1.Models;

namespace new1.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<Usuario> _gerenciaUsuarios;
        private readonly SignInManager<Usuario> _gerenciaLogins;
        private readonly RoleManager<NivelAcesso> _gerenciaRoles;
        private readonly RegistroDbContext _contexto;

        public HomeController(UserManager<Usuario> gerenciaUsuarios, SignInManager<Usuario> gerenciaLogins, RoleManager<NivelAcesso> roleManager, RegistroDbContext contexto)
        {
            _gerenciaUsuarios = gerenciaUsuarios;
            _gerenciaLogins = gerenciaLogins;
            _gerenciaRoles = roleManager;
            _contexto = contexto;
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
            var usuario = new Usuario
            {
                Nome = registro.Nome,
                Sobrenome = registro.Sobrenome,
                UserName = registro.NomeUsuario,
                Idade = Convert.ToInt32(registro.Idade),
                Email = registro.Email             
            };
            
            var usuarioCriado = await _gerenciaUsuarios.CreateAsync(usuario, registro.Senha);

            if(usuarioCriado.Succeeded)
            {
                await _gerenciaLogins.SignInAsync(usuario, false);

                return RedirectToAction("Index", "Home");
            }

          }

          return View(registro);
        }

        public async Task<IActionResult> Logout()
        {
            await _gerenciaLogins.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult CriarNivelAcesso()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CriarNivelAcesso(NivelAcesso nivelAcesso)
        {
            if(ModelState.IsValid)
            {
                bool roleExiste = await _gerenciaRoles.RoleExistsAsync(nivelAcesso.Name);

                if(!roleExiste)
                {
                    await _gerenciaRoles.CreateAsync(nivelAcesso);
                
                    return RedirectToAction("Index", "Home");
                }
            }

            return View(nivelAcesso);
        }

        public async Task<IActionResult> AssociaUsuario()
        {
            ViewData["UsuarioId"] = new SelectList(await _contexto.Usuarios.ToListAsync(), "Id", "UserName");
            ViewData["NivelAcessoId"] = new SelectList(await _contexto.NivelAcessos.ToListAsync(), "Name", "Name");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AssociaUsuario(UsuarioRoles usuarioRoles)
        {
            if(ModelState.IsValid)
            {
                var usuario = await _gerenciaUsuarios.FindByIdAsync(usuarioRoles.UsuarioId);
                await _gerenciaUsuarios.AddToRoleAsync(usuario, usuarioRoles.NivelAcessoId);

                return RedirectToAction("Index", "Home");
            }

            return View(usuarioRoles);
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
