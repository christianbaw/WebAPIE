using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WebAPI.Core.Models
{
    [Table("Shift", Schema = "HumanResources")]
    public class ShiftTimesModel
    {
        [Key]
        public int ShiftID { get; set; }
        public string Name { get; set; }
        public TimeSpan? StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }
    }
}
