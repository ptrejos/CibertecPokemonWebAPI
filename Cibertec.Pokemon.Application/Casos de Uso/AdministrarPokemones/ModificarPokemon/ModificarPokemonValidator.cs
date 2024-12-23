using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cibertec.Pokemon.Application.Casos_de_Uso.AdministrarPokemones.ModificarPokemon
{
    public class ModificarPokemonValidator : AbstractValidator<ModificarPokemonRequest>
    {
        public ModificarPokemonValidator()
        {
            RuleFor(x => x.IdPokemon).NotEmpty().WithMessage("El Id es obligatorio.");
            RuleFor(x => x.Nombre).NotEmpty().WithMessage("El Nombre es obligatorio.");
            RuleFor(x => x.tipo).NotEmpty().WithMessage("El Tipo es obligatorio.");
            RuleFor(x => x.PoderCombate).NotEmpty().WithMessage("El Poder de Combate es obligatorio.");
        }
    }
}
