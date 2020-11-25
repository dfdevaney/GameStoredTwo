using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStoredTwo.Data
{
    public class Publisher
    {
        [Key]
        public int PublisherID { get; set; }
        [Required]
        public string PublisherName { get; set; }
        public virtual List<Game> Games { get; set; } = new List<Game>();
        public List<PublisherListOfGames> PublisherGames
        {
            get
            {
                List<PublisherListOfGames> newList = List<PublisherListOfGames>();
                foreach (var game in Games)
                {
                    var gameByPublisher = new PublisherListOfGames()
                    {
                        GameID = game.GameID,
                        GameTitle = game.GameTitle
                    };
                    newList.Add(gameByPublisher);
                }
                return newList;
            }
            set { }
        }
    }
}
