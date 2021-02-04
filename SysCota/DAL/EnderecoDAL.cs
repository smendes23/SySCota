using Microsoft.EntityFrameworkCore;
using SysCota.Data;
using SysCota.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SysCota.DAL
{
    public class EnderecoDAL
    {

        private DBCOTACAOContext _context;

        public EnderecoDAL(DBCOTACAOContext context)
        {
            _context = context;
        }

    
        public async Task<Endereco> ObterEnderecoPorId(int id)
        {
            var endereco = await _context.Enderecos.Include(e => e.Empresa).SingleOrDefaultAsync(e => e.Id == id);
            return endereco;
        }

        public async Task<Endereco> ObterEnderecoPorIdEmpresa(int id)
        {
            var endereco = await _context.Enderecos.SingleOrDefaultAsync(e => e.EmpresaId == id);
            return endereco;
        }

        public async Task<Endereco> GravarEndereco(Endereco  endereco)
        {
            try { 
                if (endereco.Id == 0)
                {
                    _context.Enderecos.Add(endereco);
                }
                else
                {
                    _context.Update(endereco);
                }
                await _context.SaveChangesAsync();
            
            
            } catch (ArgumentNullException){
                
            }
            return endereco;
        }

        public async Task<Endereco> EliminarEnderecoPorId(int id)
        {
            Endereco endereco = await ObterEnderecoPorId(id);
            _context.Enderecos.Remove(endereco);
            await _context.SaveChangesAsync();
            return endereco;
        }




    }
}