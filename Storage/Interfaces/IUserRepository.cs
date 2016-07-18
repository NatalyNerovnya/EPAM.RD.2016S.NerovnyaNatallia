using Storage.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage.Interfaces
{
    public interface IUserRepository
    {

        int Add(User user);

        void Delete(User user);

        IEnumerable<User> GetAll();

        int[] SearchForUsers(Func<User, bool> criteria);

        void Save();

        void Load();


    }
}
