using BiotokkaApp.Domain.Dtos.Requests;
using BiotokkaApp.Domain.Dtos.Responses;
using BiotokkaApp.Domain.Interfaces.Services;
using System;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace BiotokkaApp.Infra.Data.Service
{
    public class ViaCepService : IViaCepService
    {
        private readonly HttpClient _httpClient;

        public ViaCepService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ViaCepRespondeDTO?> ObterEnderecoAsync(ViaCepRequestDTO request)
        {
            if (request == null || string.IsNullOrWhiteSpace(request.Cep))
                return null;

            // Remove hífen e espaços
            var cep = request.Cep.Replace("-", "").Replace(" ", "").Trim();

            // Valida formato do CEP (8 dígitos)
            if (cep.Length != 8 || !cep.All(char.IsDigit))
                return null;

            try
            {
                var response = await _httpClient.GetAsync($"https://viacep.com.br/ws/{cep}/json/");
                
                if (!response.IsSuccessStatusCode)
                    return null;

                var content = await response.Content.ReadAsStringAsync();
                
                // Deserializa para o DTO
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                var resultado = JsonSerializer.Deserialize<ViaCepRespondeDTO>(content, options);

                // ViaCEP retorna objeto vazio quando CEP não existe
                if (resultado == null || string.IsNullOrWhiteSpace(resultado.Cep))
                    return null;

                return resultado;
            }
            catch
            {
                return null;
            }
        }
    }
}
