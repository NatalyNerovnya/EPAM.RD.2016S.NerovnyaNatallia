using Storage.Entities;
using Storage.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage
{
    public class UserRepository : IUserRepository
    {
        private readonly IUserStorage userStorage;

        public UserRepository(IUserStorage storage)
        {
            this.userStorage = storage;
        }

        public int Add(User user)
        {
            return userStorage.Add(new User()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                BirthDate = user.BirthDate,
                Gender = user.Gender,
                VisaRecords = user.VisaRecords != null ? user.VisaRecords : null
            });
        }

        public void Delete(User user)
        {
            userStorage.Delete(user);
        }

        public IEnumerable<User> GetAll()
        {
            return userStorage.GetAll();
        }

        public int[] SearchForUsers(Func<User, bool> criteria)
        {
            Func<User, bool> predicate = user => criteria.Invoke(user);
            return userStorage.SearchFor(predicate);
        }

        public void Save()
        {
            userStorage.Save();
        }

        public void Load()
        {
            userStorage.Load();
        }

    }

}
