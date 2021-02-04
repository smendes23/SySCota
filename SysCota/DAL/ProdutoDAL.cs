using Microsoft.EntityFrameworkCore;
using SysCota.Data;
using SysCota.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SysCota.DAL
{
    public class ProdutoDAL
    {

        private DBCOTACAOContext _context;

        public ProdutoDAL(DBCOTACAOContext context)
        {
            _context = context;
        }

        public IQueryable<Produto> ObterListaDeProdutos()
        {
            return _context.Produtos.Include(m=> m.Marca).Include(u=> u.Unidade);
        }

        public async Task<Produto> ObterProdutoPorId(int id)
        {
            var produto = await _context.Produtos.Include(m => m.Marca).Include(u => u.Unidade).SingleOrDefaultAsync(e => e.Id == id);
            return produto;
        }

        public async Task<Produto> GravarProduto(Produto  produto)
        {
            if (produto.Id == 0)
            {
                _context.Produtos.Add(produto);
            }
            else
            {
                _context.Update(produto);
            }
            await _context.SaveChangesAsync();
            return produto;
        }

        public async Task<Produto> EliminarProdutoPorId(int id)
        {
            Produto produto = await ObterProdutoPorId(id);
            _context.Produtos.Remove(produto);
            await _context.SaveChangesAsync();
            return produto;
        }




    }
}