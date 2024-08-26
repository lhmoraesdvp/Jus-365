using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using System.Collections.Generic;
using Jus_365.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore; // Substitua com o namespace correto
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jus_365.Data;
using Jus_365.Models;
using static System.Formats.Asn1.AsnWriter;
using Microsoft.Extensions.DependencyInjection;
using System.Data;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static System.Runtime.InteropServices.JavaScript.JSType;

[Authorize(Roles = "Admin")]
public class RoleController : Controller
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly ApplicationDbContext _context;
    public RoleController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, ApplicationDbContext context)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _context = context;
    }

    // Lista todas as roles
    public async Task<IActionResult> Index()
    {
        var roles = _roleManager.Roles;
        var roleViewModels = new List<RoleViewModel>();

        foreach (var role in roles)
        {
            roleViewModels.Add(new RoleViewModel
            {

                Name = role.Name,
                Id = role.Id
            });
        }

        return View(roleViewModels);
    }

    // Cria uma nova role
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(RoleViewModel model)
    {
        model.Id = "";
        if  (!string.IsNullOrEmpty( model.Name))
        {
            var role = new IdentityRole { Name = model.Name };
            var result = await _roleManager.CreateAsync(role);

            if (result.Succeeded)
            {
                return RedirectToAction(nameof(Index));
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }

        return View(model);
    }

    // GET: Role/Edit/5
    public async Task<IActionResult> Edit(string id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var role = await _roleManager.FindByIdAsync(id);
        if (role == null)
        {
            return NotFound();
        }

        var model = new RoleViewModel
        {
            Id = role.Id,
            Name = role.Name
        };

        return View(model);
    }

    // POST: Role/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(RoleViewModel model)
    {
        if (ModelState.IsValid)
        {
            var role = await _roleManager.FindByIdAsync(model.Id);
            if (role == null)
            {
                return NotFound();
            }

            role.Name = model.Name;
            var result = await _roleManager.UpdateAsync(role);

            if (result.Succeeded)
            {
                return RedirectToAction(nameof(Index));
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }

        return View(model);
    }
    // Exclui uma role existente
    public async Task<IActionResult> Delete(string id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var role = await _roleManager.FindByIdAsync(id);


        if (role == null)
        {
            return NotFound();
        }

        var model = new RoleViewModel
        {
           
            Name = role.Name
        };

        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(RoleViewModel model)
    {
        var role = await _roleManager.FindByIdAsync(model.Id);
        if (role == null)
        {
            return NotFound();
        }
        var planos = _context.Planos.Where(c => c.Description == role.Name).ToList();
        if (planos == null && !planos.Any())
        {

            var result = await _roleManager.DeleteAsync(role);

            if (result.Succeeded)
            {
                return RedirectToAction(nameof(Index));
            }
            
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
            return View(model);
        }
        else
        {
            ModelState.AddModelError(string.Empty,"Impossivel excluir, Role"+role.Name+" está atrelada ao plano "+role.Name);
            return View(model);
        }
      
    }

       
    }




