using System;
using System.Collections.Generic;
using System.Text;

namespace WebAPI.Core.Models
{
    public class EmployeesModel
    {
        public int BussinesEntityID { get; set; }
        public int NationalIDNumber { get; set; }
        public string JobTitle { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Gender { get; set; }
        public DateTime? HireDate { get; set; }

    }
}
