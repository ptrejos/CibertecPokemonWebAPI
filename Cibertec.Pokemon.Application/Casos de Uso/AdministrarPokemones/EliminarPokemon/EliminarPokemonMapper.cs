using AutoMapper;
using Cibertec.Pokemon.Application.Casos_de_Uso.AdministrarPokemones.ModificarPokemon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cibertec.Pokemon.Application.Casos_de_Uso.AdministrarPokemones.EliminarPokemon
{
    public class EliminarPokemonMapper:Profile
    {
        public EliminarPokemonMapper()
        {
            CreateMap<EliminarPokemonRequest, Domain.Pokemon >()
            
            .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.IdPokemon));

            CreateMap<Domain.Pokemon, EliminarPokemonResponse>()
                .ForMember(dest => dest.IdPokemon, opt => opt.MapFrom(x => x.Id));
        }
    }
}
