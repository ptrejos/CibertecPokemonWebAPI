using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cibertec.Pokemon.Application.Casos_de_Uso.AdministrarPokemones.EliminarPokemon
{
    public class EliminarPokemonValidator:AbstractValidator<EliminarPokemonRequest>
    {
        public EliminarPokemonValidator()
        {
            RuleFor(x => x.IdPokemon).NotEmpty().WithMessage("El Id del Pokemon es obligatorio.");
        }
    }
}
