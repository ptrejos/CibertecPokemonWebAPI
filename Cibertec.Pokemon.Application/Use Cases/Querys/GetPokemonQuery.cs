using Cibertec.Pokemon.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cibertec.Pokemon.Application.Use_Cases.Querys
{
    public class GetPokemonQuery:IRequest<IEnumerable<Domain.Pokemon>>
    {
    }
}
