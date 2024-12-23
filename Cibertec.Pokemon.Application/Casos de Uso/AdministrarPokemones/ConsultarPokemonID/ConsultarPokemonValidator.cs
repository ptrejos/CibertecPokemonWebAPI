using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cibertec.Pokemon.Application.Casos_de_Uso.AdministrarPokemones.ConsultarPokemonID
{
    public class ConsultarPokemonValidator:AbstractValidator<ConsultarPokemonRequest>
    {
        public ConsultarPokemonValidator()
        {
            RuleFor(x => x.IdPokemon).NotEmpty().WithMessage("El Id del pokemon es requerido");
        }
    }
}
