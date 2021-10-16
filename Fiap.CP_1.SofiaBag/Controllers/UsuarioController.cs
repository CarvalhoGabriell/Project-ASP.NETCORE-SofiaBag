using Fiap.CP_1.SofiaBag.Models;
using Fiap.CP_1.SofiaBag.Persistencia;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.CP_1.SofiaBag.Controllers
{
    public class UsuarioController : Controller
    {
        private MochilaContext _context;

        [HttpGet]
        public IActionResult Index(string nomeBuscado)
        {
            var busca = _context.Usuarios
                .Where(f =>f.NomeCompleto.Contains(nomeBuscado) || nomeBuscado == null)
                .ToList();
            return View(busca);
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(Usuario user)
        {
            _context.Usuarios.Add(user);
            _context.SaveChanges();
            TempData["msg"] = "Usuário Cadastrado com sucesso";
            return RedirectToAction("Cadastrar");
        }

        [HttpPost]
        public IActionResult Remover(int id)
        {
            var buscaUser =_context.Usuarios.Find(id);
            _context.Usuarios.Remove(buscaUser);
            TempData["msg"] = "Usuário Removido com sucesso";
            return View("index");
        }
    }
}
