using Microsoft.AspNetCore.Mvc;
using NSE.WebApp.MVC.Models;
using NSE.WebApp.MVC.Services;
using System.Threading.Tasks;

namespace NSE.WebApp.MVC.Extensions
{
    public class CarrinhoViewComponent : ViewComponent
    {
        private readonly IComprasBffService _comprasbffService;

        public CarrinhoViewComponent(IComprasBffService comprasbffService)
        {
            _comprasbffService = comprasbffService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await _comprasbffService.ObterQuantidadeCarrinho());
        }
    }
}
