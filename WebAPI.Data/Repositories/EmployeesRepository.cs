using System.Collections.Generic;
using WebAPI.Core.Models;
using WebAPI.Data.Context;
using WebAPI.Data.Interfaces;
using System.Linq;
using WebAPI.Core.ViewModels;
using System;
using System.Globalization;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Data.Repositories
{
    public class EmployeesRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _context;

        public EmployeesRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task <List<EmployeesDataModel>> getAll()
        {

            var Employee =  (from Emp in _context.Employee
                            join Dep in _context.EmployeeDepartmentHistory on Emp.BusinessEntityId equals Dep.BusinessEntityId
                            join Shift in _context.Shift on Dep.ShiftId equals Shift.ShiftId
                            join person in _context.Person on Emp.BusinessEntityId equals person.BusinessEntityId

                            select new EmployeesDataModel
                            {
                                NationalIDNumber = Emp.NationalIdnumber,
                                JobTitle = Emp.JobTitle,
                                BirthDate = Emp.BirthDate,
                                Gender = Emp.Gender,
                                HireDate = Emp.HireDate,
                                ShiftName = Shift.Name,
                                ShiftStartTime = Shift.StartTime,
                                ShiftEndTime = Shift.EndTime,
                                ProfilePicture = person.PersonPicture,
                                EmployeesName = (string.IsNullOrEmpty(person.Suffix) ? "" : person.Suffix + " ") + (string.IsNullOrEmpty(person.FirstName) ? "" : person.FirstName + ", ") + (string.IsNullOrEmpty(person.LastName) ? "" : person.LastName)

                            }).ToListAsync();

            return await Employee;
        }
        public async Task <List<Department>> GetDepartments()
        {
            var Departments = _context.Department.ToListAsync();

            return await Departments;
        }
        public async Task<List<TotalMonthsModel>> getUsersByMonth()
        {

            var result = await Task.Run(() => getUsersByMonthAsync());
            return result;

            
        }
        public async Task<List<TotalMonthsModel>> getUsersByMonthAsync() { 

        var monthlyScore = (from f in _context.Employee
                            group f by new { month = f.HireDate.Month, year = f.HireDate.Year } into g
                            select new
                            {
                                dt = string.Format("{0}/{1}", g.Key.month, g.Key.year),
                                total = g.Count()
                            }).ToList();


        var TotalMonthsModel = monthlyScore.Select(x => new { Name = x, Sort = DateTime.ParseExact(x.dt, "M/yyyy", CultureInfo.InvariantCulture) })
        .OrderBy(x => x.Sort)
        .Select(x => x.Name);


        var TotalMonthsModel1 = (from p in TotalMonthsModel
                                 select new TotalMonthsModel
                                 {
                                     Month = p.dt,
                                     Total = p.total
                                 }).ToList();

            return TotalMonthsModel1;
        }

    }
}
