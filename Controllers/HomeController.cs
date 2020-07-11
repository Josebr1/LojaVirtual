using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using LojaVirtual.Models;

namespace LojaVirtual.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index() {
            return View();
        }

        public IActionResult Contato() {
            return View();
        }
        
        public IActionResult ContatoAcao() {

            string nome = HttpContext.Request.Form["nome"];
            string email = HttpContext.Request.Form["email"];
            string texto = HttpContext.Request.Form["texto"];

            return new ContentResult() { Content = "Dados recebidos com sucesso!" };
        }

        public IActionResult Login() {
            return View();
        }

        public IActionResult CadastroCliente() {
            return View();
        }

        public IActionResult CarrinhoCompras() {
            return View();
        }
    }
}
