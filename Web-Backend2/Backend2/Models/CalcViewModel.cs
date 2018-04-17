using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Backend2.Models
{
    public class CalcViewModel
    {
        [Required(ErrorMessage = "First operand is required")]
        public String First { get; set; }

        [Required(ErrorMessage = "Second operand is required")]
        public String Second { get; set; }

        public String Operator { get; set; }

        public String Result { get; set; }
    }
}
