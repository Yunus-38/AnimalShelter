using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IGenusService
    {
        IDataResult<List<Genus>> GetAll();
        IDataResult<Genus> GetById(int genusId);
        IResult Add(Genus genus);
        IResult Delete(int genusId);
        IResult Update(int genusId, Genus genus);
    }


}
