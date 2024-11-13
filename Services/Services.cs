using EstadosCidades.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace EstadosCidades.Services
{
    public class BrasilApiService
    {
        private readonly HttpClient _httpClient;

        public BrasilApiService()
        {
            _httpClient = new HttpClient();
        }

        // Buscar Estados
        public async Task<List<Estado>> BuscarEstados()
        {
            var response = await _httpClient.GetStringAsync("https://brasilapi.com.br/api/ibge/uf/v1");
            var estados = JsonSerializer.Deserialize<List<Estado>>(response);
            return estados;
        }

        // Buscar Cidades por Estado
        public async Task<List<Cidade>> BuscarCidadesPorEstado(string estadoSigla)
        {
            var response = await _httpClient.GetStringAsync($"https://brasilapi.com.br/api/ibge/municipios/v1/{estadoSigla}");
            return JsonSerializer.Deserialize<List<Cidade>>(response);
        }


        // Buscar Previsão do Tempo
        public async Task<Previsao> BuscarPrevisaoPorCidade(string cityCode)
        {
            var response = await _httpClient.GetStringAsync($"https://brasilapi.com.br/api/cptec/v1/clima/previsao/{cityCode}");
            return JsonSerializer.Deserialize<Previsao>(response);
        }


        internal async Task BuscarPrevisaoPorCidade(int id)
        {
            throw new NotImplementedException();
        }
    }

}
