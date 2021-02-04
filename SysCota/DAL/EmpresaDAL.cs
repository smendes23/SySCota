using Microsoft.EntityFrameworkCore;
using SysCota.Data;
using SysCota.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SysCota.DAL
{
    public class EmpresaDAL
    {

        private DBCOTACAOContext _context;

        public EmpresaDAL(DBCOTACAOContext context)
        {
            _context = context;
        }
        
        public IQueryable<Empresa> ObterListaDeEmpresas()
        {
             return _context.Empresas.Include(i => i.Enderecos);

            
        }

        public async Task<Empresa> ObterEmpresaPorId(int id)
        {
            var empresa = await _context.Empresas.Include(e => e.Enderecos).SingleOrDefaultAsync(e => e.Id == id);
            //_context.Enderecos.Where(e => e.EmpresaId == empresa.Id).Load();
            return empresa;
        }


        public async Task<Empresa> GravarEmpresa(Empresa  empresa)
        {
            if (empresa.Id == 0)
            {
                _context.Empresas.Add(empresa);
            }
            else
            {
                _context.Update(empresa);
            }
            await _context.SaveChangesAsync();
            return empresa;
        }

        public async Task<Empresa> EliminarEmpresaPorId(int id)
        {
            Empresa empresa = await ObterEmpresaPorId(id);
            _context.Empresas.Remove(empresa);
            await _context.SaveChangesAsync();
            return empresa;
        }




    }
        
    }
