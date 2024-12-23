using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cibertec.Pokemon.Domain.Repositories
{
    public interface IPokemonRepository
    {
        Task<IEnumerable<Pokemon>> ObtenerTodos();
        Task<Pokemon> ObtenerPorId(int id);
        Task<Pokemon> ObtenerPorNombre(string nombre);
        Task<bool> Adicionar(Pokemon pokemon);
        Task<bool> Modificar(Pokemon pokemon);
        Task<bool> Eliminar(int id);
        Task SincronizarPokemons(IEnumerable<Pokemon> pokemons);
    }
}
