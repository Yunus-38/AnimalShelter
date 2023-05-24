using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ICityService
    {
        IDataResult<List<City>> GetAll();
        IDataResult<City> GetById(int cityId);
        IResult Add(City city);
        IResult Delete(int cityId);
        IResult Update(int cityId, City city);
    }


}
