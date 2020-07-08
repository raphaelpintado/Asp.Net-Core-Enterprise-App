﻿using Microsoft.AspNetCore.Mvc;
using NSE.WebApp.MVC.Models;

namespace NSE.WebApp.MVC.Controllers
{
    public class HomeController : Controller
    {        
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

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
