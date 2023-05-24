using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IEmployeeArchiveService
    {
        IDataResult<List<EmployeeArchive>> GetAll();
        IDataResult<EmployeeArchive> GetById(int employeeArchiveId);
        IResult Add(EmployeeArchive employeeArchive);
        IResult Delete(int employeeArchiveId);
        IResult Update(int employeeArchiveId, EmployeeArchive employeeArchive);
    }


}
