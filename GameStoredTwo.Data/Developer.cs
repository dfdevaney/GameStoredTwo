using GameStoredTwo.Models.Developer;
using GameStoredTwo.Models.Game;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStoredTwo.Data
{
    public class Developer
    {
        [Key]
        public int DeveloperID { get; set; }
        [Required]
        public string DeveloperName { get; set; }
        public virtual List<Game> Games { get; set; } = new List<Game>();
        public List<GameListOfDevelopers> DeveloperGames
        {
            get
            {
                List<GameListOfDevelopers> newList = new List<GameListOfDevelopers>();
                foreach (var game in Games)
                {
                    var gameByDeveloper = new GameListOfDevelopers()
                    {
                        GameID = game.GameID,
                        GameTitle = game.GameTitle
                    };
                    newList.Add(gameByDeveloper);
                }
                return newList;
            }
            set { }
        }
    }
}
