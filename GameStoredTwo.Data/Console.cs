using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStoredTwo.Data
{
    public class Console
    {
        [Key]
        public int ConsoleID { get; set; }
        [Required]
        public string ConsoleName { get; set; }
        public string ConsoleDescription { get; set; }
        public virtual List<Game> Games { get; set; } = new List<Game>();
        public List<ConsoleListOfGames> GamesOnConsole
        {
            get
            {
                List<ConsoleListOfGames> newList = List<ConsoleListOfGames>();
                foreach (var game in Games)
                {
                    var gameOnConsole = new ConsoleListOfGames()
                    {
                        GameID = game.GameID,
                        GameTitle = game.GameTitle
                    };
                    newList.Add(gameOnConsole);
                }
                return newList;
            }
            set { }
        }
    }
}
