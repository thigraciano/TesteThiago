using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TesteThiago.Data;
using TesteThiago.Models;

namespace TesteThiago.Controllers
{
    public class ProdutosController : Controller
    {
        private readonly TesteThiagoContext _context;

        public ProdutosController(TesteThiagoContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var produtos = await _context.Produto.ToListAsync();

        
            var tiposUnidade = await _context.TipoUnidade
                .Select(t => new SelectListItem
                {
                    Value = t.Codigo.ToString(),
                    Text = t.Descricao
                })
                .ToListAsync();


            var model = new ProdutoViewModel
            {
                Produtos = produtos,
                TiposUnidade = tiposUnidade,
                NovoProduto = new Produto() 
            };

            return View(model);
        }



        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Produto == null)
            {
                return NotFound();
            }

            var produto = await _context.Produto
                .FirstOrDefaultAsync(m => m.Codigo == id);
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NovoProduto")] ProdutoViewModel model)
        {
                _context.Add(model.NovoProduto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            
        }

        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Produto == null)
            {
                return NotFound();
            }

            var produto = await _context.Produto.FindAsync(id);
            if (produto == null)
            {
                return NotFound();
            }
            return View(produto);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Codigo,Descricao,CodTipoUnidade,QtdEstoque,Observacao")] Produto produto)
        {
            if (id != produto.Codigo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(produto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProdutoExists(produto.Codigo))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                TempData["SuccessMessage"] = "Produto salvo com sucesso!";
                return RedirectToAction(nameof(Index));
            }
            return View(produto);
        }

        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Produto == null)
            {
                return NotFound();
            }

            var produto = await _context.Produto
                .FirstOrDefaultAsync(m => m.Codigo == id);
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Produto == null)
            {
                return Problem("Entity set 'TesteThiagoContext.Produto'  is null.");
            }
            var produto = await _context.Produto.FindAsync(id);
            if (produto != null)
            {
                _context.Produto.Remove(produto);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProdutoExists(string id)
        {
          return (_context.Produto?.Any(e => e.Codigo == id)).GetValueOrDefault();
        }
    }
}
