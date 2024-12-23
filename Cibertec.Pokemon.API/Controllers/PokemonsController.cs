using Cibertec.Pokemon.Application.Casos_de_Uso.AdministrarPokemones.ConsultarPokemonID;
using Cibertec.Pokemon.Application.Casos_de_Uso.AdministrarPokemones.EliminarPokemon;
using Cibertec.Pokemon.Application.Casos_de_Uso.AdministrarPokemones.ModificarPokemon;
using Cibertec.Pokemon.Application.Casos_de_Uso.AdministrarPokemones.RegistrarPokemon;
using Cibertec.Pokemon.Application.Common;
using Cibertec.Pokemon.Application.Use_Cases.Querys;
using Cibertec.Pokemon.Domain;
using Cibertec.Pokemon.Infraestructure.Servicios;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Cibertec.Pokemon.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonsController(IMediator _mediator, PokemonService _pokemonService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult> GetAllPokemons()
        {

            var pokemons = await _mediator.Send(new GetPokemonQuery());

            return Ok(pokemons);

        }
        [HttpGet("Consultar/{IdPokemon}")]
        public async Task<ActionResult> GetProductById([FromRoute] ConsultarPokemonRequest request)
        {

            var response = await _mediator.Send(request);

            return new ObjectResult(response);

        }
        [HttpPost("Registrar")]
        public async Task<ActionResult> AddPokemon([FromBody, SwaggerRequestBody("The Product  payload", Required = true)] RegistrarPokemonRequest pokemon)
        {

            var response = await _mediator.Send(pokemon);

            return new ObjectResult(response);

        }

        [HttpPut("Modificar/{IdPokemon}")]
        public async Task<IActionResult> Modificar([FromBody] ModificarPokemonRequest request)
        {

            var response = await _mediator.Send(request);

            if (response is SuccessResult<ModificarPokemonResponse> successResult)
            {
                return Ok(successResult.Value);
            }

            else
            {
                return StatusCode(StatusCodes.Status404NotFound, response);
            }
        }

        [HttpDelete("Eliminar/{IdPokemon}")]
        public async Task<IActionResult> Eliminar(int IdPokemon)
        {
            var response = await _mediator.Send(new EliminarPokemonRequest { IdPokemon = IdPokemon });

            if (response is SuccessResult<EliminarPokemonResponse> successResult)
            {
                return Ok(successResult.Value);
            }

            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocurrió un error.");
            }
        }

        [HttpPost("Sincronizar/{Nombre}")]
        public async Task<IActionResult> SyncPokemons(string Nombre)
        {
            // 1. Obtener el pokemon de la API externa
            var pokemonResult = await _pokemonService.SyncPokemonsAsync(Nombre);
            if (!pokemonResult.IsSuccess)
            {
                return BadRequest(pokemonResult.Error);
            }

            // 2. Verificar si existe por nombre
            var existingPokemon = await _mediator.Send(new GetPokemonName { Nombre = pokemonResult.Data.Name });
            if (existingPokemon != null)
            {
                return Ok(new { Message = $"Pokemon {Nombre} ya existe en la base de datos" });
            }

            // 3. Si no existe, registrarlo
            var registrarRequest = new RegistrarPokemonRequest
            {
                Name = pokemonResult.Data.Name,
                CombatPower = pokemonResult.Data.CombatPower,
                Type = pokemonResult.Data.Type
            };

            var response = await _mediator.Send(registrarRequest);
            if (response is SuccessResult<RegistrarPokemonResponse> successResult)
            {
                //return Ok(successResult.Value);
                
                return new ObjectResult(response);
            }

            return StatusCode(StatusCodes.Status500InternalServerError, "\r\nNo se pudo guardar Pokemon");

        }

    }
}
