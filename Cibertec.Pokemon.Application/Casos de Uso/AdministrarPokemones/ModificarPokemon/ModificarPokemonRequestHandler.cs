using AutoMapper;
using Cibertec.Pokemon.Application.Common;
using Cibertec.Pokemon.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cibertec.Pokemon.Application.Casos_de_Uso.AdministrarPokemones.ModificarPokemon
{
    public class ModificarPokemonRequestHandler(IPokemonRepository _pokemonRepository, IMapper _mapper) : IRequestHandler<ModificarPokemonRequest, IResult>
    {
        public async Task<IResult> Handle(ModificarPokemonRequest request, CancellationToken cancellationToken)
        {
            IResult response = null;

            try
            {
                var validador = new ModificarPokemonValidator();
                var validacionDatos = validador.Validate(request);

                if (!validacionDatos.IsValid) throw new ValidationException(validacionDatos.ToString());

                var pokemonExistente = await _pokemonRepository.ObtenerPorId(request.IdPokemon);
                if (pokemonExistente == null) throw new Common.ApplicationException("Pokemon no encontrado.");

                pokemonExistente.Name=request.Nombre;
                pokemonExistente.CombatPower=request.PoderCombate;
                pokemonExistente.Type=request.tipo;

                await _pokemonRepository.Modificar(pokemonExistente);

                var pokemonResponse = _mapper.Map<ModificarPokemonResponse>(pokemonExistente);

                response = new SuccessResult<ModificarPokemonResponse>(pokemonResponse);
            }
            catch (ValidationException ex)
            {
                response = new FailureResult<ValidationException>(ex.Message);
            }
            catch (Common.ApplicationException ex)
            {
                response = new FailureResult<Common.ApplicationException>(ex.Message);
            }
            catch (Exception ex)
            {
                response = new FailureResult<Exception>(ex.Message);
            }

            return response;
        }
    }
}
