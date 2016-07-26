using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Entities;
using BLL.Interfaces;

namespace BLL
{
    public class Master : UserService, IMaster
    {
        private static Master instance;
        public event Action ActionOnAdd = delegate {};
        public event Action ActionOnDelete = delegate {};
        private Master()
        { }

        public static Master GetInstance()
        {
            return instance ?? (instance = new Master());
        }

        public override int Add(BllUser user)
        {
            ActionOnAdd();
            return repository.Add(user.ToDalUser());
        }

        public override void Delete(BllUser user)
        {
            ActionOnDelete();
            repository.Delete(user.ToDalUser());
        }

        
    }
}
