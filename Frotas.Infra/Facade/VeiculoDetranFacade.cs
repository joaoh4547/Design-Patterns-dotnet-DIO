using Frotas.Domain;
using Microsoft.Extensions.Options;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Frotas.Infra.Facade
{
    public class VeiculoDetranFacade : IVeiculoDetran
    {
        private readonly DetranOptions _options;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IVeiculoRepository _veiculoRepository;

        public VeiculoDetranFacade(IOptionsMonitor<DetranOptions> options, IHttpClientFactory httpClientFactory,IVeiculoRepository veiculoRepository)
        {
            _options = options.CurrentValue;
            _httpClientFactory = httpClientFactory;
            _veiculoRepository = veiculoRepository;
        }

        public IHttpClientFactory HttpClientFactory => _httpClientFactory;

        public async Task AgendarVistoriaDetran(Guid id)
        {
            var veiculo = _veiculoRepository.GetById(id);
            var modelRequest = new VistoriaModel
            {
                AgendadoPara = DateTime.Now.AddDays(_options.QuantidadeDeDiasAgendamento),
                Placa = veiculo.Placa
            };

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_options.BaseUrl);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var jsonContent = JsonSerializer.Serialize(modelRequest);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            await client.PostAsync(_options.VistoriaUri, content);

        }
    }
}
