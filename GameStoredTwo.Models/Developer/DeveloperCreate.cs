using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStoredTwo.Models.Developer
{
    public class DeveloperCreate
    {
        [Required]
        public string DeveloperName { get; set; }
    }
}
