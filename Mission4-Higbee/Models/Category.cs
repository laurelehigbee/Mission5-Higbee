using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mission5_Higbee.Models
{
    public class Category //sets up class for the category table
    {
        [Key] //sets the category id as the primary key
        [Required] //sets the variable as required
        public int CategoryId { get; set; } //sets the category id variable
        public string CategoryName { get; set; } //sets the category name variable
    }
}
