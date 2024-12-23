using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cibertec.Pokemon.Domain;

namespace Cibertec.Pokemon.Infraestructure.Context
{
    public class PokemonDbContext:DbContext
    {
        public PokemonDbContext(DbContextOptions<PokemonDbContext> options) : base(options)
        {
        }
        public DbSet<Domain.Pokemon> Pokemons { get; set; }

    }
}
