using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class AnimalDetailsDto
    {
        public int AnimalId { get; set; }
        public string AnimalName { get; set; }
        public int AnimalAge { get; set; }
        public DateTime AnimalBirthDate { get; set; }
        public DateTime AnimalEntryDate { get; set; }
        public string AnimalSex { get; set; }
        public string ShelterName { get; set; }
        public string GenusName { get; set; }
        public string SpeciesName { get; set; }
        public string IsAdopted { get; set; }
    }
}
