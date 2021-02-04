using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SysCota.Data;
using SysCota.Models;

namespace SysCota.Controllers
{
    public class CotacaoController : Controller
    {
        private readonly DBCOTACAOContext _context;

        public CotacaoController(DBCOTACAOContext context)
        {
            _context = context;
        }

        // GET: Cotacao
        public async Task<IActionResult> Index()
        {
            return View(await _context.Cotacoes.ToListAsync());
        }

        // GET: Cotacao/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cotacao = await _context.Cotacoes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cotacao == null)
            {
                return NotFound();
            }

            return View(cotacao);
        }

        // GET: Cotacao/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cotacao/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NumeroDaCotacao,DataCotacao,DataEntregaCotacao")] Cotacao cotacao)
        {
            if (ModelState.IsValid)
            {

                _context.Add(cotacao);

                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(cotacao);
        }

        // GET: Cotacao/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cotacao = await _context.Cotacoes.FindAsync(id);
            if (cotacao == null)
            {
                return NotFound();
            }
            return View(cotacao);
        }

        // POST: Cotacao/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NumeroDaCotacao,DataCotacao,DataEntregaCotacao")] Cotacao cotacao)
        {
            if (id != cotacao.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cotacao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CotacaoExists(cotacao.Id))
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
            return View(cotacao);
        }

        // GET: Cotacao/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cotacao = await _context.Cotacoes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cotacao == null)
            {
                return NotFound();
            }

            return View(cotacao);
        }

        // POST: Cotacao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cotacao = await _context.Cotacoes.FindAsync(id);
            _context.Cotacoes.Remove(cotacao);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CotacaoExists(int id)
        {
            return _context.Cotacoes.Any(e => e.Id == id);
        }
    }
}
