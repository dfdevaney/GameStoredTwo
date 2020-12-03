using GameStoredTwo.Data;
using GameStoredTwo.Models.Developer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStoredTwo.Services
{
    public class DeveloperService
    {
        readonly List<DeveloperDetail> searchResults = new List<DeveloperDetail>();

        public bool CreateDeveloper(DeveloperCreate model)
        {
            var entity = new Developer()
            {
                DeveloperName = model.DeveloperName
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Developers.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<DeveloperListItem> GetDevelopers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    from developer in ctx.Developers
                    select new DeveloperListItem
                    {
                        DeveloperID = developer.DeveloperID,
                        DeveloperName = developer.DeveloperName
                    };
                return query.ToArray();
            }
        }

        public DeveloperDetail GetDeveloperByID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Developers.Single(e => e.DeveloperID == id);
                return new DeveloperDetail
                {
                    DeveloperID = entity.DeveloperID,
                    DeveloperName = entity.DeveloperName
                };
            }
        }

        public List<DeveloperDetail> GetDeveloperByName(string name)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var developers = ctx.Developers.Where(e => e.DeveloperName.Contains(name)).ToList();
                foreach (var developer in developers)
                {
                    var foundDeveloper = new DeveloperDetail
                    {
                        DeveloperID = developer.DeveloperID,
                        DeveloperName = developer.DeveloperName
                    };
                    searchResults.Add(foundDeveloper);
                }
                return searchResults;
            }
        }

        public bool UpdateDeveloper(DeveloperEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Developers.Single(e => e.DeveloperID == model.DeveloperID);

                entity.DeveloperName = model.DeveloperName;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteDeveloper(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Developers.Single(e => e.DeveloperID == id);
                ctx.Developers.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
