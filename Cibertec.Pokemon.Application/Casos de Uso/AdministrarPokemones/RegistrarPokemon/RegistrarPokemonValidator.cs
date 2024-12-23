using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cibertec.Pokemon.Application.Casos_de_Uso.AdministrarPokemones.RegistrarPokemon
{
    public class RegistrarPokemonValidator: AbstractValidator<RegistrarPokemonRequest>
    {
        public RegistrarPokemonValidator()
        {
            
            RuleFor(x => x.Name).NotEmpty().WithMessage("El Nombre es obligatorio.");
            RuleFor(x => x.Type).NotEmpty().WithMessage("El Tipo es obligatorio.");
            RuleFor(x => x.CombatPower).NotEmpty().WithMessage("El Poder de Combate es obligatorio.");
        }
    }
}
