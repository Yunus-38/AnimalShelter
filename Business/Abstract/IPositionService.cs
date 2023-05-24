using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IPositionService
    {
        IDataResult<List<Position>> GetAll();
        IDataResult<Position> GetById(int positionId);
        IResult Add(Position position);
        IResult Delete(int positionId);
        IResult Update(int positionId, Position position);
    }


}
