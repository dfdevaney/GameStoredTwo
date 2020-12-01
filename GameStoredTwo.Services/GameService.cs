using GameStoredTwo.Data;
using GameStoredTwo.Models.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStoredTwo.Services
{
    public class GameService
    {

        private readonly Guid _userId;

        public GameService(Guid userId)
        {
            _userId = userId;
        }


        readonly List<GameDetail> searchResults = new List<GameDetail>();

        public bool CreateGame (GameCreate model)
        {
            var entity = new Game()
            {
                GameTitle = model.GameTitle,
                ConsoleID = model.ConsoleID,
                DeveloperID = model.DeveloperID,
                PublisherID = model.PublisherID,
                Description = model.Description,
                ReleaseDate = model.ReleaseDate,
                AddToFavoriteGames = model.AddToFavoriteGames,
                AddToWishlist = model.AddToWishlist
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Games.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<GameListItem> GetGames()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    from game in ctx.Games
                    select new GameListItem
                    {
                        GameID = game.GameID,
                        GameTitle = game.GameTitle
                    };
                return query.ToArray();
            }
        }

        public GameDetail GetGameByID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var games = ctx.Games.Single(e => e.GameID == id);
                return new GameDetail
                {
                    GameID = games.GameID,
                    GameTitle = games.GameTitle
                };
            }
        }

        public List<GameDetail> GetGameByName(string name)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var games = ctx.Games.Where(e => e.GameTitle.Contains(name)).ToList();
                foreach (var game in games)
                {
                    var foundGame = new GameDetail
                    {
                        GameID = game.GameID,
                        GameTitle = game.GameTitle
                    };
                    searchResults.Add(foundGame);
                }
                return searchResults;
            }
        }

        public List<GameDetail> GetGameByConsole(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var games = ctx.Games.Where(e => e.ConsoleID == id).ToList();
                foreach (var game in games)
                {
                    var foundGame = new GameDetail
                    {
                        GameID = game.GameID,
                        GameTitle = game.GameTitle
                    };
                    searchResults.Add(foundGame);
                }
                return searchResults;
            }
        }

        public List<GameDetail> GetGameByDeveloper(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var games = ctx.Games.Where(e => e.DeveloperID == id).ToList();
                foreach (var game in games)
                {
                    var foundGame = new GameDetail
                    {
                        GameID = game.GameID,
                        GameTitle = game.GameTitle
                    };
                    searchResults.Add(foundGame);
                }
                return searchResults;
            }
        }

        public List<GameDetail> GetGameByPublisher(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var games = ctx.Games.Where(e => e.PublisherID == id).ToList();
                foreach (var game in games)
                {
                    var foundGame = new GameDetail
                    {
                        GameID = game.GameID,
                        GameTitle = game.GameTitle
                    };
                    searchResults.Add(foundGame);
                }
                return searchResults;
            }
        }

        public bool UpdateGame(GameEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var game = ctx.Games.Single(e => e.GameID == model.GameID);
                {
                    game.GameTitle = model.GameTitle;
                    game.Description = model.Description;
                    game.ReleaseDate = model.ReleaseDate;
                    game.ConsoleID = model.ConsoleID;
                    game.DeveloperID = model.DeveloperID;
                    game.PublisherID = model.PublisherID;
                    game.AddToFavoriteGames = model.AddToFavoriteGames;
                    game.AddToWishlist = model.AddToWishlist;
                }
                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteGame(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var game = ctx.Games.Single(e => e.GameID == id);
                ctx.Games.Remove(game);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
