using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IAdoptionService
    {
        IDataResult<List<Adoption>> GetAll();
        IDataResult<Adoption> GetById(int adoptionId);
        IResult Add(Adoption adoption);
        IResult Delete(int adoptionId);
        IResult Update(int adoptionId, Adoption adoption);
    }


}
