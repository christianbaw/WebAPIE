using System;
using System.Collections.Generic;
using System.Text;

namespace WebAPI.Core.Models
{
    public class DepartmentHistoryModel
    {
        public int BusinessEntityID { get; set; }
        public int DepartmentID { get; set; }
        public int ShiftID { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
