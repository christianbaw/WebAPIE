﻿using System;
using System.Collections.Generic;
using System.Text;
using WebAPI.Core.Models;
using WebAPI.Core.ViewModels;

namespace WebAPI.Data.Interfaces
{
    public interface IEmployeeRepository
    {
        List<EmployeesDataModel> getAll();

        List<DepartmentModel> GetDepartments();
    }
}
