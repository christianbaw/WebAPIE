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


        public IEnumerable<EmployeesDataModel> getAll()
        {

            var Employee = (from Emp in _context.EmployeesModel
                       join Dep in _context.DepartmentHistoryModel on Emp.BussinesEntityID equals Dep.BusinessEntityID
                       join Shift in _context.ShiftTimesModel on Dep.ShiftID equals Shift.ShiftID
                       
                       select new EmployeesDataModel
                       {
                           NationalIDNumber = Emp.NationalIDNumber,
                           JobTitle = Emp.JobTitle,
                           BirthDate = Emp.BirthDate,
                           Gender = Emp.Gender,
                           HireDate = Emp.HireDate,
                           ShiftName = Shift.Name,
                           ShiftStartTime = Shift.StartTime,
                           ShiftEndTime = Shift.EndTime

                           
                       }).ToList();

            return Employee;
        }
    }
}
