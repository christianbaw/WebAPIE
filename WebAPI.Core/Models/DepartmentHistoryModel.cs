using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WebAPI.Core.Models
{
    [Table("EmployeeDepartmentHistory", Schema = "HumanResources")]
    public class DepartmentHistoryModel
    {
        [Key]    
        public int BusinessEntityID { get; set; }
        public int DepartmentID { get; set; }
        public int ShiftID { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
