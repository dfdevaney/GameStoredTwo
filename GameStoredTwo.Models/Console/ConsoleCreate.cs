using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStoredTwo.Models.Console
{
    public class ConsoleCreate
    {
        [Required]
        public string ConsoleName { get; set; }
        [MaxLength(8000)]
        public string ConsoleDescription { get; set; }
    }
}
