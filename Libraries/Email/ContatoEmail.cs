using System.Net;
using System.Net.Mail;
using LojaVirtual.Models;

namespace LojaVirtual.Libraries.Email
{
    public class ContatoEmail
    {
        public static void EnviarContatoPorEmail(Contato contato)
        {
            SmtpClient smtp = new SmtpClient("smtp.office365.com", 587);
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("jose.silva.br@outlook.com", "To35@nny85");
            smtp.EnableSsl = true;

            string corpMsg = string.Format("<h2>Contato - Loja Virtual </h2>" +
            "<b>Nome: </b> {0} <br />" + 
            "<b>E-Mail: </b> {1} <br />" + 
            "<b>Texto: </b> {2} <br />" + 
            "<br /> E-Mail enviado autormaticamente do site Loja Virtual.",
            contato.Nome,
            contato.Email,
            contato.Texto);

            MailMessage mensagem = new MailMessage();
            mensagem.From = new MailAddress("jose.silva.br@outlook.com");
            mensagem.To.Add(new MailAddress("tonisilvafm@gmail.com"));
            mensagem.Subject = "Contato - Loja Virtual" + contato.Email;
            mensagem.Body = corpMsg;
            mensagem.IsBodyHtml = true;

            smtp.Send(mensagem);
        }
    }
}