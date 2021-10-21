using Fiap.CP_1.SofiaBag.Models;
using Fiap.CP_1.SofiaBag.Persistencia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.CP_1.SofiaBag.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private MochilaContext _context;

        public HomeController(MochilaContext context, ILogger<HomeController> logger)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var qtdUsers = _context.Usuarios.Count();
            var qtdObjs = _context.Objetos.Count();
            ViewData["totalObjs"] = qtdObjs;
            ViewData["totalUsers"] = qtdUsers;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
