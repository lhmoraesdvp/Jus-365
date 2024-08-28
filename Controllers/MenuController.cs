using Jus_365.Data;
using Jus_365.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class MenuController : Controller
{
    private readonly ApplicationDbContext _context;

    public MenuController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public IActionResult GetRootNodes()
    {
        var rootNodes = _context.JsTreeMenuItem
            .Where(item => item.ParentId == null) // assuming top-level nodes have no parent
            .Select(item => new
            {
                id = item.Id.ToString(), // garantir que o ID é uma string
                text = item.Name,
                children = _context.JsTreeMenuItem.Any(child => child.ParentId == item.Id) // se o item tem filhos
            })
            .ToList();

        return Json(rootNodes);
    }

    [HttpGet]
    public IActionResult GetChildNodes(string id)
    {
        string nodeId = id; // assumir que o id é um número inteiro
        var childNodes = _context.JsTreeMenuItem
            .Where(item => item.ParentId == nodeId) // ajustar conforme o tipo de ParentId
            .Select(item => new
            {
                id = item.Id, // garantir que o ID é uma string
                text = item.Name,
                children = _context.JsTreeMenuItem.Any(child => child.ParentId == item.Id) // se o item tem filhos
            })
            .ToList();

        return Json(childNodes);
    }

    [HttpPost]
    public async Task<IActionResult> CreateNode([FromBody] JsTreeMenuItem newItem)
    {
        _context.JsTreeMenuItem.Add(newItem);
        await _context.SaveChangesAsync();
        newItem.Id = newItem.Id_Item.ToString();
        await _context.SaveChangesAsync();

        return Json(new { id = newItem.Id });
    }

    [HttpPost]
    public async Task<IActionResult> RenameNode([FromBody] JsTreeMenuItem updatedItem)
    {
        var item = await _context.JsTreeMenuItem.Where(c=>c.Id==updatedItem.Id).FirstOrDefaultAsync();
        if (item != null)
        {
            item.Name = updatedItem.Name;
            await _context.SaveChangesAsync();
        }
        else
        {
            JsTreeMenuItem node = new JsTreeMenuItem();
            node.Name = updatedItem.Name;
            node.ParentId = updatedItem.ParentId;
            _context.JsTreeMenuItem.Add(node);
            await _context.SaveChangesAsync();
            node.Id = node.Id_Item.ToString();
            await _context.SaveChangesAsync();
        }
        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> DeleteNode(int id)
    {
        string idItem = id.ToString();
        var item =  await _context.JsTreeMenuItem.Where(c=>c.Id== idItem).FirstOrDefaultAsync();
        {
            _context.JsTreeMenuItem.Remove(item);
            await _context.SaveChangesAsync();
        }
        return Ok("Success");
    }
}
