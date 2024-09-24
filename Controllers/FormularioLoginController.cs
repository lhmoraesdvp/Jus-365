using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Jus_365.Data;
using Jus_365.Models;

namespace Jus_365.Controllers
{
    public class FormularioLoginController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FormularioLoginController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: FormularioLogin
        public async Task<IActionResult> Index(string id, string CaminhoView)
        {
           return PartialView (CaminhoView,await _context.FormularioLogin.ToListAsync());
        }

        // GET: FormularioLogin/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formularioLogin = await _context.FormularioLogin
                .FirstOrDefaultAsync(m => m.Id == id);
            if (formularioLogin == null)
            {
                return NotFound();
            }

            return View(formularioLogin);
        }

        // GET: FormularioLogin/Create
        public IActionResult Create(string id, string CaminhoView)
        {
            return PartialView(CaminhoView);
        }

        // POST: FormularioLogin/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
     
        public async Task<IActionResult> Create([FromBody] FormularioLogin formularioLogin)
        {
            if (ModelState.IsValid)
            {
                _context.Add(formularioLogin);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(formularioLogin);
        }

        // GET: FormularioLogin/Edit/5
        public async Task<IActionResult> Edit(string id, string CaminhoView)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formularioLogin = await _context.FormularioLogin.Where(c=>c.key==id).FirstOrDefaultAsync();
            if (formularioLogin == null)
            {
                return NotFound();
            }
            return PartialView(CaminhoView, formularioLogin);

        }

        // POST: FormularioLogin/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([FromBody] FormularioLogin formularioLogin)
        {
            if (_context.FormularioLogin.Where(C=>C.Id== formularioLogin.Id).FirstOrDefault()!=null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(formularioLogin);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FormularioLoginExists(formularioLogin.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(formularioLogin);
        }

        // GET: FormularioLogin/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formularioLogin = await _context.FormularioLogin
                .FirstOrDefaultAsync(m => m.Id == id);
            if (formularioLogin == null)
            {
                return NotFound();
            }

            return View(formularioLogin);
        }

        // POST: FormularioLogin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var formularioLogin = await _context.FormularioLogin.FindAsync(id);
            if (formularioLogin != null)
            {
                _context.FormularioLogin.Remove(formularioLogin);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FormularioLoginExists(int id)
        {
            return _context.FormularioLogin.Any(e => e.Id == id);
        }
    }
}
