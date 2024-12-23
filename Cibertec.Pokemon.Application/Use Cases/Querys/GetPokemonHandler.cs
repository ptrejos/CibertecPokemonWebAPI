using Cibertec.Pokemon.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cibertec.Pokemon.Application.Use_Cases.Querys
{
    public class GetPokemonHandler(IPokemonRepository pokemonRepository) : IRequestHandler<GetPokemonQuery, IEnumerable<Domain.Pokemon>>
    {
        public async Task<IEnumerable<Domain.Pokemon>> Handle(GetPokemonQuery request, CancellationToken cancellationToken)
        {
            return await pokemonRepository.ObtenerTodos();
        }
    }
}
