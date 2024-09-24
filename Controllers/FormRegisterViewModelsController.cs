using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Jus_365.Data;
using Jus_365.Models;
using static System.Net.Mime.MediaTypeNames;

namespace Jus_365.Controllers
{
    public class FormRegisterViewModelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FormRegisterViewModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: FormRegisterViewModels
        public async Task<IActionResult> Index()
        {
            var r = _context.FormRegisterViewModel.ToList();
            return View(r);
        }

        // GET: FormRegisterViewModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formRegisterViewModel = await _context.FormRegisterViewModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (formRegisterViewModel == null)
            {
                return NotFound();
            }

            return View(formRegisterViewModel);
        }

            // GET: FormRegisterViewModels/Create
            public IActionResult Create(string id, string CaminhoView)
        {
            var form = _context.FormularioLogin.Where(c => c.key == id).FirstOrDefault();
          
            FormRegisterViewModel model = new FormRegisterViewModel();
            model.slot1 = form.slot1 !="Vazio" ? @"\Conteudo\"+form.slot1 +@".html":"0" ;
            model.slot2 = form.slot2 != "Vazio" ? @"\Conteudo\" + form.slot2 + @".html" : "0";
            model.slot3 = form.slot3 != "Vazio" ? @"\Conteudo\" + form.slot3 + @".html" : "0";
            model.slot4 = form.slot3 != "Vazio" ? @"\Conteudo\" + form.slot4 + @".html" : "0";
            model.slot5 = form.slot5 != "Vazio" ? @"\Conteudo\" + form.slot5 + @".html" : "0";
            model.slot6 = form.slot6 != "Vazio" ? @"\Conteudo\" + form.slot6 + @".html" : "0";
            model.slot7 = form.slot7 != "Vazio" ? @"\Conteudo\" + form.slot7 + @".html" : "0";
            model.slot8 = form.slot8 != "Vazio" ? @"\Conteudo\" + form.slot8 + @".html" : "0";
            model.slot9 = form.slot9 != "Vazio" ? @"\Conteudo\" + form.slot9 + @".html" : "0";








            //    model.slot3 = @"\Conteudo\EnderecoPessoal.html";
            //    model.slot4 = @"\Conteudo\DocumentosPessoais.html";
            //  model.slot5 = @"\Conteudo\Arquivos.html";
            //   model.slot6 = @"\Conteudo\Empresa.html";
            //   model.slot7 = @"\Conteudo\Plano.html";
            //   model.slot8 = @"\Conteudo\EnderecoEmpresarial.html";
            //   model.slot9 = @"\Conteudo\Login.html";






            return PartialView (CaminhoView, model);
        }

        // POST: FormRegisterViewModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
     
        public async Task<IActionResult> Create([FromBody] FormRegisterViewModel formRegisterViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.FormRegisterViewModel.Add(formRegisterViewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(formRegisterViewModel);
        }

        // GET: FormRegisterViewModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formRegisterViewModel = await _context.FormRegisterViewModel.FindAsync(id);
            if (formRegisterViewModel == null)
            {
                return NotFound();
            }
            return View(formRegisterViewModel);
        }

        // POST: FormRegisterViewModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NomeCompleto,Sexo,DataNascimento,Email,TelefoneCelular,TelefoneResidencial,OutroTelefone,CEP,Estado,Cidade,Logradouro,Numero,Complemento,CPF,RG,DataExpedicaoRG,OrgaoExpedicaoRG,CNH,DataValidadeCNH,EstadoExpedidorCNH,Planos,Arquivo1,Arquivo2,Arquivo3,Arquivo4,Arquivo5,CPFCNPJ,RazaoSocial,InscricaoEstadual,TelefoneEmpresa,EmailEmpresa,InscricaoMunicipal,Certificado,CEPEmpresa,EstadoEmpresa,CidadeEmpresa,LogradouroEmpresa,NumeroEmpresa,ComplementoEmpresa,LoginEmail,Senha")] FormRegisterViewModel formRegisterViewModel)
        {
            if (id != formRegisterViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(formRegisterViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FormRegisterViewModelExists(formRegisterViewModel.Id))
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
            return View(formRegisterViewModel);
        }

        // GET: FormRegisterViewModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formRegisterViewModel = await _context.FormRegisterViewModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (formRegisterViewModel == null)
            {
                return NotFound();
            }

            return View(formRegisterViewModel);
        }

        // POST: FormRegisterViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var formRegisterViewModel = await _context.FormRegisterViewModel.FindAsync(id);
            if (formRegisterViewModel != null)
            {
                _context.FormRegisterViewModel.Remove(formRegisterViewModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FormRegisterViewModelExists(int id)
        {
            return _context.FormRegisterViewModel.Any(e => e.Id == id);
        }


        public async Task<IActionResult> ConcatenateHtml()
        {

            var cabPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "html", "cabeçalho.html");
            var contPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "html", "conteúdo.html");
            var fotPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "html", "rodape.html");

            var cabContent = System.IO.File.ReadAllText(@"C:\Users\morae\source\repos\Jus 365\wwwroot\Conteudo\cab.html");
            var contContent = System.IO.File.ReadAllText(@"C:\Users\morae\source\repos\Jus 365\wwwroot\Conteudo\UserDadosPessoais.html");
            var fotContent = System.IO.File.ReadAllText(@"C:\Users\morae\source\repos\Jus 365\wwwroot\Conteudo\fot.html");

            var combinedContent = $"{cabContent}{contContent}{fotContent}";

            // Se você quiser renderizar o conteúdo no navegador:
            return Content(combinedContent, "text/html");

        }
    }
}
