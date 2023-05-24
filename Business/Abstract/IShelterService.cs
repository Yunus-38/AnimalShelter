using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IShelterService
    {
        IDataResult<List<Shelter>> GetAll();
        IDataResult<Shelter> GetById(int shelterId);
        IResult Add(Shelter shelter);
        IResult Delete(int shelterId);
        IResult Update(int shelterId, Shelter shelter);
        IDataResult<List<Animal>> GetShelterAnimals(int shelterId);
    }


}
