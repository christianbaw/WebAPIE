using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WebAPI.Core.Models
{
    [Table("Department", Schema = "HumanResources")]
    public class DepartmentModel
    {
        [Key]
        public Int16 DepartmentID { get; set; }
        public string Name { get; set; }
        public string GroupName { get; set; }
        
    }
}
