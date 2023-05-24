using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Species : IEntity
    {
        public int SpeciesId { get; set; }
        public string SpeciesName { get; set; }
    }
}
