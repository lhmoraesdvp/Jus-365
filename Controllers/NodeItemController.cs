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
    public class NodeItemController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NodeItemController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: NodeItem
        public async Task<IActionResult> Index()
        {
            return View(await _context.NodeItem.ToListAsync());
        }

        // GET: NodeItem/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nodeItem = await _context.NodeItem
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nodeItem == null)
            {
                return NotFound();
            }

            return View(nodeItem);
        }

        // GET: NodeItem/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NodeItem/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Id_No,caminho,Obs1,Obs2,Obs3")] NodeItem nodeItem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nodeItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nodeItem);
        }

        // GET: NodeItem/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nodeItem = await _context.NodeItem.FindAsync(id);
            if (nodeItem == null)
            {
                return NotFound();
            }
            return View(nodeItem);
        }

        // POST: NodeItem/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Id_No,caminho,Obs1,Obs2,Obs3")] NodeItem nodeItem)
        {
            if (id != nodeItem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nodeItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NodeItemExists(nodeItem.Id))
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
            return View(nodeItem);
        }

        // GET: NodeItem/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nodeItem = await _context.NodeItem
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nodeItem == null)
            {
                return NotFound();
            }

            return View(nodeItem);
        }

        // POST: NodeItem/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nodeItem = await _context.NodeItem.FindAsync(id);
            if (nodeItem != null)
            {
                _context.NodeItem.Remove(nodeItem);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NodeItemExists(int id)
        {
            return _context.NodeItem.Any(e => e.Id == id);
        }
    }
}
