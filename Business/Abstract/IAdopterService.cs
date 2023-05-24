using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IAdopterService
    {
        IDataResult<List<Adopter>> GetAll();
        IDataResult<Adopter> GetById(int adopterId);
        IResult Add(Adopter adopter);
        IResult Delete(int adopterId);
        IResult Update(int adopterId, Adopter adopter);
        IDataResult<List<Animal>> GetAdopterAnimals(int adopterId);
    }


}
