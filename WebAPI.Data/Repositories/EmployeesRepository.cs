using System.Collections.Generic;
using WebAPI.Core.Models;
using WebAPI.Data.Context;
using WebAPI.Data.Interfaces;
using System.Linq;
using WebAPI.Core.ViewModels;

namespace WebAPI.Data.Repositories
{
    public class EmployeesRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _context;

        public EmployeesRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public List<EmployeesDataModel> getAll()
        {

            var Employee = (from Emp in _context.EmployeesModel
                       join Dep in _context.DepartmentHistoryModel on Emp.BusinessEntityID equals Dep.BusinessEntityID
                       join Shift in _context.ShiftTimesModel on Dep.ShiftID equals Shift.ShiftID
                       join person in _context.PersonModel on Emp.BusinessEntityID equals person.BusinessEntityID
                       
                       select new EmployeesDataModel
                       {
                           NationalIDNumber = Emp.NationalIDNumber,
                           JobTitle = Emp.JobTitle,
                           BirthDate = Emp.BirthDate,
                           Gender = Emp.Gender,
                           HireDate = Emp.HireDate,
                           ShiftName = Shift.Name,
                           ShiftStartTime = Shift.StartTime,
                           ShiftEndTime = Shift.EndTime,
                           ProfilePicture = person.PersonPicture,
                           EmployeesName = (string.IsNullOrEmpty(person.Suffix) ? "" : person.Suffix + " ") + (string.IsNullOrEmpty(person.FirstName) ? "" : person.FirstName + ", ") + (string.IsNullOrEmpty(person.LastName) ? "" : person.LastName )





                       }).ToList();

            return Employee;
        }

        public List<DepartmentModel> GetDepartments()
        {
            var Departments = _context.DepartmentModel.ToList();

            return Departments;
        }
    }
}
