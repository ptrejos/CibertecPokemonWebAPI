using AutoMapper;
using Cibertec.Pokemon.Application.Common;
using Cibertec.Pokemon.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cibertec.Pokemon.Application.Casos_de_Uso.AdministrarPokemones.ConsultarPokemonID;



namespace Cibertec.Pokemon.Application.Casos_de_Uso.AdministrarPokemones.ConsultarPokemonID
{
    public class ConsultarPokemonRequestHandler(IPokemonRepository _pokemonRepository, IMapper _mapper, ILogger<ConsultarPokemonRequestHandler> logger) : IRequestHandler<ConsultarPokemonRequest, IResult>
    {
        public async Task<IResult> Handle(ConsultarPokemonRequest request, CancellationToken cancellationToken)
        {
            IResult response = null;

            try
            {
                var validador = new ConsultarPokemonValidator();
                var validacionDAtos = validador.Validate(request);

                if (!validacionDAtos.IsValid) throw new ValidationException(validacionDAtos.ToString());



                var pokemonEncontrado = await _pokemonRepository.ObtenerPorId(request.IdPokemon);


                if (pokemonEncontrado is not null)
                {

                    response = new SuccessResult<ConsultarPokemonResponse>(_mapper.Map<ConsultarPokemonResponse>(pokemonEncontrado));



                }
                else
                {
                    throw new Common.ApplicationException("No se encontró el pokemon");
                }
            }
            catch (ValidationException ex)
            {
                logger.LogError(ex.Message);
                response = new FailureResult<ValidationException>(ex.Message);


            }
            catch (Common.ApplicationException ex)
            {
                logger.LogError(ex.Message);
                response = new FailureResult<Common.ApplicationException>(ex.Message);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                response = new FailureResult<Exception>(ex.Message);
            }






            return response;
        }
    }
}
