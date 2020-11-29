using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStoredTwo.Models.Game
{
    public class GameCreate
    {
        [Required]
        public int GameID { get; set; }
        [Required]
        public string GameTitle { get; set; }
        public string Description { get; set; }
        public string ReleaseDate { get; set; }
        public int? ConsoleID { get; set; }
        public int? PublisherID { get; set; }
        public int? DeveloperID { get; set; }
    }
}
