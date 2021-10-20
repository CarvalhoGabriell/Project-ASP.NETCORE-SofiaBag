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

        public CategoriaController(MochilaContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.categorias = _context.Categorias.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Adicionar(Categoria categ)
        {
            _context.Categorias.Add(categ);
            _context.SaveChanges();
            TempData["msg"] = "Categoria Adicionada!";

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Remover(int id)
        {
            var busca = _context.Categorias.Find(id);
            _context.Categorias.Remove(busca);
            _context.SaveChanges();
            TempData["msg"] = "Categoria Removida!";
            return RedirectToAction("index");
        }
    }
}
