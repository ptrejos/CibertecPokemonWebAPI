using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cibertec.Pokemon.Infraestructure.Dto
{
    public class DetallePokemon
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Stat> Stats { get; set; }
        public List<Type> Types { get; set; }
        public Sprites Sprites { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
    }

   

   
}
