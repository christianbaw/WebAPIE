using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebAPI.Core.Models
{
    public class ShiftTimesModel
    {
        [Key]
        public int ShiftID { get; set; }
        public string Name { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
    }
}
