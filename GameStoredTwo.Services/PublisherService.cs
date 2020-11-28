using GameStoredTwo.Data;
using GameStoredTwo.Models.Publisher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStoredTwo.Services
{
    public class PublisherService
    {
        readonly List<PublisherDetail> searchResults = new List<PublisherDetail>();

        public bool CreatePublisher(PublisherCreate model)
        {
            var entity = new Publisher()
            {
                PublisherName = model.PublisherName
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Publishers.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<PublisherListItem> GetPublishers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    from publisher in ctx.Publishers
                    select new PublisherListItem
                    {
                        PublisherID = publisher.PublisherID,
                        PublisherName = publisher.PublisherName
                    };
                return query.ToArray();
            }
        }

        public PublisherDetail GetPublisherByID(int publisherID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Publishers.Single(e => e.PublisherID == publisherID);
                return new PublisherDetail
                {
                    PublisherID = entity.PublisherID,
                    PublisherName = entity.PublisherName
                };
            }
        }

        public List<PublisherDetail> GetPublisherByName(string name)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var publishers = ctx.Publishers.Where(e => e.PublisherName.Contains(name)).ToList();
                foreach (var publisher in publishers)
                {
                    var foundPublisher = new PublisherDetail
                    {
                        PublisherID = publisher.PublisherID,
                        PublisherName = publisher.PublisherName
                    };
                    searchResults.Add(foundPublisher);
                }
                return searchResults;
            }
        }

        public bool UpdatePublisher(PublisherEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Publishers.Single(e => e.PublisherID == model.PublisherID);

                entity.PublisherName = model.PublisherName;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeletePublisher(int publisherID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Publishers.Single(e => e.PublisherID == publisherID);
                ctx.Publishers.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
