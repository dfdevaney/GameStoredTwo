using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStoredTwo.Data
{
    public class Game
    {
        [Key]
        public int GameID { get; set; }
        [Required]
        public string GameTitle { get; set; }
        [ForeignKey(nameof(Console))]
        public int? ConsoleID { get; set; }
        public virtual Console Console { get; set; }
        [ForeignKey(nameof(Publisher))]
        public int? PublisherID { get; set; }
        public virtual Publisher Publisher { get; set; }
        [ForeignKey(nameof(Developer))]
        public int? DeveloperID { get; set; }
        public virtual Developer Developer { get; set; }
        public string Description { get; set; }
        public string ReleaseDate { get; set; }
        public bool AddToFavoriteGames { get; set; }
        public bool AddToWishlist { get; set; }
    }
}
