using AutoMapper;
using Cibertec.Pokemon.Application.Common;
using Cibertec.Pokemon.Domain;
using Cibertec.Pokemon.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cibertec.Pokemon.Application.Casos_de_Uso.AdministrarPokemones.EliminarPokemon
{
    internal class EliminarPokemonRequestHandler(IPokemonRepository _pokemonRepository, IMapper _mapper) : IRequestHandler<EliminarPokemonRequest, IResult>
    {
        public async Task<IResult> Handle(EliminarPokemonRequest request, CancellationToken cancellationToken)
        {
            IResult response = null;

            try
            {
                var pokemonExistente = await _pokemonRepository.ObtenerPorId(request.IdPokemon);
                if (pokemonExistente == null) throw new Common.ApplicationException("Pokemon no encontrado.");

                await _pokemonRepository.Eliminar(pokemonExistente.Id);

                var pokemonResponse = _mapper.Map<EliminarPokemonResponse>(pokemonExistente);

                response = new SuccessResult<EliminarPokemonResponse>(pokemonResponse);
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
