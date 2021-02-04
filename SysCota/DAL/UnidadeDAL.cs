using Microsoft.EntityFrameworkCore;
using SysCota.Data;
using SysCota.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SysCota.DAL
{
    public class UnidadeDAL
    {

        private DBCOTACAOContext _context;

        public UnidadeDAL(DBCOTACAOContext context)
        {
            _context = context;
        }
        
        public IQueryable<Unidade> ObterListaDeUnidades()
        {
            return _context.Unidades;

            
        }

        public async Task<Unidade> ObterUnidadePorId(int id)
        {
            var Unidade = await _context.Unidades.SingleOrDefaultAsync(e => e.Id == id);
            return Unidade;
        }


        public async Task<Unidade> GravarUnidade(Unidade  Unidade)
        {
            if (Unidade.Id == 0)
            {
                _context.Unidades.Add(Unidade);
            }
            else
            {
                _context.Update(Unidade);
            }
            await _context.SaveChangesAsync();
            return Unidade;
        }

        public async Task<Unidade> EliminarUnidadePorId(int id)
        {
            Unidade Unidade = await ObterUnidadePorId(id);
            _context.Unidades.Remove(Unidade);
            await _context.SaveChangesAsync();
            return Unidade;
        }




    }
        
    }
