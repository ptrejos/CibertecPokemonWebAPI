using Cibertec.Pokemon.Application.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cibertec.Pokemon.Application.Casos_de_Uso.AdministrarPokemones.RegistrarPokemon
{
    public class RegistrarPokemonRequest: IRequest<IResult>
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public int CombatPower { get; set; }
    }
}
