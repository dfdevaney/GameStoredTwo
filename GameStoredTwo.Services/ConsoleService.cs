using GameStoredTwo.Data;
using GameStoredTwo.Models.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Console = GameStoredTwo.Data.Console;

namespace GameStoredTwo.Services
{
    public class ConsoleService
    {
        readonly List<ConsoleDetail> searchResults = new List<ConsoleDetail>();

        //private readonly Guid _userId;
        //public ConsoleService(Guid userId)
        //{
        //    _userId = userId;
        //}

        public bool CreateConsoles(ConsoleCreate model)
        {
            var entity = new Console()
            {
                ConsoleName = model.ConsoleName,
                ConsoleDescription = model.ConsoleDescription
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Consoles.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ConsoleListItem> GetConsoles()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    from console in ctx.Consoles
                    select new ConsoleListItem
                    {
                        ConsoleID = console.ConsoleID,
                        ConsoleName = console.ConsoleName
                    };
                return query.ToArray();
            }
        }

        public ConsoleDetail GetConsoleByID(int consoleID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Consoles.Single(e => e.ConsoleID == consoleID);
                return new ConsoleDetail
                {
                    ConsoleID = entity.ConsoleID,
                    ConsoleName = entity.ConsoleName,
                    ConsoleDescription = entity.ConsoleDescription
                };
            }
        }

        public List<ConsoleDetail> GetConsoleByName(string name)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var consoles = ctx.Consoles.Where(e => e.ConsoleName.Contains(name)).ToList();
                foreach (var console in consoles)
                {
                    var foundConsole = new ConsoleDetail
                    {
                        ConsoleID = console.ConsoleID,
                        ConsoleName = console.ConsoleName,
                        ConsoleDescription = console.ConsoleDescription
                    };
                    searchResults.Add(foundConsole);
                }
                return searchResults;
            }
        }

        public bool UpdateConsole(ConsoleEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Consoles.Single(e => e.ConsoleID == model.ConsoleID);

                entity.ConsoleName = model.ConsoleName;
                entity.ConsoleDescription = model.ConsoleDescription;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteConsole(int consoleID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Consoles.Single(e => e.ConsoleID == consoleID);
                ctx.Consoles.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
