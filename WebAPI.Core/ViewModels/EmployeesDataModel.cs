using System;
using System.Collections.Generic;
using System.Text;

namespace WebAPI.Core.ViewModels
{
    public class EmployeesDataModel
    {
        public int NationalIDNumber { get; set; }
        public string JobTitle { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Gender { get; set; }
        public DateTime? HireDate { get; set; }
        public string ShiftName { get; set; }
        public DateTime? ShiftStartTime { get; set; }
        public DateTime? ShiftEndTime { get; set; }

    }
}
