using Microsoft.EntityFrameworkCore;
using SysCota.Data;
using SysCota.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SysCota.DAL
{
    public class ItemDAL
    {

        private DBCOTACAOContext _context;

        public ItemDAL(DBCOTACAOContext context)
        {
            _context = context;
        }

        public IQueryable<Item> ObterListaDeItems()
        {
            return _context.Itens.Include(p => p.Produto).Include(c=>c.Cotar);
        }

        public async Task<Item> ObterItemPorId(int id)
        {
            var item = await _context.Itens.Include(p => p.Produto).Include(c => c.Cotar).SingleOrDefaultAsync(e => e.Id == id);
            return item;
        }

        public async Task<Item> GravarItem(Item  item)
        {
            if (item.Id == 0)
            {
                _context.Itens.Add(item);
            }
            else
            {
                _context.Update(item);
            }
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<Item> EliminarItemPorId(int id)
        {
            Item item = await ObterItemPorId(id);
            _context.Itens.Remove(item);
            await _context.SaveChangesAsync();
            return item;
        }




    }
}