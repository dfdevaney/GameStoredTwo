using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStoredTwo.Data
{
    public class User
    {
        [Key]
        public Guid UserID { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        public virtual List<Games> AllGames { get; set; } = new List<Games>();

        public virtual List<FavoriteGames> FavoriteGames
        {
            get
            {
                List<FavoriteGames> favoriteGames = new List<FavoriteGames>();
                foreach (var games in AllGames)
                {
                    if (games.AddToFavoriteGames == true)
                    {
                        var gameDetails = new FavoriteGames
                        {
                            GameID = games.GameID,
                            GameTitle = games.GameTitle
                        };
                        favoriteGames.Add(gameDetails);
                    }
                }
                return favoriteGames;
            }
            set { }
        }
        public virtual List<Wishlist> Wishlists
        {
            get
            {
                List<Wishlist> wishlists = new List<Wishlist>();
                foreach (var games in AllGames)
                {
                    if (games.AddToWishlist == true)
                    {
                        var gameDetails = new Wishlists
                        {
                            GameID = games.GameID,
                            GameTitle = games.GameTitle
                        };
                        wishlists.Add(gameDetails);
                    }
                }
                return wishlists;
            }
        }
    }
}
