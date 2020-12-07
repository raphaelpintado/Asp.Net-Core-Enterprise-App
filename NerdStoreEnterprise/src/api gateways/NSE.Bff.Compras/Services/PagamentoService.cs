using Microsoft.Extensions.Options;
using NSE.Bff.Compras.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace NSE.Bff.Compras.Services
{
    public interface IPagamentoService
    {

    }

    public class PagamentoService : Service, IPagamentoService
    {
        private readonly HttpClient _httpClient;

        public PagamentoService(HttpClient httpClient, IOptions<AppServicesSettings> settings)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(settings.Value.PagamentoUrl);
        }
    }
}