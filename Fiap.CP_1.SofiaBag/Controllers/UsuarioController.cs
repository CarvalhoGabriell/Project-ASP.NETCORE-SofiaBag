using Fiap.CP_1.SofiaBag.Models;
using Fiap.CP_1.SofiaBag.Persistencia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.CP_1.SofiaBag.Controllers
{
    public class UsuarioController : Controller
    {
        private MochilaContext _context;
        public UsuarioController(MochilaContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Index(string nomeBuscado)
        {
            var busca = _context.Usuarios
                .Where(f =>f.NomeCompleto.Contains(nomeBuscado) || nomeBuscado == null)
                .Include(us => us.Objetos)
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
            TempData["obj"] = "Usuário Cadastrado com sucesso";
            return RedirectToAction("Cadastrar", "Objeto", new { id =user.UsuarioId });
        }

        [HttpPost]
        public IActionResult Remover(int id)
        {
            var buscaUser =_context.Usuarios.Find(id);
            _context.Usuarios.Remove(buscaUser);
            _context.SaveChanges();
            TempData["msg"] = "Usuário Removido com sucesso";
            return RedirectToAction("index");
        }

        [HttpGet]
        public IActionResult Edicao(int id)
        {
            var users = _context.Usuarios.Where(u => u.UsuarioId == id).Include(u=>u.Objetos).FirstOrDefault(); 
            return View(users);
        }

        [HttpPost]
        public IActionResult Edicao(Usuario user)
        {
            _context.Usuarios.Update(user);
            _context.SaveChanges();
            TempData["msg"] = "Usuario Editado com sucesso!";
            return RedirectToAction("index");
        }

    }
}
