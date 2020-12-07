using Microsoft.AspNetCore.Mvc;
using NSE.WebApp.MVC.Models;

namespace NSE.WebApp.MVC.Controllers
{
    public class HomeController : Controller
    {   
        [HttpGet]
        [Route("sistema-indisponivel")]
        public IActionResult SistemaIndisponivel()
        {
            var modelErro = new ErrorViewModel
            {
                Mensagem = "O sistema está temporariamente indisponível, isto pode ocorrer em momentos de sobrecarga de usuários.", 
                Titulo = "Sistema indisponível.", 
                ErroCode = 500
            };

            return View("Error", modelErro);
        }

        [HttpGet]
        [Route("error/{id:length(3,3)}")]
        public IActionResult Error(int id)
        {
            var modelError = new ErrorViewModel();

            if (id == 500)
            {
                modelError.Mensagem = "Ocorreu um erro! Tente novamente mais tarde ou contate nosso suporte.";
                modelError.Titulo = "Ocorreu um erro!";
                modelError.ErroCode = id;
            }
            else if (id == 404)
            {
                modelError.Mensagem = "A página que está procurando não existe! <br />Em caso de dúvidas entre em contato com nosso suporte";
                modelError.Titulo = "Ops! Página não encontrada.";
                modelError.ErroCode = id;
            }
            else if (id == 403)
            {
                modelError.Mensagem = "Você não tem permissão para fazer isto.";
                modelError.Titulo = "Acesso Negado";
                modelError.ErroCode = id;
            }
            else
            {
                return StatusCode(404);
            }

            return View("Error", modelError);
        }
    }
}
