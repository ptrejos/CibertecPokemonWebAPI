using Cibertec.Pokemon.Application.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cibertec.Pokemon.Application.Casos_de_Uso.AdministrarPokemones.EliminarPokemon
{
    public class EliminarPokemonRequest:IRequest<IResult>
    {
        public int IdPokemon { get; set; }
    }
}
