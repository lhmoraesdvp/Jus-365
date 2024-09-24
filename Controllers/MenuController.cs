using Jus_365.Data;
using Jus_365.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

public class MenuController : Controller
{
    private readonly ApplicationDbContext _context;

    public MenuController(ApplicationDbContext context)
    {
        _context = context;
    }

    public  IActionResult Index()
    {
        return View( _context.NodeItem.ToList());
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
                children = _context.JsTreeMenuItem.Any(child => child.ParentId == item.Id), // se o item tem filhos
                obs = item.obs,
                obs2 = item.obs,
                obsInt = item.obsInt,
                icon= item.icon,
                type=item.type,
                tipo_no = item.tipo_no
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
                children = _context.JsTreeMenuItem.Any(child => child.ParentId == item.Id), // se o item tem filhos
                obs=item.obs,
                obs2 = item.obs2,
                obsInt= item.obsInt,
                icon = item.icon,
                type = item.type,
                tipo_no = item.tipo_no

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

    // Método para carregar o conteúdo HTML para uma nova aba
    [HttpGet]
    public IActionResult LoadContent(int id)
    {
        // Em um cenário real, você pode carregar o conteúdo com base no ID do banco de dados
        // Aqui, vamos simplesmente retornar um arquivo HTML estático para o exemplo

        // Você pode ajustar o caminho conforme a localização do arquivo HTML
        //var filePath = "wwwroot/Conteudo/conteudo1.html";
        //var content = System.IO.File.ReadAllText(filePath);

        //return Content(content, "text/html");

        var model =   _context.Empresa.ToList();// Obtenha seu modelo com base no ID
        NodeItem no = _context.NodeItem.Where(c=>c.Id_No==id).FirstOrDefault();
        string classe = no.Obs1;
        string caminho=no.caminho;

   // Obtenha o tipo do modelo usando reflection
    Type tipo = Type.GetType(classe);

        if (tipo != null)
        {
            // Obtenha o DbSet correspondente ao tipo usando reflection
            var dbSet = _context.GetType().GetProperty(tipo.Name)?.GetValue(_context);

            // Verifique se o DbSet foi encontrado
            if (dbSet != null)
            {
                // Chame o método ToList dinamicamente
                var metodoToList = typeof(Enumerable).GetMethod("ToList").MakeGenericMethod(tipo);
                var lista = metodoToList.Invoke(null, new[] { dbSet });
                try
                {
                    // Caminho relativo ou nome da partial view
                    return PartialView(caminho, lista);
                }
                catch (Exception ex)
                {
                    // Log ou manipule a exceção conforme necessário
                    return StatusCode(500, "Erro ao carregar a partial view: " + ex.Message);
                }

            }
            return PartialView(caminho, model);

        }
        return PartialView(caminho, model);



    }
}
