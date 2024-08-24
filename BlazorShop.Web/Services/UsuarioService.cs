using BlazorShop.Models.DTOs;
using System.Net.Http.Json;
using System.Net;

namespace BlazorShop.Web.Services
{
    public class UsuarioService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<UsuarioService> _logger;

        public UsuarioService(HttpClient httpClient, ILogger<UsuarioService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<UserDto?> GetUsuario()
        {
            try
            {
                var response = await _httpClient.GetAsync("api/Identity/current-user");

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == HttpStatusCode.NoContent)
                    {
                        // Retorna null se não houver conteúdo
                        return null;
                    }

                    // Lê e retorna o conteúdo JSON
                    return await response.Content.ReadFromJsonAsync<UserDto>();
                }
                else
                {
                    // Registra o erro se a resposta não for bem-sucedida
                    var message = await response.Content.ReadAsStringAsync();
                    _logger.LogError($"Erro ao obter usuário: {message}");
                    throw new Exception($"Status Code: {response.StatusCode} - {message}");
                }
            }
            catch (Exception ex)
            {
                // Registra a exceção e a propaga
                _logger.LogError($"Erro ao obter usuário: {ex.Message}");
                throw;
            }
        }
    }
}
