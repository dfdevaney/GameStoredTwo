using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStoredTwo.Models.Console
{
    public class ConsoleListOfGames
    {
        [Key]
        public int? GameID { get; set; }
        public string GameTitle { get; set; }
    }
}
