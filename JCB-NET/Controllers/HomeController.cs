using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using JCB_NET.Models;
using JCB_NET.Areas.Usuarios.Models;
using Microsoft.AspNetCore.Identity;
using JCB_NET.Areas.Usuarios.Controllers;

namespace JCB_NET.Controllers
{
    public class HomeController : Controller
    {
        private static LoginInputModel _log;
        private SignInManager<IdentityUser> _signInManager;

        public HomeController(
            SignInManager<IdentityUser> signInManager
            )
        {
            _signInManager = signInManager;
        }

        public async  Task<IActionResult> Index()
        {
            if (_signInManager.IsSignedIn(User))
            {
                return RedirectToAction(nameof(UsuariosController.Usuarios), "Usuarios");
            }
            else
            {
                if (_log != null)
                {
                    return View(_log);
                }
                else
                {
                    return View();
                }
            }
        }
        [HttpPost]
        public async Task<IActionResult> Index(LoginInputModel log)
        {
            _log = log;
            if (ModelState.IsValid) 
            {
                var result = await _signInManager.PasswordSignInAsync(log.Email, log.Password, false, lockoutOnFailure: false);
 
                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(UsuariosController.Usuarios), "Usuarios");
                    // return Redirect("/Usuarios/Usuarios");
                }
                else
                {
                    _log.ErrorMessage = "Correo o contraseña inválidos.";
                    return Redirect("/");
                }
            }
            else
            {
                foreach (var modelState in ModelState.Values)
                {
                    foreach (var error in modelState.Errors)
                    {
                        _log.ErrorMessage = error.ErrorMessage;
                    }
                }
                return Redirect("/");
            }

            return View();
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
