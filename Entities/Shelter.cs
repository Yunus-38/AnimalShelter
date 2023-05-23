using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Shelter
    {
        public int ShelterId { get; set; }
        public int CityId { get; set; }
        public string ShelterName { get; set; }
        public string ShelterAddress { get; set; }
    }
}
