using Jus_365.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using System.Security.Principal;

namespace Jus_365.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<ApplicationUser> _userManager;

        public HomeController(ILogger<HomeController> logger, UserManager<ApplicationUser> userManager)
        {
            _logger = logger;
            _userManager = userManager;

        }

        public async Task<IActionResult> Index()
        {
            if (!User.Identity.IsAuthenticated)
            {
                // Redireciona para a p�gina de login
                return Redirect("/Identity/Account/Login");
            }

            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                // Se o usu�rio n�o for encontrado, redireciona para uma p�gina de erro
                return RedirectToAction("Error", "Home");
            }

            var roles = await _userManager.GetRolesAsync(user);

            // Continue com a l�gica de exibi��o, passando as roles para a view ou manipulando conforme necess�rio
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
