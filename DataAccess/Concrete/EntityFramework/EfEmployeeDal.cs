using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfEmployeeDal : EfEntityRepositoryBase<Employee, ProjectContext>, IEmployeeDal
    {
        public EmployeeDetailsDto GetEmployeeDetails(Expression<Func<EmployeeDetailsDto, bool>> filter)
        {
            using (var context = new ProjectContext())
            {
                var result = from e in context.Employees
                             join s in context.Shelters
                             on e.ShelterId equals s.ShelterId
                             join p in context.Positions
                             on e.PositionId equals p.PositionId
                             select new EmployeeDetailsDto
                             {
                                 EmployeeId = e.EmployeeId,
                                 EmployeeName = e.FirstName + " " + e.LastName,
                                 EmployeeIsActive = e.IsActive,
                                 EmployeePhoneNumber = e.PhoneNumber,
                                 PositionName = p.PositionName,
                                 EmployeeWage = e.Wage,
                                 ShelterName = s.ShelterName
                             };

                return result.SingleOrDefault(filter);
            }
        }

        public List<EmployeePositionDto> GetAllEmployeePositions(Expression<Func<EmployeePositionDto, bool>> filter)
        {
            using (var context = new ProjectContext())
            {
                var result = from e in context.Employees
                             join p in context.Positions
                             on e.PositionId equals p.PositionId
                             join d in context.Departments
                             on p.DepartmentId equals d.DepartmentId
                             where e.IsActive == 1
                             select new EmployeePositionDto
                             {
                                 EmployeeId = e.EmployeeId,
                                 EmployeeName = e.FirstName + " " + e.LastName,
                                 PositionName = p.PositionName,
                                 EmployeeWage = e.Wage,
                                 DepartmentId = d.DepartmentId,
                             };

                return result.Where(filter).ToList();
            }
        }

        public List<GetEmployeesByShelterDto> GetEmployeesByShelter(Expression<Func<GetEmployeesByShelterDto, bool>> filter)
        {
            using (var context = new ProjectContext())
            {
                var result = from e in context.Employees
                             join p in context.Positions
                              on e.PositionId equals p.PositionId
                             join d in context.Departments
                             on p.DepartmentId equals d.DepartmentId
                             where e.IsActive == 1
                             select new GetEmployeesByShelterDto
                             {
                                 EmployeeId = e.EmployeeId,
                                 EmployeeName = e.FirstName + " " + e.LastName,
                                 PositionName = p.PositionName,
                                 EmployeeWage = e.Wage,
                                 DepartmentName = d.DepartmentName,
                                 ShelterId = e.ShelterId
                             };

                return result.Where(filter).ToList();
            }
        }
    }

}
