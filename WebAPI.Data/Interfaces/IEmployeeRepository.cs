using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Core.Models;
using WebAPI.Core.ViewModels;

namespace WebAPI.Data.Interfaces
{
    public interface IEmployeeRepository
    {
        Task <List<EmployeesDataModel>> getAll();

        Task <List<Department>> GetDepartments();

        Task <List<TotalMonthsModel>> getUsersByMonth();
    }
}
