using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStoredTwo.Models.Game
{
    public class GameDetail
    {
        public int GameID { get; set; }
        public string GameTitle { get; set; }
        public string Description { get; set; }
        public string ReleaseDate { get; set; }
        public int? ConsoleID { get; set; }
        public string ConsoleName { get; set; }
        public int? DeveloperID { get; set; }
        public string DeveloperName { get; set; }
        public int? PublisherID { get; set; }
        public string PublisherName { get; set; }
        //public bool AddToFavoriteGames { get; set; }
        //public bool AddToWishlist { get; set; }
    }
}
