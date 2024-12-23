using Cibertec.Pokemon.Domain;
using Cibertec.Pokemon.Domain.Repositories;
using Cibertec.Pokemon.Domain.Servicios;
using Cibertec.Pokemon.Infraestructure.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Cibertec.Pokemon.Infraestructure.Servicios
{
    public class PokemonService : IPokemonService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<PokemonService> _logger;
        private const string BaseUrl = "https://pokeapi.co/api/v2";

        public PokemonService(
            IHttpClientFactory httpClientFactory,
            ILogger<PokemonService> logger)
        {
            _httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Result<Domain.Pokemon>> SyncPokemonsAsync(string nombre, CancellationToken cancellationToken = default)
        {
            try
            {
                using var client = _httpClientFactory.CreateClient();
                var response = await client.GetAsync($"{BaseUrl}/pokemon/{nombre}", cancellationToken);

                response.EnsureSuccessStatusCode();

                var jsonString = await response.Content.ReadAsStringAsync(cancellationToken);
                using var document = JsonDocument.Parse(jsonString);
                var root = document.RootElement;

                var pokemon = new Domain.Pokemon
                {
                    Name = root.GetProperty("name").GetString(),
                    CombatPower = GetPokemonHP(root),
                    Type = GetPokemonType(root)
                };

                return Result<Domain.Pokemon>.Success(pokemon);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al sincronizar Pokemon {Name}", nombre);
                return Result<Domain.Pokemon>.Failure($"Error al sincronizar Pokemon: {ex.Message}");
            }
        }

        private static int GetPokemonHP(JsonElement root)
        {
            try
            {
                var stats = root.GetProperty("stats");
                foreach (var stat in stats.EnumerateArray())
                {
                    var statName = stat.GetProperty("stat").GetProperty("name").GetString();
                    if (string.Equals(statName, "hp", StringComparison.OrdinalIgnoreCase))
                    {
                        return stat.GetProperty("base_stat").GetInt32();
                    }
                }
                return 0;
            }
            catch
            {
                return 0;
            }
        }

        private static string GetPokemonType(JsonElement root)
        {
            try
            {
                var types = root.GetProperty("types");
                if (types.GetArrayLength() > 0)
                {
                    return types[0].GetProperty("type").GetProperty("name").GetString() ?? string.Empty;
                }
                return string.Empty;
            }
            catch
            {
                return string.Empty;
            }
        }
    }
}