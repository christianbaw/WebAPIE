using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WebAPI.Core.Models
{

    [Table("Person", Schema = "Person")]
    public class PersonModel
    {
        
        [Key]
        public int BusinessEntityID { get; set; }
        public string PersonType { get; set; }
        public Boolean? NameStyle { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Suffix { get; set; }
        public int EmailPromotion { get; set; }

        public string PersonPicture { get; set; }

    }
}
