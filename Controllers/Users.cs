using Jus_365.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Jus_365.Controllers
{
    public class Users : Controller
    {
        // GET: Users


        private readonly UserService _userService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public Users(UserService userService, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userService = userService;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index(string id, string CaminhoView)
        {
            var usersWithRoles = await _userService.ToList();
            return PartialView (CaminhoView,usersWithRoles);
        }

        // GET: Users/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Users/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Users/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }



        // GET: User/Edit/5
        public async Task<IActionResult> EditRoles(string id, string CaminhoView )
        {


            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            var model = new UserWithRolesViewModel
            {
                UserId = user.Id,
                UserName = user.UserName,
                CurrentRoles = await _userManager.GetRolesAsync(user),
                AvailableRoles = _roleManager.Roles.Select(r => new SelectListItem
                {
                    Value = r.Name,
                    Text = r.Name
                }).ToList(),
                SelectedRoles = await _userManager.GetRolesAsync(user)
            };
           
            return PartialView(CaminhoView, model);

        }

        // POST: User/EditRoles
        [HttpPost]
   
        public async Task<IActionResult> EditRoles(UserWithRolesViewModel model, string caminhoredirect)
        {
            var user =  _userManager.Users.Where(c=>c.Id==model.UserId).FirstOrDefault();
            if (!Request.Headers["X-Requested-With"].Equals("XMLHttpRequest"))
            {
                return BadRequest("Este método só pode ser acessado por AJAX.");
            }
            if (user == null)
            {
                return NotFound();
            }
            
            var currentRoles = await _userManager.GetRolesAsync(user);
            var result = await _userManager.RemoveFromRolesAsync(user, currentRoles);
            if (!result.Succeeded)
            {
                     AddErrors(result);
               return View(caminhoredirect,model);

            }
         
            

         var    result2 = await _userManager.AddToRolesAsync(user, model.SelectedRoles);
         if (!result2.Succeeded)
            {
                AddErrors(result);
                return View(caminhoredirect,model);
            }
            
            var usersWithRoles = await _userService.ToList();
            return PartialView("~/Views/Users/_IndexPartial.cshtml", usersWithRoles);

           
        }
        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }
    }
}
