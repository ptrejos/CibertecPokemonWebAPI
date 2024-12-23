using Cibertec.Pokemon.Domain.Repositories;
using Cibertec.Pokemon.Infraestructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cibertec.Pokemon.Infraestructure.Repositories
{
    public class PokemonRepository(PokemonDbContext context):IPokemonRepository
    {
      

        public async Task<IEnumerable<Domain.Pokemon>> ObtenerTodos()
        {
            return await context.Pokemons.ToListAsync();
        }

        public async Task<Domain.Pokemon> ObtenerPorId(int id)
        {
            return await context.Pokemons.FindAsync(id);
        }

        public async Task<Domain.Pokemon> ObtenerPorNombre(string nombre)
        {
            return await context.Pokemons.FirstOrDefaultAsync(p => p.Name == nombre);
        }

        public async Task<bool> Adicionar(Domain.Pokemon pokemon)
        {
            context.Pokemons.Add(pokemon);
            return await context.SaveChangesAsync()>0;
        }

        public async Task<bool> Modificar(Domain.Pokemon pokemon)
        {
            context.Pokemons.Update(pokemon);
            return await context.SaveChangesAsync()>0;
        }

        public async Task<bool> Eliminar(int id)
        {
            var pokemon = await context.Pokemons.FindAsync(id);
            if (pokemon != null)
            {
                context.Pokemons.Remove(pokemon);
                return await context.SaveChangesAsync()>0;
            }
            else
            {
                return false;
            }
        }

        public async Task SincronizarPokemons(IEnumerable<Domain.Pokemon> pokemons)
        {
            foreach (var pokemon in pokemons)
            {
                if (!context.Pokemons.Any(p => p.Id == pokemon.Id))
                {
                    context.Pokemons.Add(pokemon);
                }
                else
                {
                    throw new InvalidOperationException($"Pokemon con ID {pokemon.Id} ya existe.");
                }
            }
            await context.SaveChangesAsync();
        }

    
    }
}
