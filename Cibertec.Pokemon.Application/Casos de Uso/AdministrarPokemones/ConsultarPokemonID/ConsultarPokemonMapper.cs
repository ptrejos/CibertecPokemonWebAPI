using AutoMapper;
using Cibertec.Pokemon.Application.Casos_de_Uso.AdministrarPokemones.EliminarPokemon;
using Cibertec.Pokemon.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cibertec.Pokemon.Application.Casos_de_Uso.AdministrarPokemones.ConsultarPokemonID
{
    public class ConsultarPokemonMapper: Profile
    {
        public ConsultarPokemonMapper()
        {
            CreateMap<Domain.Pokemon, ConsultarPokemonResponse>()
            .ForMember(dest => dest.Nombre, opt => opt.MapFrom(x => x.Name))
            .ForMember(dest => dest.IdPokemon, opt => opt.MapFrom(x => x.Id))
            .ForMember(dest => dest.tipo, opt => opt.MapFrom(x => x.Type))
            .ForMember(dest => dest.PoderCombate, opt => opt.MapFrom(x => x.CombatPower));

        }
    }
}
