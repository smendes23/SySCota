using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SysCota.DAL;
using SysCota.Data;
using SysCota.Models;
using SysCota.ViewModel;

namespace SysCota.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly DBCOTACAOContext _context;
        private readonly IMapper _mapper;
        private ProdutoDAL _produtodal;
        private UnidadeDAL  _unidadedal;
        private MarcaDAL  _marcadal;

        public ProdutoController(DBCOTACAOContext context, IMapper mapper, ProdutoDAL produtodal, UnidadeDAL unidadedal, MarcaDAL marcadal)
        {
            _context = context;
            _mapper = mapper;
            _produtodal = produtodal;
            _marcadal = marcadal;
            _unidadedal = unidadedal;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _produtodal.ObterListaDeProdutos().ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _context.Produtos
                .Include(p => p.Marca)
                .Include(p => p.Unidade)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        public IActionResult Create()
        {
            ViewData["MarcaData"] = new SelectList(_context.Marcas, "Id", "Descricao");
            ViewData["UnidadeData"] = new SelectList(_context.Unidades, "Id", "Descricao");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Descricao,Preco,MarcaNavigator,UnidadeNavigator")] ProdutoViewModel produtoviewmodel)
        {
            var produto = _mapper.Map<Produto>(produtoviewmodel);
            try {
                if (ModelState.IsValid)
                {
                    var _marca = produtoviewmodel.MarcaNavigator;
                    var _unidade = produtoviewmodel.UnidadeNavigator;

                    if (_marca.Id == 0)
                    {
                        await _marcadal.GravarMarca(_marca);
                    }

                    if (_unidade.Id == 0)
                    {
                        await _unidadedal.GravarUnidade(_unidade);
                    }

                    produto.Marca = _marca;
                    produto.Unidade = _unidade;

                    
                    await _produtodal.GravarProduto(produto);

                    return RedirectToAction(nameof(Index));
                }
                ViewData["MarcaData"] = new SelectList(_context.Marcas, "Id", "Descricao");
                ViewData["UnidadeData"] = new SelectList(_context.Unidades, "Id", "Descricao");


            } catch (DbUpdateException) { 
            }
            
            return View(produto);
        }

        // GET: Produto/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _context.Produtos.FindAsync(id);
            if (produto == null)
            {
                return NotFound();
            }
            ViewData["MarcaId"] = new SelectList(_context.Marcas, "Id", "Descricao", produto.MarcaId);
            ViewData["UnidadeId"] = new SelectList(_context.Unidades, "Id", "Descricao", produto.UnidadeId);
            return View(produto);
        }

        // POST: Produto/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descricao,Preco,MarcaId,UnidadeId")] Produto produto)
        {
            if (id != produto.Id)
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
                    if (!ProdutoExists(produto.Id))
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
            ViewData["MarcaData"] = new SelectList(_context.Marcas, "Id", "Descricao");
            ViewData["UnidadeData"] = new SelectList(_context.Unidades, "Id", "Descricao");
            return View(produto);
        }

     
        // POST: Produto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
           await  _produtodal.EliminarProdutoPorId(id);
            return RedirectToAction(nameof(Index));
        }

        private bool ProdutoExists(int id)
        {
            return _context.Produtos.Any(e => e.Id == id);
        }
    }
}
