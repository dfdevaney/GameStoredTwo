using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStoredTwo.Models.Publisher
{
    public class PublisherCreate
    {
        [Required]
        public string PublisherName { get; set; }
    }
}
