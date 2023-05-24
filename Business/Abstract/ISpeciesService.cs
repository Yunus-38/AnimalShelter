using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ISpeciesService
    {
        IDataResult<List<Species>> GetAll();
        IDataResult<Species> GetById(int speciesId);
        IResult Add(Species species);
        IResult Delete(int speciesId);
        IResult Update(int speciesId, Species species);
        IDataResult<List<Genus>> GetSpeciesGenera(int speciesId);
    }


}
