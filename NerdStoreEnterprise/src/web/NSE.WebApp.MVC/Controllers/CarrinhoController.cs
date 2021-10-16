﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NSE.WebApp.MVC.Models;
using NSE.WebApp.MVC.Services;
using System;
using System.Threading.Tasks;

namespace NSE.WebApp.MVC.Controllers
{
    [Authorize]
    public class CarrinhoController : MainController
    {
        private readonly IComprasBffService _comprasBffService;

        public CarrinhoController(IComprasBffService comprasBffService)
        {
            _comprasBffService = comprasBffService;
        }

        [HttpGet]
        [Route("carrinhocliente")]
        public async Task<IActionResult> Index()
        {
            return View(await _comprasBffService.ObterCarrinho());
        }

        [HttpPost]
        [Route("carrinhocliente/adicionar-item")]
        public async Task<IActionResult> AdicionarItemCarrinho(ItemCarrinhoViewModel itemCarrinho)
        {
            var resposta = await _comprasBffService.AdicionarItemCarrinho(itemCarrinho);

            if (ResponsePossuiErros(resposta))
                return View("Index", await _comprasBffService.ObterCarrinho());

            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route("carrinhocliente/atualizar-item")]
        public async Task<IActionResult> AtualizarItemCarrinho(Guid produtoId, int quantidade)
        {
            var item = new ItemCarrinhoViewModel { ProdutoId = produtoId, Quantidade = quantidade };
            var resposta = await _comprasBffService.AtualizarItemCarrinho(produtoId, item);

            if (ResponsePossuiErros(resposta))
                return View("Index", await _comprasBffService.ObterCarrinho());

            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route("carrinhocliente/remover-item")]
        public async Task<IActionResult> RemoverItemCarrinho(Guid produtoId)
        {
            var resposta = await _comprasBffService.RemoverItemCarrinho(produtoId);

            if (ResponsePossuiErros(resposta))
                return View("Index", await _comprasBffService.ObterCarrinho());

            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route("carrinhocliente/aplicar-voucher")]
        public async Task<IActionResult> AplicarVoucher(string voucherCodigo)
        {
            var resposta = await _comprasBffService.AplicarVoucherCarrinho(voucherCodigo);

            if (ResponsePossuiErros(resposta))
                return View("Index", await _comprasBffService.ObterCarrinho());

            return RedirectToAction("Index");
        }
    }
}
