using Core.Entities;

namespace Entities
{
    public class City : IEntity
    {
        public int CityId { get; set; }
        public string CityName { get; set; }
    }
}