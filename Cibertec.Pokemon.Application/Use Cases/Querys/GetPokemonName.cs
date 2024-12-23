using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cibertec.Pokemon.Application.Use_Cases.Querys
{
    public class GetPokemonName :IRequest<Domain.Pokemon>
    {
        public string Nombre { get; set; }
    }
}
