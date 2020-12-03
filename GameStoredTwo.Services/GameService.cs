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
                Description = model.Description,
                ReleaseDate = model.ReleaseDate,
                ConsoleID = model.ConsoleID,
                PublisherID = model.PublisherID,
                DeveloperID = model.DeveloperID,
                //AddToFavoriteGames = model.AddToFavoriteGames,
                //AddToWishlist = model.AddToWishlist
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
                        GameTitle = game.GameTitle,
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
                    GameTitle = games.GameTitle,
                    Description = games.Description,
                    ReleaseDate = games.ReleaseDate,
                    ConsoleID = games.Console.ConsoleID,
                    ConsoleName = games.Console.ConsoleName,
                    DeveloperID = games.DeveloperID,
                    DeveloperName = games.Developer.DeveloperName,
                    PublisherID = games.PublisherID,
                    PublisherName = games.Publisher.PublisherName
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
                var entity = ctx.Games.Single(e => e.GameID == model.GameID);
                {
                    if (model.GameTitle != null) entity.GameTitle = model.GameTitle;
                    if (model.Description != null) entity.Description = model.Description;
                    if (model.ReleaseDate != null) entity.ReleaseDate = model.ReleaseDate;
                    if (model.ConsoleID != null) entity.ConsoleID = model.ConsoleID;
                    if (model.DeveloperID != null) entity.DeveloperID = model.DeveloperID;
                    if (model.PublisherID != null) entity.PublisherID = model.PublisherID;
                    //entity.AddToFavoriteGames = model.AddToFavoriteGames;
                    //entity.AddToWishlist = model.AddToWishlist;
                }
                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteGame(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Games.Single(e => e.GameID == id);
                ctx.Games.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
