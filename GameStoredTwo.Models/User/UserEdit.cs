using GameStoredTwo.Models.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStoredTwo.Models.User
{
    public class UserEdit
    {
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public List<FavoriteGames> FavoriteGames { get; set; }
        public List<Wishlist> Wishlists { get; set; }
    }
}
