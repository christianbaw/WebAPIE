using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Core.Models;
using WebAPI.Core.ViewModels;
using WebAPI.Data.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    public class EmployeesApiController : Controller
    {

        private readonly IEmployeeRepository _repository;
        

        public EmployeesApiController(IEmployeeRepository repository)
        {
            _repository = repository;
        }
        
        [HttpGet]
        public async Task <List<EmployeesDataModel>> Get()
        {
            var Employee = _repository.getAll();
            
            if(Employee == null)
            {
                return null;
            }
            else
            {
                return await Employee;
            }

           
        }

        [HttpGet]
        public async Task <List<Department>> getDepartment()
        {
            var Departments = _repository.GetDepartments();

            if (Departments == null)
            {
                return null;
            }
            else
            {
                return await Departments;



            }
        }

        [HttpGet]
        public async Task<List<TotalMonthsModel>> GetEmployeesChart()
        {
            var Departments = _repository.getUsersByMonth();

            if (Departments == null)
            {
                return null;
            }
            else
            {
                return await Departments;



            }
        }

    }
}
