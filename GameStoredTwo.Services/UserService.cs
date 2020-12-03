using GameStoredTwo.Data;
using GameStoredTwo.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStoredTwo.Services
{
    public class UserService
    {
        private readonly Guid _userID;
        public UserService(Guid userID)
        {
            _userID = userID;
        }

        readonly List<UserDetail> searchResults = new List<UserDetail>();

        public bool CreateUsers(UserCreate model)
        {
            var entity = new User()
            {
                UserID = _userID,
                FirstName = model.FirstName,
                LastName = model.LastName,
                City = model.City,
                State = model.State,
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Users.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<UserListItem> GetUsers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    from users in ctx.Users
                    select new UserListItem
                    {
                        FirstName = users.FirstName,
                        LastName = users.LastName
                    };
                return query.ToArray();
            }
        }

        public UserDetail GetUserByID(Guid userID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Users.Single(e => e.UserID == userID);
                return new UserDetail
                {
                    FirstName = entity.FirstName,
                    LastName = entity.LastName
                };
            }
        }

        public List<UserDetail> GetUserByLastName(string lastName)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var users = ctx.Users.Where(e => e.LastName.Contains(lastName)).ToList();
                foreach (var user in users)
                {
                    var foundUser = new UserDetail
                    {
                        FirstName = user.FirstName,
                        LastName = user.LastName
                    };
                    searchResults.Add(foundUser);
                }
                return searchResults;
            }
        }

        public bool UpdateUser(UserEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Users.Single(e => e.UserID == _userID);

                entity.FirstName = model.FirstName;
                entity.LastName = model.LastName;
                entity.City = model.City;
                entity.State = model.State;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteUser(Guid userID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Users.Single(e => e.UserID == userID);
                ctx.Users.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

    }
}
