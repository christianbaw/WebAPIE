using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WebAPI.Core.Models
{
    [Table("Employee", Schema = "HumanResources")]
    public class EmployeesModel
    {
        [Key]
        public int BusinessEntityID { get; set; }
        public string NationalIDNumber { get; set; }
        public string JobTitle { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Gender { get; set; }
        public DateTime? HireDate { get; set; }

    }
}
