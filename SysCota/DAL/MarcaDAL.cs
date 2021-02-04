using Microsoft.EntityFrameworkCore;
using SysCota.Data;
using SysCota.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SysCota.DAL
{
    public class MarcaDAL
    {

        private DBCOTACAOContext _context;

        public MarcaDAL(DBCOTACAOContext context)
        {
            _context = context;
        }
        
        public IQueryable<Marca> ObterListaDeMarcas()
        {
             return _context.Marcas;

            
        }

        public async Task<Marca> ObterMarcaPorId(int id)
        {
            var Marca = await _context.Marcas.SingleOrDefaultAsync(e => e.Id == id);
            return Marca;
        }


        public async Task<Marca> GravarMarca(Marca  Marca)
        {
            if (Marca.Id == 0)
            {
                _context.Marcas.Add(Marca);
            }
            else
            {
                _context.Update(Marca);
            }
            await _context.SaveChangesAsync();
            return Marca;
        }

        public async Task<Marca> EliminarMarcaPorId(int id)
        {
            Marca Marca = await ObterMarcaPorId(id);
            _context.Marcas.Remove(Marca);
            await _context.SaveChangesAsync();
            return Marca;
        }




    }
        
    }
