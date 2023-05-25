using Core.DataAccess;
using Entities.Concrete;
using Entities.Dtos;
using System.Linq.Expressions;

namespace DataAccess.Abstract
{
    public interface IEmployeeDal : IEntityRepository<Employee>
    {
        public EmployeeDetailsDto GetEmployeeDetails(Expression<Func<EmployeeDetailsDto, bool>> filter);
        public List<EmployeePositionDto> GetAllEmployeePositions(Expression<Func<EmployeePositionDto, bool>> filter);
    }


}
