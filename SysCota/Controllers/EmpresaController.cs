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
    public class EmpresaController : Controller
    {
        private readonly DBCOTACAOContext _context;
        private EmpresaDAL dal;
        private EnderecoDAL enderecodal;
        private readonly IMapper _mapper;

        public EmpresaController(DBCOTACAOContext context, IMapper mapper, EmpresaDAL empresaDAL, EnderecoDAL enderecoDAL)
        {
            _context = context;
            dal = empresaDAL;
            _mapper = mapper;
            enderecodal = enderecoDAL;
        }

        public async Task<IActionResult> Index()
        {
            return View(await dal.ObterListaDeEmpresas().ToListAsync());
        }

        // GET: Empresa/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var empresa = await dal.ObterEmpresaPorId(id);

            if (empresa == null)
            {
                return NotFound();
            }

            return View(empresa);
        }

        // GET: Empresa/Create
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CNPJ,RazaoSocial,IsFornecedor,EnderecoNavigation")] EmpresaViewModel empresaview)
        {
            var empresa = _mapper.Map<Empresa>(empresaview);




            try
            {

                if (ModelState.IsValid)
                {

                    await dal.GravarEmpresa(empresa);

                    var endereco = new Endereco
                    {
                        Cep = empresaview.EnderecoNavigation.Cep,
                        Bairro = empresaview.EnderecoNavigation.Bairro,
                        Logradouro = empresaview.EnderecoNavigation.Logradouro,
                        Complemento = empresaview.EnderecoNavigation.Complemento,
                        Cidade = empresaview.EnderecoNavigation.Cidade,
                        Uf = empresaview.EnderecoNavigation.Uf,
                        Observacao = empresaview.EnderecoNavigation.Observacao,
                        Empresa = empresa

                    };

                    await enderecodal.GravarEndereco(endereco);

                    TempData["Mensagem"] = "Dados salvo com sucesso!";
                    return RedirectToAction(nameof(Index));
                }


            }
            catch (DbUpdateException)
            {

                TempData["Mensagem"] = "Não foi possível inserir os dados.";
            }
            return View(empresa);

        }


        public async Task<IActionResult> Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var empresa = await _context.Empresas.Include(e => e.Enderecos).FirstOrDefaultAsync(em => em.Id ==id);

            var emp = _mapper.Map<EmpresaViewModel>(empresa);
            emp.EnderecoNavigation = await enderecodal.ObterEnderecoPorIdEmpresa(id);
            if (empresa == null)
            {
                return NotFound();
            }
            return View(emp);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CNPJ,RazaoSocial,IsFornecedor,EnderecoNavigation")] EmpresaViewModel empresa)
        {
            if (id != empresa.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var emp = _mapper.Map<Empresa>(empresa);
                    var endereco = empresa.EnderecoNavigation;
                    endereco.Empresa = emp;
                    await dal.GravarEmpresa(emp);
                    await enderecodal.GravarEndereco(empresa.EnderecoNavigation);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmpresaExists(empresa.Id))
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
            return View(empresa);
        }

        

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            
           await dal.EliminarEmpresaPorId(id);
            return RedirectToAction(nameof(Index));
        }

        private bool EmpresaExists(int id)
        {

            return false;
            // return _context.Empresa.Any(e => e.Id == id);
        }

        public async Task<JsonResult> ConsultaWebServiceCorreios(string cep)
        {
            try
            {
                var servicoCorreios = new WebServiceCorreios.AtendeClienteClient();

                var consulta = await servicoCorreios.consultaCEPAsync(cep.Replace("-", ""));

                if (consulta != null)
                {
                    return Json(consulta);
                }
            }
            catch (Exception msg)
            {
                ViewBag.CepNotFound = msg.Message;
            }
            return Json(null);
        }
    }
}
