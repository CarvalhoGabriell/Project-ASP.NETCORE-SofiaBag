using Fiap.CP_1.SofiaBag.Models;
using Fiap.CP_1.SofiaBag.Persistencia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.CP_1.SofiaBag.Controllers
{
    public class ObjetoController : Controller
    {
        private MochilaContext _context;

        public ObjetoController(MochilaContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index(string nomeBuscado)
        {
            var busca = _context.Objetos.Where(str => 
                (str.Nome.Contains(nomeBuscado) || nomeBuscado == null)).ToList();
            return View(busca);
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            CarregarCores();
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(Objetos obj)
        {
            _context.Objetos.Add(obj);
            _context.SaveChanges();
            TempData["msg"] = "Objeto Cadastrado com Sucesso!";
            return RedirectToAction("Cadastrar");
        }
        
        [HttpPost]
        public IActionResult Deletar(int id) 
        {
            var busca = _context.Objetos.Find(id);
            // Metodo para procurar na lista de objetos cadastrados (Banco de Dados) e remover
            _context.Objetos.Remove(busca);
            _context.SaveChanges();

            TempData["msg"] = "Objeto Removido com Sucesso";
            return RedirectToAction("Index");
        }

        [HttpGet] // metodo responsavel para direcionar para a tela de edição com os dados do objeto clicado
        public IActionResult Editar(int id)
        {
            CarregarCores();
            // apos no clique no botao "editar" no objeto da tabela esse metodo irá procurar ele na lista de objetos (banco de dados)
            var objeto = _context.Objetos.Find(id);
            return View(objeto);
        }

        [HttpPost]
        public IActionResult Editar(Objetos objs)
        {
            _context.Objetos.Update(objs);
            _context.SaveChanges();
            TempData["msg"] = "Objeto Editado com Sucesso!";
            TempData["rfid"] = objs.CodigoId;

            return RedirectToAction("Index");
        }


        public void CarregarCores()
        {
            var listaCores = new List<string>(new string[]
            { "Vermelho","Azul", "Amarelo", "Verde", "Rosa", "Lilás", "Preto", "Roxa", "Branco", "Marrom",
                "Rosa-Pink", "Laranja", "Cinza", "Prateado", "Dourado","Verde-Escuro", "Violeta", "Azul-Claro", "Azul-Marinho"});
            ViewBag.cores = new SelectList(listaCores);
        }
    }
}
