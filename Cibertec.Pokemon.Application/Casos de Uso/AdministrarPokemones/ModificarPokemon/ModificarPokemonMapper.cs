using AutoMapper;
using Cibertec.Pokemon.Application.Casos_de_Uso.AdministrarPokemones.RegistrarPokemon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cibertec.Pokemon.Application.Casos_de_Uso.AdministrarPokemones.ModificarPokemon
{
    public class ModificarPokemonMapper: Profile
    {
        public ModificarPokemonMapper()
        {
            CreateMap< ModificarPokemonRequest, Domain.Pokemon>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(x => x.Nombre))
            .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.IdPokemon))
            .ForMember(dest => dest.Type, opt => opt.MapFrom(x => x.tipo))
            .ForMember(dest => dest.CombatPower, opt => opt.MapFrom(x => x.PoderCombate));

            CreateMap<Domain.Pokemon, ModificarPokemonResponse>()
            .ForMember(dest => dest.Nombre, opt => opt.MapFrom(x => x.Name))
            .ForMember(dest => dest.IdPokemon, opt => opt.MapFrom(x => x.Id))
            .ForMember(dest => dest.tipo, opt => opt.MapFrom(x => x.Type))
            .ForMember(dest => dest.PoderCombate, opt => opt.MapFrom(x => x.CombatPower));

        }
    }
}
