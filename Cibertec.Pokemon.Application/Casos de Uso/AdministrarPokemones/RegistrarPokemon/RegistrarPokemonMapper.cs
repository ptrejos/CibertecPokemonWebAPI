using AutoMapper;
using Cibertec.Pokemon.Application.Casos_de_Uso.AdministrarPokemones.ConsultarPokemonID;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cibertec.Pokemon.Application.Casos_de_Uso.AdministrarPokemones.RegistrarPokemon
{
    public class RegistrarPokemonMapper:Profile
    {
        public RegistrarPokemonMapper()
        {

            CreateMap<RegistrarPokemonRequest, Domain.Pokemon>();
                //.ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.Id)); ;
            CreateMap<Domain.Pokemon, RegistrarPokemonResponse>()
            .ForMember(dest => dest.IdPokemon, opt => opt.MapFrom(x => x.Id));
        }
    }
}
