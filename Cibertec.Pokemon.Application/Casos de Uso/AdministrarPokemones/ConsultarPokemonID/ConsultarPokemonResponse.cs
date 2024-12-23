using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cibertec.Pokemon.Application.Casos_de_Uso.AdministrarPokemones.ConsultarPokemonID
{
    public class ConsultarPokemonResponse
    {
        public int IdPokemon { get; set; }
        public string Nombre { get; set; }
        public string tipo { get; set; }
        public int PoderCombate { get; set; }
    }
}
