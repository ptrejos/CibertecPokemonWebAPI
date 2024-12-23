using AutoMapper;
using Cibertec.Pokemon.Application.Common;
using Cibertec.Pokemon.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cibertec.Pokemon.Application.Casos_de_Uso.AdministrarPokemones.RegistrarPokemon
{
    internal class RegistrarPokemonRequestHandler(IPokemonRepository _pokemonRepository, IMapper _mapper) : IRequestHandler<RegistrarPokemonRequest, IResult>
    {
        public async Task<IResult> Handle(RegistrarPokemonRequest request, CancellationToken cancellationToken)
        {
            IResult response = null;

            try
            {

                var validador = new RegistrarPokemonValidator();
                var validacionDAtos = validador.Validate(request);

                if (!validacionDAtos.IsValid) throw new Exception(validacionDAtos.ToString());

                var entidadDominioPokemon = _mapper.Map<Domain.Pokemon>(request);

                var isOk = await _pokemonRepository.Adicionar(entidadDominioPokemon);

                if (isOk)
                {

                    response = new SuccessResult<RegistrarPokemonResponse>();
                }
                else
                {

                    throw new Exception("Error al registrar el pokemon");
                }




            }
            catch (Exception ex)
            {

                response = new FailureResult<DetailEror>(new DetailEror("COD-POK", ex.Message));
            }




            return response;
        }
    }
}
