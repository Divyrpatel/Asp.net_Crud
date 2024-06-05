using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Models
{
    public  class City
    {
        [Key]
        public int City_Id { get; set; }

        public string Name { get; set; }
        
        public int  State_Id { get; set; }

        [ForeignKey("State_Id")]
        [ValidateNever]
        public  State State { get; set; }
    }
}
