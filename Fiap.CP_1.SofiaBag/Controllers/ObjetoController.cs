using Fiap.CP_1.SofiaBag.Models;
using Fiap.CP_1.SofiaBag.Persistencia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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
        public IActionResult Index(string nomeBuscado, int? idUser)
        {

            if (nomeBuscado == null && idUser == null)
            {
                var busca = _context.Objetos
                    .Include(l => l.Lembrete)
                    .Include(l => l.Usuario)
                    .ToList();
                return View(busca);
            }
            var filtro = _context.Objetos.Where(obj => obj.Nome.Contains(nomeBuscado) || obj.UsuarioId == idUser)
                .Include(l => l.Lembrete)
                .Include(l => l.Usuario)
                .ToList();
            return View(filtro);
        }

        [HttpGet]
        public IActionResult Cadastrar(int id)
        {
            CarregarCores();
            ViewBag.usuarios = id;
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(Objetos obj)
        {
            if (obj.Lembrete.Nome == null && obj.ObjetosCateg == null)
            {
                obj.Lembrete = null;
                obj.ObjetosCateg = null;
            }
            _context.Objetos.Add(obj);
            _context.SaveChanges();
            TempData["obj"] = "Objeto Cadastrado com Sucesso!";
            return RedirectToAction("Cadastrar");
        }

        [HttpPost]
        public IActionResult Deletar(int id)
        {
            var busca = _context.Objetos.Find(id);
            // Metodo para procurar na lista de objetos cadastrados (Banco de Dados) e remover
            _context.Objetos.Remove(busca);
            _context.SaveChanges();

            TempData["obj"] = "Objeto Removido com Sucesso";
            return RedirectToAction("Index");
        }

        [HttpGet] // metodo responsavel para direcionar para a tela de edição com os dados do objeto clicado
        public IActionResult Editar(int id)
        {
            CarregarCores();
            // apos no clique no botao "editar" no objeto da tabela esse metodo irá procurar ele no (banco de dados)
            var objeto = _context.Objetos
                .Include(o => o.Lembrete)
                .Include(c => c.ObjetosCateg)
                .Include(u => u.Usuario)
                .Where(o => o.CodigoId == id)
                .FirstOrDefault();
            ViewBag.usuarios = objeto.UsuarioId;
            return View(objeto);
        }

        [HttpPost]
        public IActionResult Editar(Objetos objs)
        {
            if (objs.ObjetosCateg == null)
            {
                
                objs.ObjetosCateg = null;
            }
            _context.Objetos.Update(objs);
            _context.SaveChanges();
            TempData["obj"] = "Objeto Editado com Sucesso!";
            return RedirectToAction("Editar");

        }


        [HttpGet]
        public IActionResult AdicionarCateg(int id)
        {
            // recuperar os objetos cadastrados no banco
            var objetos = _context.Objetos
                .Include(o => o.Lembrete)
                .Include(user => user.Usuario)
                .Where(o => o.CodigoId == id)
                .FirstOrDefault();

            // recuperar todos as categorias cadastradas no banco
            var allCategs = _context.Categorias.Where(c => c.CategoriaId != 0).ToList();

            // pesquisar as categorias associados a um objeto
            var objsCategoria = _context.ObjetosCategoria.Where(o => o.CodigoId == id).Select(o => o.Categoria).ToList();

            // Mostrar na tela as categorias que nao estao associados aquele objeto
            var filtroFinal = allCategs.Where(c => !objsCategoria.Any(c1 => c1.CategoriaId == c.CategoriaId));

            // viewbag carregadas para enviar para o front
            ViewBag.categSelect = new SelectList(filtroFinal, "CategoriaId", "Nome");

            ViewBag.categorias = objsCategoria;

            return View(objetos);
        }


        [HttpPost]
        public IActionResult AdicionarCateg(ObjetoCategoria objCateg)
        {
            _context.ObjetosCategoria.Add(objCateg);
            _context.SaveChanges();
            TempData["obj"] = "Categoria Vinculada com Sucesso!";

            return RedirectToAction("AdicionarCateg"); //new {id = objCateg.CodigoId}
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
