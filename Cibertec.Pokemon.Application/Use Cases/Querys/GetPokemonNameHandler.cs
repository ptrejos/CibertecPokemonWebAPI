using Cibertec.Pokemon.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cibertec.Pokemon.Application.Use_Cases.Querys
{
    public class GetPokemonNameHandler : IRequestHandler<GetPokemonName, Domain.Pokemon>
    {

        private readonly IPokemonRepository _repository;

        public GetPokemonNameHandler(IPokemonRepository repository)
        {
            _repository = repository;
        }
        public async Task<Domain.Pokemon> Handle(GetPokemonName request, CancellationToken cancellationToken)
        {
            return await _repository.ObtenerPorNombre(request.Nombre);
        }
    }
}
