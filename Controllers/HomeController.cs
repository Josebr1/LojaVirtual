using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using LojaVirtual.Models;
using LojaVirtual.Libraries.Email;
using System.ComponentModel.DataAnnotations;
using System.Text;

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

            try 
            {
                var contato = new Contato();

                contato.Nome= HttpContext.Request.Form["nome"];
                contato.Email = HttpContext.Request.Form["email"];
                contato.Texto = HttpContext.Request.Form["texto"];

                
                
                var listaMensagens = new List<ValidationResult>();
                var context = new ValidationContext(contato);
                
                bool isValid = Validator.TryValidateObject(contato, context, listaMensagens, true);
                
                if(isValid)
                {
                    ContatoEmail.EnviarContatoPorEmail(contato);
                    ViewData["MSG_S"] = "Mensagem de contato enviada com sucesso!";
                } else 
                {
                    StringBuilder sb = new StringBuilder();
                    foreach(var texto in listaMensagens) 
                    {
                        sb.Append(texto.ErrorMessage + "<br />");
                    }
                    ViewData["MSG_E"] = sb.ToString();
                    ViewData["CONTATO"] = contato;
                }

                
            } catch(Exception ex) 
            {
                ViewData["MSG_E"] = "Opps! Tivemos um erro, tente novamente mais tarde!";
            }
            return View("Contato");
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
