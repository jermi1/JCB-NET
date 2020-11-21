using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using JCB_NET.Controllers;
using JCB_NET.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JCB_NET.Areas.Usuarios.Controllers
{
    [Area("Usuarios")]
    [Authorize]
    public class UsuariosController : Controller
    {
        private readonly ApplicationDbContext _db;
        private SignInManager<IdentityUser> _signInManager;

        public UsuariosController(ApplicationDbContext db,
            SignInManager<IdentityUser> signInManager
            )
        {
            _db = db;
            _signInManager = signInManager;
        }
        public async Task<IActionResult> Usuarios()
        {
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            if (claim != null)
            {
                return View(await _db.ApplicationUser.Where(u => u.Id != claim.Value).ToListAsync());
            }
            else 
            {
                return View(await _db.ApplicationUser.ToListAsync());
            }
        }

        public async Task<IActionResult> CerrarSesion()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }
    }
}