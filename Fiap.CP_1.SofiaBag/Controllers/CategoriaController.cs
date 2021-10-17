using Fiap.CP_1.SofiaBag.Models;
using Fiap.CP_1.SofiaBag.Persistencia;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.CP_1.SofiaBag.Controllers
{
    public class CategoriaController : Controller
    {
        private MochilaContext _context;

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(Categoria categ)
        {

            return RedirectToAction();
        }

        [HttpPost]
        public IActionResult Remover(int id)
        {
            return RedirectToAction();
        }
    }
}
